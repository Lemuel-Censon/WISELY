<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="GachaDetails.aspx.cs" Inherits="WISLEY.Views.Gacha.GachaDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            text-align: center;
            width: 1145px;
        }
        .auto-style4 {
            margin-left: 320px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">

    <div id="headGaDetails">

        <asp:Button ID="ButtonBack" CssClass="btn btn-danger btn-sm" runat="server" Text="Back" OnClick="ButtonBack_Click" />


            <p class="text-center" style="font-family:Cambria">
            <br />
            <asp:Label ID="LabelSummon" runat="server" Font-Size="X-Large"></asp:Label>
            </p>
        <p class="text-center" style="font-family:Cambria">
                    <img id="gachadetailsbanner" src="<%=Page.ResolveUrl("~/Public/img/Gacha/banner.png") %>" />
            &nbsp;</p>
        <p class="text-center" style="font-family:Cambria">
                    &nbsp;</p>

        <div class="auto-style2">
        
            <asp:GridView ID="GvSummon2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="auto-style4" DataSourceID="Regular" Height="320px" Width="1184px" Font-Size="Larger">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="AvatarID" DataField="AvatarID" HeaderText="AvatarID" >
                    <HeaderStyle Font-Size="Larger" />
                    <ItemStyle Font-Size="Larger" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Avatar_Name" HeaderText="Avatar Name" >
                    <HeaderStyle Font-Size="Larger" />
                    <ItemStyle Font-Size="Larger" />
                    </asp:BoundField>
                    <asp:BoundField DataField="x_Summon_rate" HeaderText="1x Summon rate" >
                    <HeaderStyle Font-Size="Larger" />
                    <ItemStyle Font-Size="Larger" />
                    </asp:BoundField>
                    <asp:BoundField DataField="xx_Summon_rate" HeaderText="11x Summon rate" >
                    <HeaderStyle Font-Size="Larger" />
                    <ItemStyle Font-Size="Larger" />
                    </asp:BoundField>
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
