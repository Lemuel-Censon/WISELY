<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="WISLEY.recoveraccount" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <h5 class="card-title mb-4">Enter your email address</h5>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbEmail" ID="LbEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="TbEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button CssClass="btn btn-md btn-danger" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    <asp:Button CssClass="btn btn-md btn-success" ID="btnRecoverAccount" runat="server" Text="Next" OnClick="btnRecoverAccount_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
