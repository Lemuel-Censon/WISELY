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
                        <asp:Label AssociatedControlID="TbPassword" ID="LbPassword" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="TbPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbConfirmPassword" ID="LbConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                        <asp:TextBox ID="TbConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <p>Get started as a...</p>
                    <div class="custom-control custom-radio custom-control-inline">
                        <input type="radio" runat="server" class="custom-control-input" id="rbtnStud" />
                        <label class="custom-control-label" for="rbtnStud">Student</label>
                    </div>
                    <div class="custom-control custom-radio custom-control-inline">
                        <input type="radio" runat="server" class="custom-control-input" id="rbtnTeach" />
                        <label class="custom-control-label" for="rbtnTeach">Teacher</label>
                    </div>
                    <div class="mt-3">
                        <button class="btn btn-md btn-block btn-primary" id="btnRegister" runat="server" onserverclick="btnRegister_Click">Join</button>
                    </div>
                    <div class="card-footer">
                        <p class="text-center small m-0">
                            Already a member? <a href="login.aspx">Sign in</a>
                        </p>
                    </div>
                </div>
            </div>
        </form>
    </div>

</asp:Content>
