<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="GachaDetails.aspx.cs" Inherits="WISLEY.Views.Gacha.GachaDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
        .auto-style2 {
            text-align: center;
            width: 1145px;
        }
        .auto-style3 {
            margin-left: 266px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">

    <div id="headGaDetails">

        <br />
        <p class="auto-style1">
            <asp:Button ID="ButtonBack" CssClass="btn btn-danger" runat="server" Text="Back" OnClick="ButtonBack_Click" />
        </p>


            <p class="text-center" style="font-family:Cambria">
            <br />
            <asp:Label ID="LabelSummon" runat="server"></asp:Label>
            </p>

        <div class="auto-style2">
        <asp:GridView ID="GvSummon" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" CssClass="auto-style3" GridLines="None" OnSelectedIndexChanged="GridViewSummon_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="AvatarID" />
                <asp:BoundField HeaderText="Avatar Name" />
                <asp:BoundField HeaderText="1x Summon rate" />
                <asp:BoundField HeaderText="11 x Summon rate" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
        </div>

        <br />

    </div>


</asp:Content>
