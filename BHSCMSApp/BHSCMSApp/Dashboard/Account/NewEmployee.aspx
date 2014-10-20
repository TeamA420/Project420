<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardAdmin.Master" AutoEventWireup="true" CodeBehind="NewEmployee.aspx.cs" Inherits="BHSCMSApp.Dashboard.Register.NewEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
                                <tr>
                                    <td>EmpID: 
                              <asp:TextBox ID="txtEmpID" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>                                

                                 <tr>
                                    <td>Role : 
                                        <asp:DropDownList ID="ddrole" runat="server" CssClass="form-control" Width="15%">
                                            <asp:ListItem>Admin</asp:ListItem>
                                            <asp:ListItem>Employee</asp:ListItem>
                                        </asp:DropDownList>                                
                                    </td>
                                </tr>
                              <tr>
                                    <td>Last Name : 
                                <asp:TextBox ID="txtLast" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>First Name : 
                                <asp:TextBox ID="txtFirst" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr> 
                                   
                               <tr>
                                    <td>Username : 
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Password : 
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Primary Email:
                                <asp:TextBox ID="txtPriEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Secondary Email:
                                <asp:TextBox ID="txtSecEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                <asp:Button ID="btnAdd" runat="server" Text="Submit" CssClass="btn btn-info" OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                                           
                            </table>
                       <br />
    <br />
</asp:Content>
