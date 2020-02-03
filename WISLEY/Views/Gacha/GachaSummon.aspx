<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="GachaSummon.aspx.cs" Inherits="WISLEY.Views.Gacha.GachaSummons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">

    <asp:Button ID="ButtonBack" CssClass="btn btn-danger btn-sm" runat="server" Text="Back" OnClick="ButtonBack_Click" />
    <div class="text-center">
        <video controls autoplay>
            <source id="gachavideo" src="/Public/videos/gacha_common.mp4" type="video/mp4" runat="server">
        </video>
        <div class="text-center">
            <asp:Button ID="ButtonResults" CssClass="btn btn-light-green" runat="server" Text="RESULTS!" OnClick="ButtonResults_Click" autopostback="false" />
        </div>
    </div>
    <div class="row">
        <asp:Repeater runat="server" ID="gacharesults" OnItemDataBound="gacharesults_ItemDataBound" Visible="false">
            <ItemTemplate>
                <div class="col-12 col-md-3 col-lg-4 mt-4">
                    <asp:HiddenField runat="server" ID="rarity" Value='<%#Eval("rarity") %>' />
                    <div class="card w-100">
                        <div class="view overlay border-bottom border-primary rounded-top">
                            <asp:Image runat="server" ImageUrl='<%#Eval("src") %>' ID="avatarimg" CssClass="card-img-top w-100 h-100 " AlternateText="Image not Available" />
                            <a>
                                <div class="mask rgba-black-light"></div>
                            </a>
                        </div>
                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
