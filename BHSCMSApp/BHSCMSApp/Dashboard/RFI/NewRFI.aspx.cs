using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BHSCMSApp.Models;
using BHSCMSApp;

namespace BHSCMSApp.Dashboard.RFI
{
    public partial class NewRFI : System.Web.UI.Page
    {
        DataTable dt;//DataTable use to store retrieved data
        private int _categoryid;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            label1.Text = "J AND J HEALTHCARE";
            label2.Text= "DEROYAL INDUSTRIES INC";
            label3.Text = "CARDINAL HEALTH";
            label4.Text = "BSN MEDICAL INC";
            label5.Text = "MEDLINE INDUSTRIES INC";
            label6.Text = "G&G INC";

            if (!Page.IsPostBack)
            {
                //ddCategories.Items.Add(new ListItem("Select from list..."));
                
                FillInCategoriesDropDownList();
            }
        }


        /// <summary>
        /// Fills the in Category dropdown list.
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

                ddCategories.DataSource = ddlCategories;
                ddCategories.DataValueField = "ID";
                ddCategories.DataTextField = "Category";
                ddCategories.DataBind();
            }
        }

        protected void ddCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            _categoryid = (ddCategories.SelectedIndex);
            BindGrid(_categoryid);            
            panelVendors.Visible = true;
        }


        private void BindGrid(int categoryid)
        {
            string strSQL= "";

            try
            {
                //Fetch data from BHSCMS database
                string connString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);

                conn.Open();

                strSQL = string.Format(FunctionsHelper.GetFileContents("SQL/RFICategoryVendors.sql"), categoryid);
                SqlDataAdapter adapter = new SqlDataAdapter(strSQL, conn);


                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dt = ds.Tables[0];
                //Bind the fetched data to gridview
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception e)
            {
                //System.Console.Error.Write(e.Message);

            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                    //switch (status)
                    //{
                    //    case "Approved":
                    //        e.Row.Cells[6].ForeColor = System.Drawing.Color.Green; // Column color
                    //        e.Row.Cells[6].Font.Bold = true;
                    //        break;

                    //    case "Pending":
                    //        e.Row.Cells[6].ForeColor = System.Drawing.Color.Blue; // Column color
                    //        //e.Row.Cells[6].Font.Bold = true;
                    //        break;

                    //    case "Disapproved":
                    //        e.Row.Cells[6].ForeColor = System.Drawing.Color.Red; // Column color                        
                    //        break;

                    //    case "Sanctioned":
                    //        e.Row.Cells[6].ForeColor = System.Drawing.Color.Red; // Column color
                    //        e.Row.Cells[6].Font.Bold = true;
                    //        break;

                    //    default:
                    //        e.Row.Cells[6].ForeColor = System.Drawing.Color.Black; // Column color
                    //        e.Row.Cells[6].Font.Bold = true;
                    //        break;
                    //}


                }
            }
        }

        protected void btnCont_Click(object sender, EventArgs e)
        {
            setupPanel.Visible = true;
            panelVendors.Visible = false;
            panelvendorlist.Visible = true;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            List<int> vendorlist;
            List<int> permissionid;
          
           
           

        }

    }
}