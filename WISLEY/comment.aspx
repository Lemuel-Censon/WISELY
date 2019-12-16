<%@ Page Title="" Language="C#" MasterPageFile="~/group.Master" AutoEventWireup="true" CodeBehind="comment.aspx.cs" Inherits="WISLEY.comment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="groupPosts" runat="server">
    <form id="form1" runat="server">
    <div class="container">
        <div class="md-form md-outline">
            <asp:Label ID="LbComment" AssociatedControlID="tbComment" runat="server" Text="Comment Content"></asp:Label>
            <asp:TextBox ID="tbComment" runat="server" Rows="6" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <asp:Label ID="LbMsg" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-lg-6 text-right">
                <a href="/collab.aspx" class="btn btn-danger">Cancel</a>
                <asp:Button ID="btnComment" runat="server" Text="Post" CssClass="btn btn-success" OnClick="btnComment_Click" />
            </div>
        </div>
    </div>
    </form>
</asp:Content>