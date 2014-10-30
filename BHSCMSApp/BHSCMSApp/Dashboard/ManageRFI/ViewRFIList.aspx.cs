using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BHSCMSApp.Dashboard.ManageRFI
{
    public partial class ViewRFIList : System.Web.UI.Page
    {
        DataTable dt;//DataTable use to store retrieved data

        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();//calls this method to get data for grid
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

                strSQL = FunctionsHelper.GetFileContents("SQL/ViewRFI.sql");
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
        protected void addNewRFI_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("NewRFI.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void ddstatusfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddstatusfilter.SelectedItem.Text=="Opened")
            {
                BindGridOpenedRFI();
                
            }
            if(ddstatusfilter.SelectedItem.Text =="Closed")
            {
                BindGridClosedRFI();
            }
            else
            {
                BindGrid();
            }
        }


        private void BindGridOpenedRFI()
        {
            string strSQL = "";

            try
            {
                //Fetch data from BHSCMS database
                string connString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);

                conn.Open();
             
                strSQL = String.Format(FunctionsHelper.GetFileContents("SQL/ViewRFIOpened.sql"), DateTime.Today);
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


        private void BindGridClosedRFI()
        {
            string strSQL = "";

            try
            {
                //Fetch data from BHSCMS database
                string connString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);

                conn.Open();

                strSQL = String.Format(FunctionsHelper.GetFileContents("SQL/ViewRFIClosed.sql"), DateTime.Today.ToShortDateString());
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

    }
}