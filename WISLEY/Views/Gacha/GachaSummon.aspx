<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="GachaSummon.aspx.cs" Inherits="WISLEY.Views.Gacha.GachaSummons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">

    <div class="card">
        <div class="card-body">
            <asp:Button ID="ButtonBack" CssClass="btn btn-danger" runat="server" Text="Back" OnClick="ButtonBack_Click" />
            <div class="text-center">
                <video controls autoplay>
                    <source id="gachavideo" src="/Public/videos/gacha_common.mp4" type="video/mp4" runat="server">
                </video>
                <asp:Button ID="ButtonResults" CssClass="btn btn-light-green" runat="server" Text="RESULTS!" OnClick="ButtonResults_Click" autopostback="false" />
            </div>
            <div class="row">
                <asp:Repeater runat="server" ID="gacharesults" Visible="false">
                    <ItemTemplate>
                        <div class="col-12 col-md-3 col-lg-4 d-flex align-items-stretch mt-4">
                            <img src='<%#Eval("src") %>' class="img-fluid mx-auto rounded border" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
