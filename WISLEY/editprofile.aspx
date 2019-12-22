<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="editprofile.aspx.cs" Inherits="WISLEY.editprofile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" class="col-12 row justify-content-around" runat="server">
        <h3 class="font-weight-bold text-center col-12">Edit Profile</h3>
        <div class="card col-12 p-1">

            <table style="width: 100%;">
                <tr>
                    <td class="auto-style4">
                        <h4 class="font-weight-bold">Personal Information</h4>
                    </td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <h4 class="font-weight-bold">Settings</h4>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LbUsername" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <asp:CheckBox ID="chkBoxNotification" runat="server" Text="Send notifications to my mail" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="tbUsername" runat="server" Width="280px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                    </td>
                    <td class="auto-style3">
                        <asp:CheckBox ID="chkBoxPrivacy" runat="server" Text="Keep my account private" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LbFName" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="LbLName" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LbLanguage" runat="server" Text="Language:"></asp:Label>&nbsp;          
                        <asp:DropDownList ID="ddlLanguage" runat="server" Width="280px">
                            <asp:ListItem Value="English">English</asp:ListItem>
                            <asp:ListItem Value="Chinese">Chinese</asp:ListItem>
                            <asp:ListItem>Malay</asp:ListItem>
                            <asp:ListItem>Tamil</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="tbFName" runat="server" Width="280px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tbLName" runat="server" Width="280px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LbEmail" runat="server" Text="Email Address"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <asp:Button CssClass="btn btn-success p-2 ml-auto" ID="btnchangePassword" runat="server" Text="Change Password"/>
                        <asp:Button CssClass="btn btn-primary p-2 ml-auto" ID="btnsaveProfile" runat="server" Text="Save Profile" />
                        <asp:Button CssClass="btn btn-danger p-2 ml-auto" ID="btncancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="tbEmail" runat="server" Width="280px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LbBirthDate" runat="server" Text="Date of Birth"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="LbGender" runat="server" Text="Gender"></asp:Label>
                    </td>
                    <td class="auto-style3"></td>
                </tr>                
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="tbBirthDate" runat="server" Width="280px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlGender" runat="server" Width="280px">
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>                             
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LbLocation" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>                
                <tr>
                    <td class="auto-style4"><asp:TextBox ID="tbLocation" runat="server" Width="280px"></asp:TextBox></td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LbContactNo" runat="server" Text="Contact No."></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4"><asp:TextBox ID="tbContactNo" runat="server" Width="280px"></asp:TextBox></td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 344px;
        }
        .auto-style2 {
            width: 344px;
            height: 38px;
        }
        .auto-style3 {
            height: 38px;
        }
        .auto-style4 {
            width: 334px;
        }
    </style>
</asp:Content>
