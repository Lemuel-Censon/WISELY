<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="quizstart.aspx.cs" Inherits="WISLEY.Views.Quiztool.quizcreator" %>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <h5 class="card-title mb-4">Welcome to the Quiz Creator!</h5>
                <p>The quiz creator is an interactive tool designed to motivate students into remembering their content through test. Students may take the preset quizzes or create their own quizzes and share them to their friends.</p>
                <p><asp:Label ID="LbName" runat="server" Text="Label"></asp:Label>, you have <asp:Label ID="LbNofQuiz" runat="server"></asp:Label> quiz(s). Create one now!</p>
                <div class="text-right">
                    <a class="btn btn-block btn-info text-left rounded-0 mb-1 text-center" href="quizcreator.aspx"><i class="fas fa-plus"></i>&nbsp;&nbsp;  Create Quiz </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>