<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.master" AutoEventWireup="true" CodeBehind="fileUploadTest.aspx.cs" Inherits="WISLEY.Views.Resources.fileUploadTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" runat="server">
    <h1>Hi</h1>
        <h1>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
        </h1>
        <h1>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </h1>
    </form>
</asp:Content>
