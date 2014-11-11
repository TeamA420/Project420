using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;

namespace BHSCMSApp.Dashboard
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static List<DateTime> list = new List<DateTime>();
        Vendor v = new Vendor();
        RFI r = new RFI();
        int pendingvendors;
        int closedRfi;


        protected void Page_Load(object sender, EventArgs e)
        {
            pendingvendors = v.CountPendingVendors();
            closedRfi = r.CountClosedRFI();

            if(!Page.IsPostBack)
            {
              
            }

            // Put user code to initialize the page here
            //Session.Abandon();
            //FormsAuthentication.SignOut();
            list.Add(DateTime.Today);
            list.Add(DateTime.Today.AddDays(2));
            list.Add(DateTime.Today.AddDays(4));
            list.Add(DateTime.Today.AddDays(6));
      


            foreach (DateTime dt in list)
            {
                calendar.SelectedDates.Add(dt);
            }

          
            vendorlink.Text = string.Format("You have {0} new vendors waiting for approval", pendingvendors);
           

            rfilink.Text = string.Format("You have {0} closed RFI waiting for decision", closedRfi);

            rfp.Text = string.Format("You have {0} closed RFP waiting for decision", 1);

            contract.Text = string.Format("You have {0} expired contracts", 2);

            day1.Text = string.Format("Neuro Sponges RFI closes on {0}", DateTime.Today.ToShortDateString());
            day2.Text = string.Format("Ace Bandages contract expires on {0}", DateTime.Today.AddDays(2).ToShortDateString());
            day3.Text = string.Format("Anesthesia Supplies RFP closes on {0}", DateTime.Today.AddDays(4).ToShortDateString());
            day4.Text = string.Format("Disposable sharps RFP closes on {0}", DateTime.Today.AddDays(6).ToShortDateString());
           
        }
    }
}