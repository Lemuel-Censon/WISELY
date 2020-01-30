<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="Avatar.aspx.cs" Inherits="WISLEY.Views.Gacha.Avatars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <asp:Button runat="server" ID="btnBack" CssClass="btn btn-danger btn-sm" Text="Back to profile" OnClick="ButtonBack_Click" />
            <div class="text-center">
                <asp:Repeater runat="server" ID="avatars" OnItemCommand="avatars_ItemCommand" OnItemDataBound="avatars_ItemDataBound">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="avatarimg" CommandName="upAvatar" CommandArgument='<%#Eval("src") %>' CssClass="img-fluid rounded d-block mx-auto" ImageUrl='<%#Eval("src") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="text-center mt-4">
                            <h4>
                                <asp:Label runat="server" ID="LbErr" Text="No Avatars" CssClass="font-weight-bold" Visible="false"></asp:Label>
                            </h4>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>

