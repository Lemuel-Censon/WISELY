<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WISLEY.login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <form id="form1" class="text-center" runat="server">
            <div class="card z-depth-3 pb-0 px-0">
                <div class="card-body px-5">
                    <h5 class="card-title text-center mb-4">Login</h5>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbEmail" ID="LbEmail" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="TbEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbPassword" ID="LbPassword" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="TbPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div>
                        <button class="btn btn-md btn-block btn-primary" id="btnLogin" runat="server" onserverclick="btnLogin_Click">Login</button>
                    </div>
                    <div class="card-footer">
                        <p class="small m-0">
                            <a href="<%= Page.ResolveUrl("~/Views/Profile/recoveraccount.aspx") %>">Forgot your password?</a>
                        </p>
                        <p class="text-center small m-0">
                            Don't have an account yet? <a href="<%= Page.ResolveUrl("~/Views/Auth/register.aspx") %>">Click here to register.</a>
                        </p>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
