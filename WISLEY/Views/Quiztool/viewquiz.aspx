<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/sidebar.master" AutoEventWireup="true" CodeBehind="viewquiz.aspx.cs" Inherits="WISLEY.Views.Quiztool.viewquiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="container">
        <div class="card">
            <div class="card-body m-3">
                <asp:HiddenField runat="server" ID="LbQuizID" />
                <h4 class="font-weight-bold card-title"><%=quiz().title %></h4>
                <div class="row">
                    <div class="col-lg-6">
                        <%=quiz().description %>
                    </div>
                    <div class="col-lg-6 text-right">
                        Total Questions: <%=quiz().totalquestions %>
                    </div>
                </div>
                <hr class="w-100" />
                <div id="questions">
                    <asp:Repeater runat="server" ID="questionitems">
                        <ItemTemplate>
                            <div class="mt-3">
                                <h5 class="card-title mb-4 font-weight-bold">Question <%#Eval("number") %></h5>
                                <asp:Label runat="server" ID="question" Text='<%#Eval("question") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
