<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WISLEY.register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" class="col-12 row justify-content-around" runat="server">
        <h3 class="font-weight-bold text-center col-12">Create an Account</h3>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="LbUsername" runat="server" Text="Username"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbUsername" runat="server" Width="720px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbEmail" runat="server" Text="Email Address"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbEmail" runat="server" Width="720px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbNewPassword" runat="server" Text="New Password"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbNewPassword" runat="server" Width="720px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbConfirmPassword" runat="server" Width="720px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbUserType" runat="server" Text="What are you?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Vertical">
                            <asp:ListItem>Student</asp:ListItem>
                            <asp:ListItem>Teacher</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btn btn-primary p-2" ID="btnRegister" runat="server" Text="Create Account" Font-Size="Large" OnClick="btnRegister_Click"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="login.aspx">Already have an account? Click here to log in.</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
