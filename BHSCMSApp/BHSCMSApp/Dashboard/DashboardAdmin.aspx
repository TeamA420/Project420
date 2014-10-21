<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardAdmin.Master" AutoEventWireup="true" CodeBehind="DashboardAdmin.aspx.cs" Inherits="BHSCMSApp.Dashboard.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="background-color:white; width:100%">


          <div class="col-md-8">
              <h3>Notifications:</h3>
              <hr />
              <asp:HyperLink runat="server" ID="vendorlink" NavigateUrl="~/Dashboard/Account/ManageVendors.aspx"></asp:HyperLink>
              <asp:label runat="server" ID="vendor"></asp:label>
              <br />
              <br />
              <asp:HyperLink runat="server" ID="rfilink" NavigateUrl="~/Dashboard/RFI/NewRFI.aspx"></asp:HyperLink>
              <asp:label runat="server" ID="rfi"></asp:label>
              <br />
              <br />
               <asp:label runat="server" ID="rfp"></asp:label>
              <br />
              <br />
              <asp:label runat="server" ID="contract"></asp:label>

             
          </div>
       <%-- <div class="col-md-1">
              
          </div>--%>

        <div class="col-md-4">
      
            <h4>Upcoming Events:</h4>
            <hr />
            <asp:Calendar runat="server" Width="100%" ID="calendar" TitleStyle-BackColor="#D06730" TitleStyle-ForeColor="White"
                 Font-Bold="true" TitleFormat="Month" SelectedDayStyle-BackColor="#539BBC" cellpadding="3" cellspacing="3"/>

              <hr />
              <span class="glyphicon glyphicon-flag"> </span> <asp:label runat="server" ID="day1" ForeColor="DarkBlue"></asp:label>
              <br />
              
              <span class="glyphicon glyphicon-flag"> </span> <asp:label runat="server" ID="day2" ForeColor="DarkBlue"></asp:label>
              <br />
              
               <span class="glyphicon glyphicon-flag"> </span> <asp:label runat="server" ID="day3" ForeColor="DarkBlue"></asp:label>
              <br />
            
              <span class="glyphicon glyphicon-flag"> </span> <asp:label runat="server" ID="day4" ForeColor="DarkBlue"></asp:label>


            </div>


    </div>
  
          

          




         

    
     <br />
    <br />   
    <br />
    <br />  
    <br />   
 
 
</asp:Content>
