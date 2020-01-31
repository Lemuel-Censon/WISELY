<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="Avatar.aspx.cs" Inherits="WISLEY.Views.Gacha.Avatars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <asp:Button runat="server" ID="btnBack" CssClass="btn btn-danger btn-sm" Text="Back to profile" OnClick="ButtonBack_Click" />
            <div class="row">
                <asp:Repeater runat="server" ID="avatars" OnItemCommand="avatars_ItemCommand" OnItemDataBound="avatars_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-12 col-md-3 col-lg-4 d-flex align-items-stretch mt-4">
                            <asp:HiddenField runat="server" ID="avatarrarity" Value='<%#Eval("rarity") %>' />
                            <div class="card w-100">
                                <div class="view overlay border-bottom border-primary rounded-top">
                                    <asp:Image runat="server" ID="avatarimg" ImageUrl='<%#Eval("src") %>' AlternateText="Image not Available" />
                                    <a>
                                        <div class="mask rgba-black-light"></div>
                                    </a>
                                </div>
                                <div class="text-center flex-fill">
                                    <asp:LinkButton runat="server" ID="changeav" CssClass="btn btn-success btn-sm" Text="Select" CommandName="upAvatar" CommandArgument='<%#Eval("src") %>'></asp:LinkButton>
                                </div>
                            </div>
                        </div>
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

