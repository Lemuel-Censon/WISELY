<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/sidebar.master" AutoEventWireup="true" CodeBehind="quizresult.aspx.cs" Inherits="WISLEY.Views.Quiztool.quizresult" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="container">
        <div class="card">
            <div class="card-body">
                <h4 class="font-weight-bold text-center">Results</h4>
                <hr class="w-100" />
                <div class="text-center">
                    <h5 class="font-weight-bold">Your Score: <asp:Label ID="LbScore" runat="server"></asp:Label></h5>
                    <h5 class="font-weight-bold">Rewards: </h5>
                    <br />
                    <h5 class="font-weight-bold">+<asp:Label ID="LbWISPoints" runat="server"></asp:Label><img src="https://vignette.wikia.nocookie.net/brawlstars/images/e/e8/Star_Points.png/revision/latest?cb=20190827015915" class="img-fluid col-lg-1" style="width: 60px;"></h5>
                </div>
                <div class="text-right flex-fill">
                    <asp:LinkButton ID="btnBack" runat="server" OnClick="btnBack_Click" CssClass="btn btn-danger btn-sm rounded-0 mb-1">Back to Quizzes</asp:LinkButton>
                    <asp:LinkButton ID="btnRetake" runat="server" OnClick="btnRetake_Click" CssClass="btn btn-success btn-sm rounded-0 mb-1">Retake Quiz</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
