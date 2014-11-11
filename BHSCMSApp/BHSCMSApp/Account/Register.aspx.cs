using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using BHSCMSApp.Models;
using BHSCMSApp;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace BHSCMSApp.Account
{
    public partial class Register : Page
    {

        Vendor v = new Vendor();
        //instantiate a new vendor from Vendor Class

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillInCategoriesDropDownList();
            }
            
        }

        /// <summary>
        /// Fills the in Category check down list.
        /// </summary>
        protected void FillInCategoriesDropDownList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string qry = "SELECT * FROM [BHSCMS].[dbo].[CategoryTable]";

                SqlCommand cmd = new SqlCommand(qry, connection);
                cmd.Connection.Open();

                SqlDataReader ddlCategories;
                ddlCategories = cmd.ExecuteReader();

                chkCommodities.DataSource = ddlCategories;
                chkCommodities.DataValueField = "CategoryID";
                chkCommodities.DataTextField = "Category";
                chkCommodities.DataBind();
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            

            //variables used to create the new vendor
            #region            
            string company = CompanyName.Text;
            string phone = PhoneNumber.Text;
            string fax = FaxNumber.Text;
            string address1 = Address.Text;
            string address2 = Address2.Text;
            string city = City.Text;
            string state = ddState.SelectedItem.Value;
            string zipcode = Zipcode.Text;
            string regDate = DateTime.Today.ToShortDateString();
            int taxid = Convert.ToInt32(TaxID.Text);
            string username = UserName.Text;
            string password = Password.Text;
            string priEmail = Email.Text;
            string secEmail = AltEmail.Text;
            int roleid = 3;//vendor role is number 3               
            #endregion

           
            if (IsValid)
            {
                v.RegisterUser(username, password, priEmail, secEmail, roleid);

                int userid = v.GetLastUserIDinserted();//gets the user id from the sysusertable

                v.RegisterVendor(company, userid, phone, fax, address1, address2, city, state, zipcode, 2, regDate, taxid);

                AddVendorCategories();//inserts categories the vendor sells in the bridge SellTable

                Page.Response.Redirect("../Default.aspx");          
                

                //IdentityHelper.SignIn(manager, user, isPersistent: false);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }

            else
            {
                ErrorMessage.Text = "Invalid field input.";
            }
        }

        //Records in SellTable the categories the vendor sells
        public void AddVendorCategories()
        {
            int vendorid;

            vendorid = v.GetLastVendorIDinserted();            

            foreach (System.Web.UI.WebControls.ListItem item in chkCommodities.Items)
            {
                if (item.Selected)
                {
                    try
                    {
                        string insertQry = "Insert into [BHSCMS].[dbo].[SellTable] (VendorID, ID) Values (@vendorid, @categoryid)";

                        string connString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;

                        SqlConnection conn = new SqlConnection(connString);
                        SqlCommand cmd = new SqlCommand(insertQry, conn);
                        conn.Open();

                        cmd.Parameters.AddWithValue("@vendorid", vendorid);
                        cmd.Parameters.AddWithValue("@categoryid", item.Value);
                        cmd.ExecuteNonQuery(); 
                                               
                        
                        conn.Close(); 
                       
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }                       

        }

    }
}