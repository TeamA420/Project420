using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;
using System.Data;
using System.Text;

namespace BHSCMSApp.Dashboard
{
    public partial class WebForm1 : System.Web.UI.Page
    {        
        DataTable rfidt;//DataTable use to store retrieved data
             

        public static List<DateTime> rfidates = new List<DateTime>();
        public static List<string> rfiproducts = new List<string>();
        
        Vendor v = new Vendor();
        RFI i = new RFI();
        RFP p = new RFP();
        Contract ct = new Contract();
        int pendingvendors;
        int closedRfi;
        int closedRfp;
        int expiringContracts;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetLabels();

            SetCalendar();                     
                            

            if(!Page.IsPostBack)
            {
              
            }
           
        }

        //protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        //{
        //   if(e.Day.IsSelected)
        //   {
        //       Label aLabel = new Label();
        //       aLabel.Text = " <br>" + "";
        //       e.Cell.Controls.Add(aLabel);
        //   }
           
           
        //}

        protected void SetLabels()
        {
            pendingvendors = v.CountPendingVendors();
            closedRfi = i.CountClosedRFI();
            closedRfp = p.CountClosedRFP();
            expiringContracts = ct.CountExpiredContracts();
            
            



            vendorlink.Text = string.Format("You have {0} new vendors waiting for approval", pendingvendors);
            rfilink.Text = string.Format("You have {0} closed RFI waiting for decision", closedRfi);
            rfplink.Text = string.Format("You have {0} closed RFP waiting for decision", closedRfp);
            contract.Text = string.Format("You have {0} expired contracts", expiringContracts);

        }

        protected void SetCalendar()
        {
            StringBuilder builderRFIclosing = new StringBuilder();

            rfidt = FunctionsHelper.GetRFIClosingDates();

            rfidates = (from dr in rfidt.AsEnumerable()
                        select dr.Field<DateTime>("EndDate")).ToList<DateTime>();

            rfiproducts = (from dr in rfidt.AsEnumerable()
                           select dr.Field<string>("ProductDescription")).ToList<string>();


            foreach (DateTime dt in rfidates)
            {
                calendar.SelectedDates.Add(dt);

            }

            int index=0;

            foreach(string rfi in rfiproducts)
            {
                string date = rfidates[index].ToShortDateString();
                
                builderRFIclosing.Append(rfi).Append(" is closing on: ").AppendFormat(date).Append("<br />"); // Append string to StringBuilder
                index++;
            }

            lblRficlosing.Text = builderRFIclosing.ToString();


             
        }
    }
}