<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="WISLEY.Views.Profile.settings" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="col-12 card p-2 rounded-bottom mb-4">
            <h1 class="col-12 text-center">Settings</h1>
        </div>
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <div class="md-form md-outline">
                    <div class="custom-control custom-checkbox">
                        <input type="checkbox" class="custom-control-input" id="chkboxNotification">
                        <label class="custom-control-label" for="chkboxNotification">Send notifications to my mail</label>
                    </div>
                </div>
                <div class="md-form md-outline">
                    <div class="custom-control custom-checkbox">
                        <input type="checkbox" class="custom-control-input" id="chkboxPrivacy">
                        <label class="custom-control-label" for="chkboxPrivacy">Keep my account private</label>
                    </div>
                </div>
                <div class="md-form md-outline">
                    <p>Choose your language:</p>
                    <select class="mdb-select colorful-select dropdown-primary md-form">
                        <option value="English" selected>English</option>
                        <option value="Chinese">Chinese</option>
                        <option value="Malay">Malay</option>
                        <option value="Tamil">Tamil</option>
                    </select>
                </div>
                <div class="text-right">
                    <a href="<%= Page.ResolveUrl("~/Views/Profile/profile.aspx") %>" class="btn btn-danger">Cancel</a>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save Changes" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
