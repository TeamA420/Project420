<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardAdmin.Master" AutoEventWireup="true" CodeBehind="EditRFI.aspx.cs" Inherits="BHSCMSApp.Dashboard.ManageRFI.EditRFI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <My:UserInfoBoxControl runat="server" ID="UserInfoBoxControl" Visible="false"/>

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

                          <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                        </asp:PlaceHolder>

                          <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">Start Date:</asp:Label>
                        <div class="col-md-8">               
                              <asp:TextBox ID="StartDate" runat="server" ReadOnly="true" />                           
                        </div>
                         </div>
     

                         <br />
                         <br />
                         
                          <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">End Date:</asp:Label>
                            <div class="col-md-8">               
                                 <asp:TextBox ID="EndDate" runat="server" ReadOnly="true"/>                           
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
								<asp:Button runat="server" Text="Save changes" ID="savebtn" class="btn btn-info" OnClick="savebtn_Click"/>
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
       $(function () {
           $("#<%= StartDate.ClientID %>").datepicker({
               defaultDate: "+1w",
               changeMonth: true,
               numberOfMonths: 3,
               onClose: function (selectedDate) {
                   $("#to").datepicker("option", "minDate", selectedDate);
               }
           });
           $("#<%= EndDate.ClientID %>").datepicker({
               defaultDate: "+1w",
               changeMonth: true,
               numberOfMonths: 3,
               onClose: function (selectedDate) {
                   $("#from").datepicker("option", "maxDate", selectedDate);
               }
           });
       });


    </script>
    


</asp:Content>
