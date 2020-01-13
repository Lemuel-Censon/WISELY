<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="editprofile.aspx.cs" Inherits="WISLEY.editprofile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="col-12 card p-2 rounded-bottom mb-4">
            <h1 class="col-12 text-center">Edit Profile </h1>
        </div>
        <div class="col-lg-12">
            <div class="card z-depth-2 pt-2 mb-5">
                <div class="card-body">
                    <asp:Label runat="server" ID="LbEmail" Visible="false"></asp:Label>
                    <h4 class="card-title">Personal Information</h4>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="tbName" ID="LbName" runat="server" Text="Full Name"></asp:Label>
                        <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="tbDOB" ID="LbDOB" runat="server" Text="Date of Birth"></asp:Label>
                        <asp:TextBox ID="tbDOB" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="tbContact" ID="Lbcontact" runat="server" Text="Contact"></asp:Label>
                        <asp:TextBox ID="tbContact" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                    </div>
                    <div class="text-right">
                        <a href="<%= Page.ResolveUrl("~/Views/Profile/profile.aspx") %>" class="btn btn-danger">Cancel</a>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save Changes" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
