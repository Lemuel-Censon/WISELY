<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="resourceUpload.aspx.cs" Inherits="WISLEY.Views.Resources.resourceUpload" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="col-10 border border-danger">
        <asp:FileUpload ID="FileUploadControl" runat="server" />
        <asp:Button runat="server" ID="UploadButton" Text="Upload" />
    </div>
</asp:Content>
