<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="collab.aspx.cs" Inherits="WISLEY.collab" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="font-weight-bold text-center">Collaboration Board</h3>
    <form id="comment" runat="server" class="border">
    <div class="card">
        <div class="card-body">
            <label for="tbtitle">Post title: </label>
            <asp:TextBox ID="tbtitle" runat="server" CssClass="form-control"></asp:TextBox>
            &nbsp;<hr />
            <label for="tbcontent">Description: </label>
            <asp:TextBox ID="tbcontent" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="6"></asp:TextBox>
            <div class="row justify-content-end">
                <asp:Button CssClass="btn btn-success ml-auto" ID="btnpost" runat="server" Text="Post" OnClick="btnpost_Click"/>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
