<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="verifyaccount.aspx.cs" Inherits="WISLEY.verifyaccount" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" class="col-12 row justify-content-around" runat="server">
        <h3 class="font-weight-bold text-center col-12">Verify your email</h3>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <p>An email has been sent to abc@gmail.com.</p>
                        <p>Please enter the validation code that has been sent to your email.</p>
                        <p>Validation code will expire in <span class="timer">5:00</span></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LbCode" runat="server" Text="Enter validation code"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="720px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="btn btn-primary p-2" ID="btnVerifyAccount" runat="server" Text="Next" Font-Size="Large" OnClick="btnVerifyAccount_Click" />
                        <asp:Button CssClass="btn btn-danger p-2" ID="btnBack" runat="server" Text="Back" Font-Size="Large" OnClick="btnBack_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
