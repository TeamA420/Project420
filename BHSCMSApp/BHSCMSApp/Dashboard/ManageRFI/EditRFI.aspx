<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardAdmin.Master" AutoEventWireup="true" CodeBehind="EditRFI.aspx.cs" Inherits="BHSCMSApp.Dashboard.ManageRFI.EditRFI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="background-color:white; width:100%">
       
          <div class="col-md-6">
            					
						<fieldset>
							
                            <br />
                             
                            <hr />
                           <div class="form-group">
							 <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">RFI ID</asp:Label>
								 <div class="col-md-8">   
									<asp:TextBox runat="server" id="rfiid" ReadOnly="true"/>
								</div>
							</div>
                            <br />                            
                            <br />
							<div class="form-group">
							 <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">Category</asp:Label>
								 <div class="col-md-8">   
									<asp:TextBox runat="server" id="category" ReadOnly="true" Width="80%"/>
								</div>
							</div>
                            <br />
                           
                            <br />
                             
                            <hr />
                            <asp:HiddenField ID="hdnstartDate" runat="server" />
                          <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">Start Date:</asp:Label>
                        <div class="col-md-8">               
                            <input type="text" id="startdate" readonly="true" name="startdate" value="2014/11/02"/>                           
                        </div>
                         </div>
     

                         <br />
                         <br />
                           <asp:HiddenField ID="hdnendDate" runat="server"/>
                          <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">End Date:</asp:Label>
                            <div class="col-md-8">               
                                <input type="text" id="enddate" readonly="true" name="enddate" value="2014/11/30"/>                        
                            </div>
                         </div>
						<br />
                            <br />
                            <br />
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">RFI Documents:</asp:Label>
                            <div class="col-md-8">   
                             <asp:HyperLink runat="server" ID="rfiDoc" ForeColor="#529ABB" NavigateUrl="ftp://cis420:Cis$$420@cob-it-blobfish.ad.louisville.edu:21/RFI/56.doc"><span class="glyphicon glyphicon-download"></span>Price notification letter</asp:HyperLink>	 
                             <br />                                                              

                            </div>
                         </div> 



                             
                       <%--<iframe src="http://docs.google.com/gview?url=ftp://cis420:Cis$$420@cob-it-blobfish.ad.louisville.edu:21/RFI/56.doc&embedded=true" style="width:600px; height:500px;" frameborder="0"></iframe>      <br />--%>
                           <br />		
							
						<hr />					
							



                            </fieldset>



   
                        <br />
                   </div>
     <div class="col-md-6">
          <h4>Selected Vendors</h4>
        <br />
        <div class="form-group">
        
       <h5 style="background-color:lightgray; width:90px; padding:4px; border-radius:4px">Participants:</h5>

        <asp:label runat="server" ID="participatelist"></asp:label>
            <asp:Label runat="server" ID="p1" Text="G&G Co"></asp:Label>
            <br />
            <asp:Label runat="server" ID="Label1" Text="Health Supplies"></asp:Label>
        <br />
       </div>

         <div class="form-group">
        
          <h5 style="background-color:lightgray; width:90px; padding:4px; border-radius:4px">View Only:</h5>
        <asp:label runat="server" ID="viewlist"></asp:label>
              <asp:Label runat="server" ID="Label2" Text="AMC Co"></asp:Label>
            <br />
            <asp:Label runat="server" ID="Label3" Text="Cardinal Supplies"></asp:Label>
        <br />
       </div>
         <br />
         <br />
         <div class="form-actions">
								<asp:Button runat="server" Text="Edit selection"  ID="Button1" class="btn btn-info" ToolTip="Click to modify participants list"/>
                                
							</div>
     </div>
          
        </div>
     <br />
    <br />  
    <div class="row" style="background-color:white; width:100%">
                <div class="col-md-12">
        <div class="form-actions">
								<asp:Button runat="server" Text="Save changes" ID="savebtn" class="btn btn-info"/>
                                <asp:Button runat="server" Text="Cancel" ID="cancelbtn" class="btn" OnClick="cancelbtn_Click"/>
		</div>
         </div>
              </div>
      <br />
    <br />   
    <br />
    <br />  
    <br />   
    <br />
    <br /> 
    <br /> 

   <script>
       (function ($) {
           $(document).ready(function() {
               $("#startdate").datepicker();
  
               dtString = $("#<%=hdnstartDate.ClientID%>").val();
  dtString = dtString.split('/');
  var defaultDate = new Date(dtString[2], dtString[1], dtString[0]);
  $("#startdate").datepicker("setDate",defaultDate);

          });
               <%-- $(function () {
                    $("#startdate").datepicker();

                    dtString = $("#<%=hdnendDate.ClientID%>").val();
                    dtString = dtString.split('/');
                    var defaultDate = new Date(dtString[0], dtString[1], dtString[2]);
                    $("#StartDate").datepicker("setDate", defaultDate);
                    
                });--%>
                $(function () {
                    $("#enddate").datepicker();

                    dtString = $("#<%=hdnendDate.ClientID%>").val();
                    dtString = dtString.split('/');
                    var defaultDate = new Date(dtString[2], dtString[1], dtString[0]);
                    $("#enddate").datepicker("setDate", defaultDate);

                });

                //$(function () {
                //    $("#startdate").datepicker({
                //        dateFormat: "yy-mm-dd"
                //    }).datepicker("setDate", "0");
                //});

            });
        

    </script>
    


</asp:Content>
