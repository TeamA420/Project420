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





    }
}