#region
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

namespace BHSCMSApp.Dashboard.Register
{
    public partial class EditVendor : System.Web.UI.Page
    {
        //declaring variables
        #region
        public int _userID;
        //public string _company;
        //public string _phone;
        //public string _fax;
        //public string _address1;
        //public string _address2;
        //public string _city;
        //public string _state;
        //public string _zipcode;
        //public int _status;
        //public int _taxid;
        //public string _username;
        //public string _password;
        //public string _priEmail;
        //public string _secEmail;
        
        #endregion
       

        protected void Page_Load(object sender, EventArgs e)
        {
            _userID = Convert.ToInt32(Request.QueryString["userID"]);//gets and convert to int the userid passed in the querystring

            BindGrid();//calls this method to get data for the fields     
        }

        private void BindGrid()
        {          

            string strSQL = "";
            try
            {
                //Fetch data from BHSCMS database
                string connString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);

                conn.Open();


                strSQL = string.Format(FunctionsHelper.GetFileContents("SQL/UserVendorDetails.sql"), _userID);


                SqlCommand command = new SqlCommand(strSQL, conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //this.lblVendorID.Text = reader["VendorID"].ToString();
                    //this.lblUserID.Text = reader["UserID"].ToString();
                   
                    this.txtcompany.Text = reader["CompanyName"].ToString();
                    this.txtphone.Text = reader["PhoneNumber"].ToString();
                    this.txtfax.Text = reader["FaxNumber"].ToString();
                    this.txtaddress1.Text = reader["AddressLine1"].ToString();
                    this.txtaddress2.Text = reader["AddressLine2"].ToString();
                    this.txtcity.Text = reader["City"].ToString();
                    this.txtstate.Text = reader["State"].ToString();
                    this.txtZipcode.Text = reader["ZipCode"].ToString();
                    this.ddstatus.SelectedIndex = (Convert.ToInt32(reader["StatusID"]) - 1);
                    this.txttaxid.Text = reader["TaxID"].ToString();
                    this.txtusername.Text = reader["UserName"].ToString();
                    this.txtpassword.Text = reader["Password"].ToString();
                    this.txtpriemail.Text = reader["PrimaryEmail"].ToString();
                    this.txtsecemail.Text = reader["SecondaryEmail"].ToString();
                }



            }
            catch (Exception e)
            {
                //System.Console.Error.Write(e.Message);

            }
        }      

        
      
        protected void cancelbtn_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("ManageVendors.aspx");
        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
            Vendor v = new Vendor();

            //assigns input fields data to variables which are used to update
            #region
            //_company = this.txtCompany.Text;
            //_phone = this.txtPhone.Text;
            //_fax = this.txtFax.Text;
            //_address1 = this.txtAddress1.Text;
            //_address2 = this.txtAddress2.Text;
            //_city = this.txtCity.Text;
            //_state = this.txtState.Text;
            //_zipcode = this.txtZipCode.Text;
            //_status = (this.ddstatus.SelectedIndex) + 1;
            //_taxid = Convert.ToInt32(this.txtTaxID.Text);
            //_username = this.txtUsername.Text;
            //_password = this.txtPassword.Text;
            //_priEmail = this.txtPriEmail.Text;
            //_secEmail = this.txtSecEmail.Text;
            #endregion

            //v.UpdateUser(this.txtUsername.Text, this.txtPassword.Text, this.txtPriEmail.Text, this.txtSecEmail.Text, 3, _userID);
            //v.UpdateVendor(_userID, this.txtcompany.Text, this.txtPhone.Text, this.txtFax.Text, this.txtAddress1.Text, this.txtAddress2.Text, this.txtCity.Text, this.txtState.Text, this.txtZipCode.Text, (this.ddstatus.SelectedIndex) + 1 , Convert.ToInt32(this.txtTaxID.Text));


            v.UpdateUser(this.txtusername.Text, this.txtpassword.Text, this.txtpriemail.Text, this.txtsecemail.Text, 3, _userID);
            v.UpdateVendor(_userID, this.txtcompany.Text, this.txtphone.Text, this.txtfax.Text, this.txtaddress1.Text, this.txtaddress2.Text, this.txtcity.Text, this.txtstate.Text, this.txtZipcode.Text, (this.ddstatus.SelectedIndex) + 1, Convert.ToInt32(this.txttaxid.Text));


            Page.Response.Redirect("ManageVendors.aspx");

        }

       
        


    }
}