<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="verifyaccount.aspx.cs" Inherits="WISLEY.verifyaccount" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <h5 class="card-title mb-4">Verify your email</h5>
                <div>
                    <p>
                        An email has been sent to
                            <asp:Label ID="LbEmail" runat="server" Text="Label"></asp:Label>. Please enter the validation code that has been sent to your email. Validation code will expire in 5 minutes.
                    </p>
                </div>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbCode" ID="LbCode" runat="server" Text="Validation code"></asp:Label>
                    <asp:TextBox ID="TbCode" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button CssClass="btn btn-danger p-2" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                    <asp:Button CssClass="btn btn-primary p-2" ID="btnVerifyAccount" runat="server" Text="Next" OnClick="btnVerifyAccount_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
