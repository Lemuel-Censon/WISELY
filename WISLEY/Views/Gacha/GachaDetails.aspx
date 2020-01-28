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
            margin-left: 344px;
        }
        .auto-style4 {
            margin-left: 349px;
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
        <p class="text-center" style="font-family:Cambria">
                    <iframe id="gachadetailsbanner" width="820" height="244" scrolling="no" frameborder="0" allowtransparency="true" allow="autoplay" allowfullscreen="true" runat="server"></iframe>
            &nbsp;</p>
        <p class="text-center" style="font-family:Cambria">
                    &nbsp;</p>

        <div class="auto-style2">
        <asp:GridView ID="GvSummon" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" CssClass="auto-style3" GridLines="None" OnSelectedIndexChanged="Page_Load" DataSourceID="Featured" Height="416px" Width="1191px"  >
            <Columns>
                <asp:BoundField HeaderText="AvatarID" DataField="AvatarID" />
                <asp:BoundField HeaderText="Avatar Name" DataField="Avatar_Name" />
                <asp:BoundField HeaderText="1x Summon rate" DataField="x_Summon_rate" />
                <asp:BoundField HeaderText="11 x Summon rate" DataField="xx_Summon_rate" />
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
            <asp:GridView ID="GvSummon2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="auto-style4" DataSourceID="Regular" Height="320px" Width="1184px">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="AvatarID" DataField="AvatarID" HeaderText="AvatarID" />
                    <asp:BoundField DataField="Avatar_Name" HeaderText="Avatar Name" />
                    <asp:BoundField DataField="x_Summon_rate" HeaderText="1x Summon rate" />
                    <asp:BoundField DataField="xx_Summon_rate" HeaderText="11x Summon rate" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="Regular" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [AvatarID], [Avatar_Name], [x_Summon_rate], [xx_Summon_rate] FROM [regular]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="Featured" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [AvatarID], [Avatar_Name], [x_Summon_rate], [xx_Summon_rate] FROM [Featured]"></asp:SqlDataSource>
        </div>

        <br />

    </div>


</asp:Content>
