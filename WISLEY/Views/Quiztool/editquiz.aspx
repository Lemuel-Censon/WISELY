<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="editquiz.aspx.cs" Inherits="WISLEY.Views.Quiztool.editquiz" %>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <h5 class="card-title mb-4">Quiz Id: #<asp:Label ID="LbQuizId" runat="server"></asp:Label></h5>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbTitle" ID="LbTitle" runat="server" Text="Enter quiz title"></asp:Label>
                    <asp:TextBox ID="TbTitle" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbDesc" ID="LbDesc" runat="server" Text="Enter quiz description"></asp:Label>
                    <asp:TextBox ID="TbDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="300px"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button ID="btnSaveQuiz" CssClass="btn btn-block btn-info text-left rounded-0 mb-1 text-center" runat="server" Text="Save Quiz" Onclick="btnSaveQuiz_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
