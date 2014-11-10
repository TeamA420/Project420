using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BHSCMSApp.Dashboard.Register
{
    public partial class NewVendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (ValidTaxID.IsValid == true)
            //ValidVend.IsValid == true &&
            {

                Vendor vend = new Vendor();
                //instantiate a new employee from Employee Class

                //variables used to create the new employee
                string company = CompanyName.Text;
                string phone = PhoneNumber.Text;
                string fax = Fax.Text;
                string address1 = PAddress.Text;
                string address2 = BAddress.Text;
                //int vendid = int.Parse(VendorID.Text);
                string city = City.Text;
                string state = State.Text;
                string zipcode = ZipCode.Text;
                int taxid = int.Parse(TaxID.Text);
                string email = Email.Text;
                string emailsec = EmailSec.Text;
                string username = UserId.Text;
                string password = Password.Text;
                DateTime registrationDate = System.DateTime.Now;
                int status = 1;
                int roleid = 2;



                vend.RegisterUser(username, password, email, emailsec, roleid);//register the emp in the sysusertable


                int userid = vend.GetLastUserIDinserted();//gets the user id from the sysusertable

                vend.RegisterVendor(company, userid, phone, fax, address1, address2, city, state, zipcode, status, registrationDate.ToString(), taxid);//registers the vendor in the VendorTable

                Page.Response.Redirect("/Dashboard/Account/ManageVendors.aspx");
            }

        }
    }
}