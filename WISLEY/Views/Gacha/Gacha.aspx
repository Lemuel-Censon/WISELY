<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="Gacha.aspx.cs" Inherits="WISLEY.Views.Gacha.Gachas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <asp:Button ID="ButtonBack" CssClass="btn btn-danger btn-sm" runat="server" Text="Back" OnClick="ButtonBack_Click" />
            <div class="mb-4">
                <h4 class="text-center mx-auto" style="font-family: Cambria">G A C H A S</h4>
                <p class="text-center mx-auto" style="font-family: Cambria">&nbsp;</p>
                <img src="<%=Page.ResolveUrl("~/Public/img/Gacha/banner.png") %>" alt="Gacha banner" class="img-fluid d-block mx-auto" />
                <div class="text-center mt-3">
                    <asp:Button ID="Button1x_R" runat="server" Text="1x ( 1000 WIS )" CssClass="btn btn-blue rounded btn-lg" OnClick="Button1x_R_Click" />
                    <asp:Button ID="Button11x_R" runat="server" Text="11x ( 10000 WIS )" CssClass="btn btn-purple rounded btn-lg" OnClick="Button11x_R_Click" />
                    <asp:Button ID="ButtonI_R0" runat="server" Text="ⓘ" CssClass="btn btn-blue-grey rounded" OnClick="ButtonI_R" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
