﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardAdmin.Master" AutoEventWireup="true" CodeBehind="ManageVendors.aspx.cs" Inherits="BHSCMSApp.Dashboard.ManageVendors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="row" style="background-color:white; width:100%">
          <div class="col-md-12">
            
    

      <h4>List of vendors registered in the system:</h4>
    <hr />   
           
            <div class="form-group">     
               <asp:Label runat="server" AssociatedControlID="ddstatusfilter" CssClass="col-md-2 control-label">Filter by Status:</asp:Label>
                 
                 <div class="col-md-8">
             
                 <asp:DropDownList runat="server" ID="ddstatusfilter" AutoPostBack="true" CssClass="form-control" Width="20%" DataSourceID="DropDownDataSource"
                      DataTextField="Status" DataValueField="Status" AppendDataBoundItems="true">
                     <asp:ListItem Text="Show All" Value=""></asp:ListItem>
                </asp:DropDownList>
                     <asp:SqlDataSource ID="DropDownDataSource" runat="server" ConnectionString="<%$ connectionStrings:BHSCMS %>"
                         SelectCommand="SELECT Distinct r.Status From BHSCMS.dbo.VendorTable e join BHSCMS.dbo.StatusTable r on e.StatusID = r.StatusID"></asp:SqlDataSource>

             </div>
        </div>
              <br />
              <br />
              <br />


           
                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                        HorizontalAlign="Center"
                        AutoGenerateColumns="false" 
                        AllowPaging="true" 
                        DataSourceID="GridDataSource"
                        OnRowDataBound="GridView1_RowDataBound" 
                        OnPageIndexChanging="GridView1_PageIndexChanging"
                        DataKeyNames="UserID" CssClass="table" 
                        HeaderStyle-BackColor="#40B3DF" 
                        HeaderStyle-Font-Bold="true" 
                        HeaderStyle-ForeColor="White"
                        AllowSorting="true" OnSorting="GridView1_Sorting">


                         <pagersettings mode="Numeric" position="Bottom" pagebuttoncount="10"/>

                        <pagerstyle backcolor="#C6E8F5" height="20px" verticalalign="Bottom" horizontalalign="Center"/>


                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="DetailsLink" runat="server" Text="Details" ToolTip="Click to see details"><span class="glyphicon glyphicon-zoom-in"></span></asp:HyperLink>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>                                     
                                    <asp:HyperLink ID="EditLink" runat="server" Text="Edit" ToolTip="Click to edit info"><span class="glyphicon glyphicon-pencil"></span></asp:HyperLink>                                
                                </ItemTemplate>
                            </asp:TemplateField>    
                             <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>                                     
                                    <asp:HyperLink ID="DeleteLink" runat="server" Text="Delete" ToolTip="Click to delete vendor"> <span class="glyphicon glyphicon-trash"></span></asp:HyperLink>                                
                                </ItemTemplate>
                            </asp:TemplateField>                   
                                                      
                            <asp:BoundField DataField="CompanyName" HeaderText="Company"/>
                            <asp:BoundField DataField="State" HeaderText="State"/>
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"  HeaderStyle-CssClass="glyphicon glyphicon-sort" HeaderStyle-BorderColor="Transparent" />
                             <asp:BoundField DataField="UserID" HeaderText="UserID" Visible="false"/>
                           <asp:TemplateField HeaderText="Primary Email">
                            <ItemTemplate>
                          <asp:HyperLink ID="priEmail" runat="server" ToolTip="Click to send email"
                            NavigateUrl='<%# Eval("PrimaryEmail", "mailto:{0}") %>'
                            Text='<%# Eval("PrimaryEmail") %>'>
                         </asp:HyperLink>
                          </ItemTemplate>
                         </asp:TemplateField>

                        </Columns>
                         <asp:SqlDataSource ID="GridDataSource" runat="server" ConnectionString="<%$ connectionStrings:BHSCMS %>"
                        SelectCommand="Select v.UserID, v.CompanyName, v.State, s.Status, u.PrimaryEmail from BHSCMS.dbo.VendorTable v join BHSCMS.dbo.StatusTable s on v.StatusID= s.StatusID join BHSCMS.dbo.SysUserTable u on v.UserID = u.UserID" 
                        FilterExpression="Status = '{0}'">
                        <FilterParameters>
                            <asp:ControlParameter Name="Status" ControlID="ddstatusfilter" PropertyName="SelectedValue" />
                        </FilterParameters>
                    </asp:SqlDataSource>
                    </asp:GridView>
                    <asp:Button ID="btnAdd" runat="server" Text="Add New Vendor" CssClass="btn btn-info" OnClick="btnAdd_Click" />
              


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
</asp:Content>
