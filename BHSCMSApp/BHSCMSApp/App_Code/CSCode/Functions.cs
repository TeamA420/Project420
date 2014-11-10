using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BHSCMSApp;
using System.Data.SqlClient;
using System.Configuration;
using BHSCMSApp.Models;

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
<<<<<<< HEAD
        public static void UploadDocument(int typeId, string filepath, int referenceID)
=======
        public static void UploadDocument(DocumentFile file)
>>>>>>> origin/master
        {
            string connectionString = GetConnectionString();

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

<<<<<<< HEAD
                    string insertQry = "Insert into [BHSCMS].[dbo].[DocumentTable] ([TypeID], [FilePath], [ReferenceID], [DateStamp]) values (@typeID, @filepath, @referenceID, @datestamp)";
                    SqlCommand command = new SqlCommand(insertQry, connection);
                    command.Parameters.AddWithValue("@typeID", typeId);
                    command.Parameters.AddWithValue("@filepath", filepath);
                    command.Parameters.AddWithValue("@referenceID", referenceID);
                    command.Parameters.AddWithValue("@datestamp", DateTime.Today.ToShortDateString());                    
=======
                    string insertQry = "Insert into [BHSCMS].[dbo].[DocumentTable] ([TypeID], [ReferenceID], [DateStamp], Document_Data, Document_Name, Content_Type) values (@typeID, @referenceID, @datestamp, @data, @doc_Name, @contentType)";
                    SqlCommand command = new SqlCommand(insertQry, connection);
                    command.Parameters.AddWithValue("@typeID", file.TypeID);
                    command.Parameters.AddWithValue("@referenceID", file.RFIID);
                    command.Parameters.AddWithValue("@datestamp", DateTime.Today.ToShortDateString());
                    command.Parameters.AddWithValue("@data", file.FileData);
                    command.Parameters.AddWithValue("@doc_Name", file.FileName);
                    command.Parameters.AddWithValue("@contentType", file.ContentType);
>>>>>>> origin/master
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