<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="quizcreator.aspx.cs" Inherits="WISLEY.Views.Quiztool.quizcreator" %>
<asp:Content ID="Content2" ContentPlaceHolderID="groupPosts" runat="server">
    <div class="container">
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <h5 class="card-title font-weight-bold mb-4 text-info">Create Quiz</h5>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbTitle" ID="LbTitle" runat="server" Text="Quiz title"></asp:Label>
                    <asp:TextBox ID="TbTitle" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbDesc" ID="LbDesc" runat="server" Text="Quiz description (Optional)"></asp:Label>
                    <asp:TextBox ID="TbDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:LinkButton ID="btnCreateQuestions" CssClass="btn btn-block btn-success text-left rounded-0 mb-1 text-center" runat="server" OnClick="btnCreateQuestions_Click"><i class="fas fa-plus mr-1"></i>Create Questions</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
