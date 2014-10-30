using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using BHSCMSApp;

namespace BHSCMSApp
{
    public class RFI
    {       

        public RFI()//Empty RFI constructor
        {

        }


         




        //creates new RFI
        public void CreateNewRFI(int userid, string startdate, string enddate, int categoryid)
        {
            string connectionString = GetConnectionString();

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQry = "Insert into [BHSCMS].[dbo].[RFITable] (UserID, StartDate, EndDate, CategoryID, CreatedDate) values (@userid, @startdate, @enddate, @categoryid, @createddate)";
                    SqlCommand command = new SqlCommand(insertQry, connection);
                    command.Parameters.AddWithValue("@userid", userid);
                    command.Parameters.AddWithValue("@startdate", startdate);
                    command.Parameters.AddWithValue("@enddate", enddate);
                    command.Parameters.AddWithValue("@categoryid", categoryid);
                    command.Parameters.AddWithValue("@createddate", DateTime.Today.ToShortDateString()); 
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }

            catch (Exception e)
            {
                //System.Console.Error.Write(e.Message);

            }

        }

        public void AddVendorstoRFI(int rfiID, List<int> vendorid, List<int> permissionID)
        {
            string connectionString = GetConnectionString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQry = "Insert into [BHSCMS].[dbo].[RFIVendorTable] (RFI_ID, VendorID, PermissionID) values (@rfiID, @vendorid, @permissionid)";
                    SqlCommand command = new SqlCommand(insertQry, connection);


                    command.Parameters.AddWithValue("@rfiID", rfiID);
                 
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }

            
            catch (Exception e)
            {
                //System.Console.Error.Write(e.Message);

            }

        }


        //this method will return the last RFI_ID registered in the RFITable
        public int GetLastRFI_IDinserted()
        {
            int id;
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string qry = "select MAX(RFI_ID) as Max from BHSCMS.dbo.RFITable";
                SqlCommand command = new SqlCommand(qry, connection);
                connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }

            return id;
        }





        //Updates existing RFI
        public void UpdateRFI(int empid, string startdate, string enddate, int categoryid, int id)
        {

            string connectionString = GetConnectionString();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQry = "update BHSCMS.dbo.RFITable set EmpID=@empid, StartDate=@startdate, EndDate=@enddate, CategoryID=@categoryid, ModifiedDate=@modifieddate where RFI_ID=@id";

                    SqlCommand updateCmd = new SqlCommand(updateQry, connection);

                    updateCmd.Parameters.AddWithValue("@empid", empid);
                    updateCmd.Parameters.AddWithValue("@startdate", startdate);
                    updateCmd.Parameters.AddWithValue("@enddate", enddate);
                    updateCmd.Parameters.AddWithValue("@categoryid", categoryid);
                    updateCmd.Parameters.AddWithValue("@modifieddate", DateTime.Today.ToShortDateString()); 
                    updateCmd.Parameters.AddWithValue("@id", id);
                    updateCmd.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                //System.Console.Error.Write(e.Message);

            }

        }



        //this method returns BHSCMS connection string
        protected string GetConnectionString()
        {
            string connString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;
            return connString;
        }
    }
}