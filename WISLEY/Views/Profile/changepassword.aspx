<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="WISLEY.changepassword" %>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" class="col-12 row justify-content-around" runat="server">
        <h3 class="font-weight-bold text-center col-12">Change Password</h3>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="LbCurrentPassword" runat="server" Text="Enter your current password"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbCurrentPassword" runat="server" Width="720px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbNewPassword" runat="server" Text="Enter a new password"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbNewPassword" runat="server" Width="720px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbConfirmPassword" runat="server" Text="Confirm your new password"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbConfirmPassword" runat="server" Width="720px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btn btn-success" ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click"/>
                        <asp:Button CssClass="btn btn-danger" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
