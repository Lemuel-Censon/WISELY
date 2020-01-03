<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="editprofile.aspx.cs" Inherits="WISLEY.editprofile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="col-12 card p-2 rounded-bottom mb-4">
            <h1 class="col-12 text-center">Edit Profile </h1>
        </div>
        <form id="form1" class="justify-content-around" runat="server">
            <div class="col-lg-12">
                <div class="card z-depth-2 pt-2 mb-5">
                    <div class="card-body">
                        <h4 class="card-title">Personal Information</h4>
                        <div class="md-form md-outline">
                            <asp:Label AssociatedControlID="tbEmail" ID="LbUsername" runat="server" Text="Email"></asp:Label>
                            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="md-form md-outline">
                                    <asp:Label AssociatedControlID="tbFname" ID="Lbfname" runat="server" Text="First Name"></asp:Label>
                                    <asp:TextBox ID="tbFname" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="md-form md-outline">
                                    <asp:Label AssociatedControlID="tbLname" ID="Lblname" runat="server" Text="Last Name"></asp:Label>
                                    <asp:TextBox ID="tbLname" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="md-form md-outline">
                            <asp:Label AssociatedControlID="tbDOB" ID="LbDOB" runat="server" Text="Date of Birth"></asp:Label>
                            <asp:TextBox ID="tbDOB" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="md-form md-outline">
                            <asp:Label AssociatedControlID="tbLocation" ID="Lblocation" runat="server" Text="Location"></asp:Label>
                            <asp:TextBox ID="tbLocation" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="md-form md-outline">
                            <asp:Label AssociatedControlID="tbContact" ID="Lbcontact" runat="server" Text="Contact"></asp:Label>
                            <asp:TextBox ID="tbContact" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
