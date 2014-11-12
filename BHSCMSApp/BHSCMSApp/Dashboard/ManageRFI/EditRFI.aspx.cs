using BHSCMSApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BHSCMSApp.Dashboard.ManageRFI
{
    public partial class EditRFI : System.Web.UI.Page
    {
        private int _rfiid;
        RFI rfi = new RFI();
        Employee emp = new Employee();

        protected void Page_Load(object sender, EventArgs e)
        {
            _rfiid = Convert.ToInt32(Request.QueryString["rfiid"]);//gets and convert to int the rfiif passed in the querystring
           
            GetRFIData();
        }

        protected void GetRFIData()
        {          

            try
            {
                //Fetch data from BHSCMS database
                string connString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);

                conn.Open();

                SqlCommand command = new SqlCommand(String.Format("Select R.RFI_ID, R.StartDate, R.EndDate, C.Category from BHSCMS.dbo.RFITable R join BHSCMS.dbo.CategoryTable C on R.CategoryID=C.CategoryID Where R.RFI_ID={0}", _rfiid), conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    this.rfiid.Text = reader["RFI_ID"].ToString();
                    this.category.Text = reader["Category"].ToString();
                    this.StartDate.Text = Convert.ToDateTime(reader["StartDate"].ToString()).ToShortDateString();                    
                    this.EndDate.Text = Convert.ToDateTime(reader["EndDate"].ToString()).ToShortDateString();
                }




            }
            catch (Exception ex)
            {
                //System.Console.Error.Write(e.Message);

            }
        }

        protected void cancelbtn_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("ViewRFIList.aspx");
        }

        protected void savebtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(Request.Form[EndDate.UniqueID]) < Convert.ToDateTime(Request.Form[StartDate.UniqueID]))
            {
                ErrorMessage.Visible = true;
                FailureText.Text = "Invalid date range";
            }
            else
            {
                rfi.UpdateRFI(UserInfoBoxControl.UserID, Request.Form[StartDate.UniqueID], Request.Form[EndDate.UniqueID], _rfiid);
                Page.Response.Redirect("ViewRFIList.aspx");
            }

            
        }

        protected void rfiDoc_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string qry = "Select Document_Data, Document_Name, Content_Type From DocumentTable DT Where DT.TypeID = 2 AND DT.ReferenceID = @RFIID";
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(qry,con))
                {
                    com.Parameters.AddWithValue("@RFIID", rfiid.Text);
                    using(SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            foreach(DataRow dr in dt.Rows)
            {
                DocumentFile dFile = new DocumentFile()
                {
                    FileData = dr[0] as byte[],
                    FileName = dr[1].ToString(),
                    ContentType = dr[2].ToString(),

                };
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + dFile.FileName);
                Response.ContentType = dFile.ContentType;
                Response.AddHeader("Content-Length", dFile.FileData.Length.ToString());
                Response.BinaryWrite(dFile.FileData);
                Response.Flush();
                Response.End();

            }
            

        }
    }
}