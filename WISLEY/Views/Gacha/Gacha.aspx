<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="Gacha.aspx.cs" Inherits="WISLEY.Views.Gacha.Gachas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    
    <form id="form1" runat="server">

<div id="headGa">

    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonBack" CssClass="btn btn-blue-grey" runat="server" Text="Back" OnClick="ButtonBack_Click" />
        <br />

    <br />
    <h4 class="text-center mx-auto" style="font-family:Cambria">G A C H A S</h4>
    <br />

    

</div>
        <div id="bodyGa" class="text-center">
        <iframe src="//cdn.bannersnack.com/banners/bdpl499mz/embed/index.html?userId=40214613&t=1575957949" width="820" height="244" scrolling="no" frameborder="0" allowtransparency="true" allow="autoplay" allowfullscreen="true"></iframe>
            <br />
            <asp:Button ID="Button1x_F" runat="server" Text="1x ( 1000 WIS )" CssClass="btn btn-blue rounded" OnClick="Button1x_F_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button11x_F" runat="server" Text="11x ( 10000 WIS )" CssClass="btn btn-purple rounded" OnClick="Button11x_F_Click" />
            <br />
            <br />
        <iframe src="//cdn.bannersnack.com/banners/bxh82nnjd/embed/index.html?userId=40214613&t=1575958709" width="820" height="244" scrolling="no" frameborder="0" allowtransparency="true" allow="autoplay" allowfullscreen="true"></iframe>
            <br />
            <asp:Button ID="Button1x_R" runat="server" Text="1x ( 1000 WIS )" CssClass="btn btn-blue rounded" OnClick="Button1x_R_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button11x_R" runat="server" Text="11x ( 10000 WIS )" CssClass="btn btn-purple rounded" OnClick="Button11x_R_Click" />
            <br />
            <br />
        </div>
    </form>

</asp:Content>
