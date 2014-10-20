<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardAdmin.Master" AutoEventWireup="true" CodeBehind="NewRFI.aspx.cs" Inherits="BHSCMSApp.Dashboard.RFI.NewRFI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <My:UserInfoBoxControl runat="server" ID="UserInfoBoxControl" Visible="false" />
<div class="row" style="background-color:white; width:100%">
<div class="col-md-12">
            


    <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddCategories" CssClass="col-md-4 control-label">Category:</asp:Label>
            <div class="col-md-8">               
                <asp:DropDownList runat="server"  ID="ddCategories" Width="50%" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddCategories_SelectedIndexChanged">
                
                </asp:DropDownList>                    
            </div>
     </div>
    <br />
    <hr />

    <asp:Panel runat="server" Visible="false" ID="panelVendors">
        
      <h5>Select vendor participants:</h5>
    <hr />
       
           
            <%--<p style="text-align: center;">Demo by Priya Darshini - Tutorial @ <a href="http://www.programming-free.com/2013/09/gridview-crud-bootstrap-modal-popup.html">Programmingfree</a></p>--%>
            
                
           
                    <asp:GridView ID="GridView1" runat="server" Width="100%" HorizontalAlign="Center"
                        AutoGenerateColumns="false" AllowPaging="true" OnRowDataBound="GridView1_RowDataBound"
                        DataKeyNames="VendorID" CssClass="table" HeaderStyle-BackColor="#40B3DF" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White">

                         <pagersettings mode="Numeric" position="Bottom" pagebuttoncount="10"/>

                        <pagerstyle backcolor="#C6E8F5" height="20px" verticalalign="Bottom" horizontalalign="Center"/>


                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="View RFI">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkview" />                                   
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Participate">
                                <ItemTemplate>                                     
                                    <asp:CheckBox runat="server" ID="chkbid" />                                       
                                </ItemTemplate>
                            </asp:TemplateField>    
                            <asp:BoundField DataField="VendorID" HeaderText="VendorID" Visible="false"/>                                              
                            <asp:BoundField DataField="CompanyName" HeaderText="Company"/> 
                            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number"/>
                             <asp:BoundField DataField="State" HeaderText="State"/>                                
                            <asp:BoundField DataField="Status" HeaderText="Status"/>      
                            <asp:BoundField DataField="PrimaryEmail" HeaderText="Email"/>                      
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnCont" runat="server" Text="Next" CssClass="btn btn" OnClick="btnCont_Click"/>

    </asp:Panel><%--ends vendor list panel--%>


     <asp:Panel runat="server" Visible="false" ID="setupPanel">
        
         
            <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">Start Date:</asp:Label>
            <div class="col-md-8">               
                <input type="text" id="startdate" />                          
            </div>
     </div>
     

         <br />
         <br />
          <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">End Date:</asp:Label>
            <div class="col-md-8">               
                <input type="text" id="enddate" />                        
            </div>
         </div>

         <br />
         <br />
         <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-4 control-label" Font-Bold="true">Upload RFI:</asp:Label>
            <div class="col-md-8">               
                <asp:FileUpload runat="server" AllowMultiple="false" ID="docUpload"/>                                   
            </div>
         </div>
         
          <br />
         <br />
                    
                   
       <%-- <asp:Button ID="Submit" runat="server" Text="Submit RFI" CssClass="btn btn" >
            <span class="glyphicon glyphicon-star"></span> 
         </asp:Button>       --%>     
           
   
         <button type="button" class="btn btn-default" id="submit"> <span class="glyphicon glyphicon-ok"></span> Create RFI</button>
         




         </asp:Panel><%--ends setup panel--%>


  



















</div><%--end div col--%>
              
</div><%--end div row--%>
       
    <br />
    <br />   
    <br />
    <br />  
    <br />   
    <br />
    <br /> 
    <br /> 


</asp:Content>
