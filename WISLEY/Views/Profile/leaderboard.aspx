<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="leaderboard.aspx.cs" Inherits="WISLEY.leaderboard" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" class="col-12 row justify-content-around" runat="server">
        <h3 class="font-weight-bold text-center col-12">Leaderboard</h3>
        <div>
            <table border="1" style="width: 500px; text-align: center; height: 300px; font-family: Verdana;">
                <tr>
                    <td style="background-color: gray;"><strong>#</strong></td>
                    <td style="background-color: gray;"><strong>Name</strong></td>
                    <td style="background-color: gray;"><strong>Experience Level</strong></td>
                    <td style="background-color: gray;"><strong>WIS Points</strong></td>
                </tr>
                <tr>
                    <td style="background-color: gold;">1</td>
                    <td>Bill Cipher</td>
                    <td>100</td>
                    <td>1000000</td>
                </tr>
                <tr>
                    <td style="background-color: silver;">2</td>
                    <td>Dipper</td>
                    <td>99</td>
                    <td>900000</td>
                </tr>
                <tr>
                    <td style="background-color: brown;">3</td>
                    <td>Mabel</td>
                    <td>99</td>
                    <td>890000</td>
                </tr>
                <tr>
                    <td>4</td>
                    <td>Stan</td>
                    <td>98</td>
                    <td>850000</td>
                </tr>
                <tr>
                    <td>5</td>
                    <td>Soos</td>
                    <td>98</td>
                    <td>840000</td>
                </tr>
                <tr>
                    <td style="background-color: blue;">9001</td>
                    <td>Bryan</td>
                    <td>1</td>
                    <td>420</td>
                </tr>
            </table>
            <table>
                <tr>
                    <td><asp:Button CssClass="btn btn-primary p-2" ID="Refresh" runat="server" Text="Refresh" /></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
