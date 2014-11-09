using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHSCMSApp;
using System.Data.SqlClient;
using System.Configuration;

namespace BHSCMSApp
{
    public class Functions
    {
    }

    public sealed class FunctionsHelper
    {
        private FunctionsHelper()
        {
        }

        //Reads the contents of a file and returns it as string
        public static string GetFileContents(string FileName)
        {
            string functionReturnValue = null;
            System.IO.StreamReader objStreamReader = default(System.IO.StreamReader);
            objStreamReader = System.IO.File.OpenText(System.Web.HttpContext.Current.Server.MapPath(FileName));
            functionReturnValue = objStreamReader.ReadToEnd();
            objStreamReader.Close();
            return functionReturnValue;
        }



        //This funtion is used to store documents path in the DocumentTable
        public static void UploadDocument(int typeId, int referenceID, byte[] documentData, string documentName, string contentType)
        {
            string connectionString = GetConnectionString();

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQry = "Insert into [BHSCMS].[dbo].[DocumentTable] ([TypeID], [ReferenceID], [DateStamp], Document_Data, Document_Name, Content_Type) values (@typeID, @referenceID, @datestamp, @data, @doc_Name, @contentType)";
                    SqlCommand command = new SqlCommand(insertQry, connection);
                    command.Parameters.AddWithValue("@typeID", typeId);
                    command.Parameters.AddWithValue("@referenceID", referenceID);
                    command.Parameters.AddWithValue("@datestamp", DateTime.Today.ToShortDateString());
                    command.Parameters.AddWithValue("@data", documentData);
                    command.Parameters.AddWithValue("@doc_Name", documentName);
                    command.Parameters.AddWithValue("@contentType", contentType);
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }

            catch (Exception e)
            {
                //System.Console.Error.Write(e.Message);

            }

        }


        //this method returns BHSCMS connection string
        protected static string GetConnectionString()
        {
            string connString = ConfigurationManager.ConnectionStrings["BHSCMS"].ConnectionString;
            return connString;
        }



    }
}