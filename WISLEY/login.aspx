<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WISLEY.login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" class="col-12 row justify-content-around" runat="server">
        <h3 class="font-weight-bold text-center col-12">Log In</h3>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="LbEmail" runat="server" Text="Enter your email address"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbEmail" runat="server" Width="720px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbPassword" runat="server" Text="Enter your password"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbPassword" runat="server" Width="720px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btn btn-primary p-2" ID="btnLogin" runat="server" Text="Log In" Font-Size="Large" OnClick="btnLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="recoveraccount.aspx">Forgot your password?</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="register.aspx">Don't have an account yet? Click here to register.</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
