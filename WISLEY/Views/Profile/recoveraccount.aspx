<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="recoveraccount.aspx.cs" Inherits="WISLEY.recoveraccount" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" class="col-12 row justify-content-around" runat="server">
        <h3 class="font-weight-bold text-center col-12">Recover Account</h3>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="LbEmail" runat="server" Text="Enter your email address"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="720px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btn btn-primary p-2" ID="btnRecoverAccount" runat="server" Text="Next" Font-Size="Large" OnClick="btnRecoverAccount_Click" />
                        <asp:Button CssClass="btn btn-danger p-2" ID="btnCancel" runat="server" Text="Cancel" Font-Size="Large" OnClick="btnCancel_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
