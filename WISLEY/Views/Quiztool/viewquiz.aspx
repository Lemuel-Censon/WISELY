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
                    <asp:Repeater runat="server" ID="questionitems" OnItemDataBound="questionitems_ItemDataBound" OnItemCommand="questionitems_ItemCommand">
                        <ItemTemplate>
                            <div class="mt-3">
                                <h5 class="card-title mb-4 font-weight-bold">Question <%#Eval("number") %></h5>
                                <asp:Label runat="server" ID="question" Text='<%#Eval("question") %>'></asp:Label>
<%--                                <asp:RadioButtonList ID="rbtnOptions" runat="server" RepeatDirection="Vertical">
                                    <asp:ListItem Text='<%#Eval("option1") %>'></asp:ListItem>
                                    <asp:ListItem Text='<%#Eval("option2") %>'></asp:ListItem>
                                    <asp:ListItem Text='<%#Eval("option3") %>'></asp:ListItem>
                                    <asp:ListItem Text='<%#Eval("option4") %>'></asp:ListItem>
                                </asp:RadioButtonList>--%>
                                <ul class="list-unstyled">
                                    <li><asp:RadioButton ID="rbtnOption1" GroupName='<%#Eval("number") %>' runat="server" Text=' <%#Eval("option1") %>'/></li>
                                    <li><asp:RadioButton ID="rbtnOption2" GroupName='<%#Eval("number") %>' runat="server" Text=' <%#Eval("option2") %>'/></li>
                                    <li><asp:RadioButton ID="rbtnOption3" GroupName='<%#Eval("number") %>' runat="server" Text=' <%#Eval("option3") %>'/></li>
                                    <li><asp:RadioButton ID="rbtnOption4" GroupName='<%#Eval("number") %>' runat="server" Text=' <%#Eval("option4") %>'/></li>
                                    <li><asp:Label ID="Label1" runat="server" Visible="false" Text='<%#Eval("answer") %>'></asp:Label></li>
                                </ul>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="text-right">
                                <asp:LinkButton ID="btnSubmit" CssClass="btn btn-success btn-sm rounded-0 mb-1" runat="server" CommandName="submit">Submit</asp:LinkButton>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
