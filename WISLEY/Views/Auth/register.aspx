<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WISLEY.register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">

    <div class="container">
        <form id="form1" class="text-center" runat="server">
            <div class="card z-depth-3 pb-0 px-0">
                <div class="card-body px-5">
                    <h5 class="card-title text-center mb-4">Register an Account</h5>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbEmail" ID="LbEmail" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="TbEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbName" ID="LbName" runat="server" Text="Full Name"></asp:Label>
                        <asp:TextBox ID="TbName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbPassword" ID="LbPassword" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="TbPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbConfirmPassword" ID="LbConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                        <asp:TextBox ID="TbConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <p>Get started as a...</p>
                    <asp:Panel runat="server" ID="typepanel" HorizontalAlign="Center">
                        <asp:RadioButtonList runat="server" ID="typelist" RepeatDirection="Horizontal" align="center">
                            <asp:ListItem>Student</asp:ListItem>
                            <asp:ListItem>Teacher</asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                    <div class="mt-3">
                        <button class="btn btn-md btn-block btn-primary" id="btnRegister" runat="server" onserverclick="btnRegister_Click">Join</button>
                    </div>
                    <div class="card-footer">
                        <p class="text-center small m-0">
                            Already a member? <a href="<%= Page.ResolveUrl("~/Views/Auth/login.aspx") %>">Sign in</a>
                        </p>
                    </div>
                </div>
            </div>
        </form>
    </div>

</asp:Content>
