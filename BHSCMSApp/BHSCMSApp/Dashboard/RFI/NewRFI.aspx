<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardAdmin.Master" AutoEventWireup="true" CodeBehind="NewRFI.aspx.cs" Inherits="BHSCMSApp.Dashboard.RFI.NewRFI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <My:UserInfoBoxControl runat="server" ID="UserInfoBoxControl" Visible="false" />



<div class="row" style="background-color:white; width:100%">
<div class="col-md-12">
            


    <div class="form-group">
        <h4>Select the product category for RFI</h4>
        <br />
            <asp:Label runat="server" AssociatedControlID="ddCategories" CssClass="col-md-4 control-label">Category:</asp:Label>
            <div class="col-md-8">               
                <asp:DropDownList runat="server"  ID="ddCategories" Width="50%" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddCategories_SelectedIndexChanged">
               <asp:ListItem></asp:ListItem>
                </asp:DropDownList>                    
            </div>
     </div>
    <br />
    <hr />

    <asp:Panel runat="server" Visible="false" ID="panelVendors">
        
      <h4>Select vendor participants:</h4>
    <hr />
       
           
            <%--<p style="text-align: center;">Demo by Priya Darshini - Tutorial @ <a href="http://www.programming-free.com/2013/09/gridview-crud-bootstrap-modal-popup.html">Programmingfree</a></p>--%>
            
                
           
                    <asp:GridView ID="GridView1" runat="server" Width="100%" HorizontalAlign="Center"
                        AutoGenerateColumns="false" AllowPaging="true" OnRowDataBound="GridView1_RowDataBound"
                        DataKeyNames="VendorID" CssClass="table" HeaderStyle-BackColor="#40B3DF" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White">

                         <pagersettings mode="Numeric" position="Bottom" pagebuttoncount="10"/>

                        <pagerstyle backcolor="#C6E8F5" height="20px" verticalalign="Bottom" horizontalalign="Center"/>


                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Permissions">
                                <ItemTemplate>
                                    <asp:RadioButtonList runat="server" >
                                        <asp:ListItem Value="1"> Participate</asp:ListItem>
                                        <asp:ListItem Value="2"> View</asp:ListItem>
                                    </asp:RadioButtonList>                                  
                                </ItemTemplate>                                                       
                            </asp:TemplateField>                              
                            <asp:BoundField DataField="VendorID" HeaderText="VendorID" Visible="false"/>                                              
                            <asp:BoundField DataField="CompanyName" HeaderText="Company"/> 
                            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number"/>
                             <asp:BoundField DataField="State" HeaderText="State"/>       
                                                

                            <asp:TemplateField HeaderText="Primary Email">
                            <ItemTemplate>
                          <asp:HyperLink ID="priEmail" runat="server" 
                            NavigateUrl='<%# Eval("PrimaryEmail", "mailto:{0}") %>'
                            Text='<%# Eval("PrimaryEmail") %>'>
                         </asp:HyperLink>
                          </ItemTemplate>
                         </asp:TemplateField>

                          <asp:TemplateField HeaderText="Secondary Email">
                            <ItemTemplate>
                          <asp:HyperLink ID="secEmail" runat="server" 
                            NavigateUrl='<%# Eval("SecondaryEmail", "mailto:{0}") %>'
                            Text='<%# Eval("SecondaryEmail") %>'>
                         </asp:HyperLink>
                          </ItemTemplate>
                         </asp:TemplateField>
                         
                                              
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnCont" runat="server" Text="Next" CssClass="btn btn" OnClick="btnCont_Click"/>

    </asp:Panel><%--ends vendor list panel--%>

    <asp:Panel runat="server" Visible="false" ID="panelvendorlist" BackColor="#E4DAD8">

        <h5>Vendors to participate in this RFI:</h5>
      
        <asp:label runat="server" ID="label1"></asp:label>
        <br />
        <asp:label runat="server" ID="label2"></asp:label>
        <br />
        <asp:label runat="server" ID="label3"></asp:label>
        <br />
        <asp:label runat="server" ID="label4"></asp:label>
        <br />

        <h5>Vendors that can view this RFI:</h5>

        <asp:label runat="server" ID="label5"></asp:label>
        <br />
        <asp:label runat="server" ID="label6"></asp:label>


    </asp:Panel>



    <br />
    <hr />



     <asp:Panel runat="server" Visible="false" ID="setupPanel">
        
         <h4>Select start and end date:</h4>
         <br />
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
           
   
         <asp:button runat="server" type="button" class="btn btn-info" ID="submit" Text="Submit RFI" OnClick="submit_Click"></asp:button>
         <button type="button" class="btn btn-default" id="cancel"> <span class="glyphicon glyphicon-remove"></span> Cancel</button>
         




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
        
    <br />
    <br /> 
    <br /> 


</asp:Content>
