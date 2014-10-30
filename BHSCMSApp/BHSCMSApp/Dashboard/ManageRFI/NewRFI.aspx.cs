using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using BHSCMSApp.Models;
using BHSCMSApp;
using System.Text;

namespace BHSCMSApp.Dashboard.ManageRFI
{
    public partial class NewRFI : System.Web.UI.Page
    {
        DataTable dt;//DataTable use to store retrieved data
        private int _categoryid;
        private DateTime startdate;
        private DateTime enddate;

       
        //parallel list used to store vendors permissions
        static List<int> vendorlist = new List<int>();
        static List<int> permissionlist = new List<int>();
        private List<string> companylist = new List<string>();


        //path used to save images
        private String fileSavePath = "\\\\cob-blobfish.cbpa.louisville.edu\\BHStorage\\RFI\\";
     


        protected void Page_Load(object sender, EventArgs e)
        {
            //label1.Text = "J AND J HEALTHCARE";
            //label2.Text= "DEROYAL INDUSTRIES INC";
            //label3.Text = "CARDINAL HEALTH";
            //label4.Text = "BSN MEDICAL INC";
            //label5.Text = "MEDLINE INDUSTRIES INC";
            //label6.Text = "G&G INC";

            if (!Page.IsPostBack)
            {
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

            txtCategory.Text = (ddCategories.SelectedItem.Text);
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
            ddCategories.Visible = false;
            ddlCategorylabel.Visible = false;

            txtCategory.Visible = true;
            txtCategorylabel.Visible = true;

            foreach (GridViewRow row in GridView1.Rows)
            {
                RadioButtonList rb = (RadioButtonList)row.FindControl("radiolist");
                
                if (rb.SelectedItem.Value == "1" || rb.SelectedItem.Value == "2")
               {
                    int vendorid = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values[0]);
                    int permissionid = Convert.ToInt32(rb.SelectedItem.Value);
                    string company = (GridView1.DataKeys[row.RowIndex].Values[1]).ToString();

                    vendorlist.Add(vendorid);
                    permissionlist.Add(permissionid);
                    companylist.Add(company);
               }

            }

            StringBuilder builderParticipate = new StringBuilder();
            StringBuilder builderView = new StringBuilder();
            int index = 0;

            foreach (string company in companylist) // Loop through all companies in list
            {
                if(permissionlist[index]==1)
                {
                    builderParticipate.Append(company).Append("<br />"); // Append string to StringBuilder

                }
                else
                {
                    builderView.Append(company).Append("<br />"); // Append string to StringBuilder
                }

                index++;
            }

            participatelist.Text = builderParticipate.ToString();
            viewlist.Text = builderView.ToString();
           

            setupPanel.Visible = true;
            panelVendors.Visible = false;
            panelvendorlist.Visible = true;
        }
       
        //Go back to select category and vendors 
        protected void goback_Click(object sender, EventArgs e)
        {
            panelVendors.Visible = true;
            setupPanel.Visible = false;
            panelvendorlist.Visible = false;

            ddCategories.Visible = true;
            ddlCategorylabel.Visible = true;

            txtCategory.Visible = false;
            txtCategorylabel.Visible = false;

        }

        //upload the RFI document
        private void UploadRFI()
        {
            if((docUpload.PostedFile !=null) && (docUpload.PostedFile.ContentLength>0))
            {
                string fn = System.IO.Path.GetFileName(docUpload.PostedFile.FileName);
                string SaveLocation = Server.MapPath("Documents") + "\\" + fn;
                //string directoryPath = Server.MapPath(string.Format("~/Documents/RFI/{0}/", txtFolderName.Text.Trim()));

            }

        }

        //reviews the RFI before submitting
        protected void review_Click(object sender, EventArgs e)
        {
            try
            {
                startdate = Convert.ToDateTime(Request.Form["startdate"]);
                enddate = Convert.ToDateTime(Request.Form["enddate"]);

                if (enddate > startdate)
                {
                    ErrorMessage.Visible = false;
                    reviewPanel.Visible = true;
                    setupPanel.Visible = false;

                    lblstartdate.Text = startdate.ToShortDateString();
                    lblenddate.Text = enddate.ToShortDateString();

                }
                else
                {

                    FailureText.Text = "Invalid date range. Please select a valid date range";
                    ErrorMessage.Visible = true;
                }

            }

            catch (Exception ex)
            {
                FailureText.Text = "Please select start and end date for RFI";
                ErrorMessage.Visible = true;
            }         

        }

        protected void Submit_Click1(object sender, EventArgs e)
        {
            RFI rfi = new RFI();
            int rfiId;
 
            rfi.CreateNewRFI(UserInfoBoxControl.UserID, lblstartdate.Text, lblenddate.Text, ddCategories.SelectedIndex);
            rfiId = rfi.GetLastRFI_IDinserted();

            int index = 0;//index use to step through the permissionlist 

            foreach (var vendor in vendorlist)
            {
                try
                {
                    string insertQry = "Insert into [BHSCMS].[dbo].[VendorRFITable] (RFI_ID, VendorID, PermissionID) Values (@rfiId, @vendorid, @permissionId)";

                    string connString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;

                    SqlConnection conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand(insertQry, conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@rfiId", rfiId);
                    cmd.Parameters.AddWithValue("@vendorid", vendor);
                    cmd.Parameters.AddWithValue("@permissionId", permissionlist[index]);
                    cmd.ExecuteNonQuery();


                    conn.Close();

                    index++;//increases the index of permissionID list

                }
                catch (Exception ex)
                {

                }

                

            }

            reviewPanel.Visible = false;
            setupPanel.Visible = false;
            panelVendors.Visible = false;
            panelvendorlist.Visible = false;
            ddCategories.Visible = false;
            ddlCategorylabel.Visible = false;
            txtCategory.Visible = false;
            txtCategorylabel.Visible = false;
 
            RFIsubmit.Visible = true;
            lblsuccess.Text = "The RFI has been successfully submitted";
       

            




            
        }

        protected void back_Click(object sender, EventArgs e)
        {
            reviewPanel.Visible = false;
            setupPanel.Visible = true;
        }




    }
}