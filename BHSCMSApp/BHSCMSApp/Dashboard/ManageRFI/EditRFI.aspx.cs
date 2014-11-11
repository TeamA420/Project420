using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

                SqlCommand command = new SqlCommand(String.Format("Select R.RFI_ID, R.StartDate, R.EndDate, C.Category from BHSCMS.dbo.RFITable R join BHSCMS.dbo.CategoryTable C on R.CategoryID=C.ID Where R.RFI_ID={0}", _rfiid), conn);

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
    }
}