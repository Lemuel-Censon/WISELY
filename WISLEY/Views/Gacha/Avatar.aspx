<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="Avatar.aspx.cs" Inherits="WISLEY.Views.Gacha.Avatars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 1056px;
            height: 485px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">


    <div id="headAv">

        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonBack" CssClass="btn btn-danger" runat="server" Text="Back" OnClick="ButtonBack_Click" />
        <br />

        <h4 class="text-center mx-auto font-weight-bold" style="font-size: 40px; font-family:Arial;">YOUR AVATAR LIST</h4>

        </br>
        </br>

    </div>

    <div id="bodyAv" class="text-center">
        
        <asp:ImageButton ID="ImageButton1" runat="server" Height="144px" Width="166px" BorderColor="#9900CC" BorderStyle="Solid" BorderWidth="10px" ImageUrl="https://www.clipartwiki.com/clipimg/detail/315-3158759_clipart-dressed.png" OnClick="ImageButton1_Click"/>
&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" Height="144px" Width="166px" BorderColor="#00CC66" BorderStyle="Solid" BorderWidth="10px" ImageUrl="https://i.ya-webdesign.com/images/baymax-transparent-head-2.png" OnClick="ImageButton2_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton3" runat="server" Height="144px" Width="166px" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" ImageUrl="https://i.pinimg.com/736x/ec/67/45/ec6745ffe17cffb0e23b2f16c64100b1.jpg" OnClick="ImageButton3_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton4" runat="server" Height="144px" Width="166px" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" ImageUrl="https://steemitimages.com/640x0/https://chibigame.io/chibis/generated/0/3/9170981d59d0f8d3f003ef0f289394ded6a00696.png" OnClick="ImageButton4_Click" />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton5" runat="server" Height="144px" Width="166px" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" ImageUrl="https://steemitimages.com/0x0/https://chibigame.io/chibis/generated/0/3/cea6475abf50000b50fe25c592e079363689f59e.png" OnClick="ImageButton5_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton6" runat="server" Height="144px" Width="166px" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" ImageUrl="https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5-preview/2354-1553846801.png" OnClick="ImageButton6_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton7" runat="server" Height="144px" Width="166px" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" ImageUrl="https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5/920-1550012771.png" OnClick="ImageButton7_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton8" runat="server" Height="144px" Width="166px" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" ImageUrl="https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5/3538-1556546438.png" OnClick="ImageButton8_Click" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownListSort" runat="server" BackColor="Black" Font-Names="Arial Black" ForeColor="White" OnSelectedIndexChanged="DropDownListSort_SelectedIndexChanged">
            <asp:ListItem Value="-1">Sort</asp:ListItem>
            <asp:ListItem>Rarity</asp:ListItem>
            <asp:ListItem>Recent</asp:ListItem>
        </asp:DropDownList>
&nbsp;
        <asp:Button ID="ButtonSelect" runat="server" Text="Select" CssClass="btn btn-unique" OnClick="ButtonSelect_Click"/>


    </div>

    <br />

    <br />
</asp:Content>

