<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardVendor.Master" AutoEventWireup="true" CodeBehind="DashboardVendor.aspx.cs" Inherits="BHSCMSApp.Dashboard.DashboardVendor1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  
    <div class="row" style="background-color:white; width:100%; height:300px">


          <div class="col-md-8">
              <h3>Welcome to Vendor Dashboard!!!</h3>
          </div>
        <div class="col-md-1">
              
          </div>

        <div class="col-md-3">
      
            <h4>Upcoming Events:</h4>
            <hr />
            <asp:Calendar runat="server" />

            </div>


    </div>
  
          

          




         

    
    <br />
    <br />   
    <br />
    <br /> 

</asp:Content>
