<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="GachaSummon.aspx.cs" Inherits="WISLEY.Views.Gacha.GachaSummons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style1 {
            margin-left: 335px;
                margin-right: 0px;
            }
        .auto-style2 {
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">


        <div id="headGaSum">

        <br />
        <p class="auto-style2">
            <asp:Button ID="ButtonBack" CssClass="btn btn-danger" runat="server" Text="Back" OnClick="ButtonBack_Click" />
        </p>


            <p class="text-center" style="font-family:Cambria">
            <br />
            <asp:Label ID="LabelTitle" runat="server"></asp:Label>
            </p>

            <div class="text-center">
                <video width="830" height="530" controls autoplay>
                  <source id="gachavideo" src="/Public/videos/gacha_super.mp4" type="video/mp4">
                </video>
                <br />
                <br />
            <asp:Button ID="ButtonResults" CssClass="btn btn-light-green" runat="server" Text="RESULTS!" OnClick="ButtonResults_Click" autopostback="false"  />
                <br />
                <br />
            </div>

            <div id="hider" class="text-center" style="visibility:hidden" runat="server">
                <asp:Panel ID="PanelSum" runat="server" CssClass="auto-style1 text-center" Height="351px" Width="1127px" style="margin-left: 336px">
                    &nbsp;
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="144px" Width="166px" BorderColor="#9900CC" BorderStyle="Solid" BorderWidth="10px" ImageUrl="https://www.clipartwiki.com/clipimg/detail/315-3158759_clipart-dressed.png"/>
                    <asp:ImageButton ID="ImageButton6" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5-preview/2354-1553846801.png" Width="166px" />
                    <asp:ImageButton ID="ImageButton7" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5-preview/2354-1553846801.png" Width="166px" />
                    <asp:ImageButton ID="ImageButton4" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://steemitimages.com/640x0/https://chibigame.io/chibis/generated/0/3/9170981d59d0f8d3f003ef0f289394ded6a00696.png" Width="166px" />
                    <asp:ImageButton ID="ImageButton5" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://steemitimages.com/0x0/https://chibigame.io/chibis/generated/0/3/cea6475abf50000b50fe25c592e079363689f59e.png" Width="166px" />
                    <asp:ImageButton ID="ImageButton8" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5/3538-1556546438.png" Width="166px" />
                    <asp:ImageButton ID="ImageButton9" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5/3538-1556546438.png" Width="166px" />
                    <asp:ImageButton ID="ImageButton3" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://i.pinimg.com/736x/ec/67/45/ec6745ffe17cffb0e23b2f16c64100b1.jpg" Width="166px" />
                    <asp:ImageButton ID="ImageButton10" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://steemitimages.com/0x0/https://chibigame.io/chibis/generated/0/3/cea6475abf50000b50fe25c592e079363689f59e.png" Width="166px" />
                    <asp:ImageButton ID="ImageButton11" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5/920-1550012771.png" Width="166px" />
                    <asp:ImageButton ID="ImageButton12" runat="server" BorderColor="#0066CC" BorderStyle="Solid" BorderWidth="10px" Height="144px" ImageUrl="https://storage.opensea.io/0x71c118b00759b0851785642541ceb0f4ceea0bd5/920-1550012771.png" Width="166px" />
                </asp:Panel>
            </div>
        <br />

        
        
        </div>

</asp:Content>
