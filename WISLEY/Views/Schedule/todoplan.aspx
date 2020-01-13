<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="todoplan.aspx.cs" Inherits="WISLEY.todoplan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 204px;
        }
        .auto-style3 {
            height: 32px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-body">
                <h3 class="text-center font-weight-bold">Your to-do-list</h3>

                <div class="border border-primary">
                    
                    <table class="w-100">
                        <tr>
                            <td class="auto-style1 font-weight-bold">Date selected:</td>
                            <td>
                                <asp:TextBox ID="tbDateSelected" runat="server" Width="202px" CssClass="offset-sm-0" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1 font-weight-bold">Title of your to-do-list:</td>
                            <td class="auto-style3">
                                <asp:TextBox ID="tbTitle" runat="server" Width="412px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1 font-weight-bold">Description of your to-do-list:</td>
                            <td>
                                <asp:TextBox ID="tbDesc" runat="server" Height="133px" TextMode="MultiLine" Width="412px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click" Text="Add" />
                                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-danger" OnClick="btnBack_Click" Text="Back" />
                            </td>
                        </tr>
                    </table>
                    
                </div>
            </div>
        </div>
    </form>
</asp:Content>
