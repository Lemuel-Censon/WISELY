<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="recoveraccount.aspx.cs" Inherits="WISLEY.recoveraccount" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <form id="form1" class="text-center" runat="server">    
            <div class="card z-depth-3 pb-0 px-0">
                <div class="card-body px-5">
                    <h5 class="card-title mb-4">Recover Account</h5>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbEmail" ID="LbEmail" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="TbEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:Button CssClass="btn btn-md btn-danger" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                        </div>
                        <div class="col-lg-6">
                            <asp:Button CssClass="btn btn-md btn-success" ID="btnRecoverAccount" runat="server" Text="Next" OnClick="btnRecoverAccount_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
