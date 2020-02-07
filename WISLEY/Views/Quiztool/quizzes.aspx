<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.master" AutoEventWireup="true" CodeBehind="quizzes.aspx.cs" Inherits="WISLEY.Views.Quiztool.quizzes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="groupPosts" runat="server">
    <div class="container">
        <div class="card">
            <div class="card-body">
                <h4 class="font-weight-bold text-center">Quizzes</h4>
                <hr class="w-100" />
                <div class="text-right">
                    <asp:LinkButton runat="server" ID="btnCreate" CssClass="btn btn-info btn-sm" OnClick="btnCreate_Click"><i class="fas fa-plus mr-1"></i>Create Quiz</asp:LinkButton>
                </div>
                <div class="row">
                    <asp:Repeater runat="server" ID="quizinfo" OnItemCommand="quizinfo_ItemCommand" OnItemDataBound="quizinfo_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-12 col-md-6 col-lg-6 d-flex align-items-stretch mt-4">
                                <div class="card w-100">
                                    <div class="card-body d-flex flex-column">

                                        <div class="d-flex">
                                            <div class="flex-fill">
                                                <h4 class="card-title mb-0"><%#Eval("title") %></h4>
                                            </div>
                                        </div>

                                        <div class="d-flex mt-2">
                                            <div class="flex-fill">
                                                <img src='<%#Eval("profilesrc") %>' onerror="this.src='<%=Page.ResolveUrl("~/Public/img/default.jpg") %>'" class="rounded-circle img-fluid z-depth-1" style="max-width: 2rem;">
                                                <asp:LinkButton runat="server" ID="btnviewprof" CssClass="align-middle ml-1" CommandName="viewprofile" CommandArgument='<%#Eval("userId") %>'><%#Eval("username") %></asp:LinkButton>
                                            </div>

                                            <div class="d-flex align-items-center">
                                                <span class="text-muted small">
                                                    <i class="far fa-clock mr-2"></i><%#Eval("datecreated") %>
                                                </span>
                                            </div>
                                        </div>

                                        <hr class="w-100" />
                                        <div class="flex-fill">
                                            <p class="card-text"><%#Eval("description") %></p>
                                        </div>
                                    </div>
                                    <div class="card-footer text-center">
                                        <asp:LinkButton runat="server" ID="btnView" CommandName="viewquiz" CommandArgument='<%#Eval("Id") %>' CssClass="btn btn-success btn-sm">Take Quiz</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="mb-4 text-center">
                                <h4>
                                    <asp:Label runat="server" ID="LbErr" Text="No Quizzes" CssClass="font-weight-bold" Visible="false"></asp:Label>
                                </h4>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
