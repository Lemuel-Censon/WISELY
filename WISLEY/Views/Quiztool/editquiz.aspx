<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/sidebar.Master" AutoEventWireup="true" CodeBehind="editquiz.aspx.cs" Inherits="WISLEY.Views.Quiztool.editquiz" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="container">
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <asp:HiddenField runat="server" ID="LbQuizID" />
                <h4 class="card-title font-weight-bold mb-4 text-info">Edit Quiz
                </h4>
                <div class="md-form md-outline">
                    <asp:Label runat="server" ID="LbTitle" AssociatedControlID="TbTitle" Text="Quiz Title"></asp:Label>
                    <asp:TextBox runat="server" ID="TbTitle" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="md-form md-outline">
                    <asp:Label runat="server" ID="LbDesc" AssociatedControlID="TbDesc" Text="Quiz Description (Optional)"></asp:Label>
                    <asp:TextBox runat="server" ID="TbDesc" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                </div>
                <p>
                    No. of Questions:
                    <asp:Label runat="server" ID="LbQuestionCount"></asp:Label>
                </p>
                <div id="questions">
                    <asp:ScriptManager runat="server" ID="qnScript"></asp:ScriptManager>
                    <asp:UpdatePanel runat="server" ID="qnupdate">
                        <ContentTemplate>
                            <asp:Repeater runat="server" ID="question" OnItemCommand="question_ItemCommand" OnItemDataBound="question_ItemDataBound">
                                <ItemTemplate>
                                    <div>
                                        <h5 class="card-title mb-4">Question <%#Eval("number") %></h5>
                                        <div class="md-form md-outline">
                                            <asp:Label AssociatedControlID="TbQuestion" ID="LbQuestion" runat="server" Text="Question"></asp:Label>
                                            <asp:TextBox ID="TbQuestion" runat="server" CssClass="form-control" Text='<%#Eval("question") %>'></asp:TextBox>
                                        </div>
                                        <div>
                                            <div class="md-form md-outline">
                                                <asp:Label AssociatedControlID="TbOption1" ID="LbOption1" runat="server" Text="Option 1"></asp:Label>
                                                <asp:TextBox ID="TbOption1" runat="server" CssClass="form-control w-75" Text='<%#Eval("option1") %>'></asp:TextBox>
                                            </div>
                                            <div class="md-form md-outline">
                                                <asp:Label AssociatedControlID="TbOption2" ID="LbOption2" runat="server" Text="Option 2"></asp:Label>
                                                <asp:TextBox ID="TbOption2" runat="server" CssClass="form-control w-75" Text='<%#Eval("option2") %>'></asp:TextBox>
                                            </div>
                                            <div class="md-form md-outline">
                                                <asp:Label AssociatedControlID="TbOption3" ID="LbOption3" runat="server" Text="Option 3"></asp:Label>
                                                <asp:TextBox ID="TbOption3" runat="server" CssClass="form-control w-75" Text='<%#Eval("option3") %>'></asp:TextBox>
                                            </div>
                                            <div class="md-form md-outline">
                                                <asp:Label AssociatedControlID="TbOption4" ID="LbOption4" runat="server" Text="Option 4"></asp:Label>
                                                <asp:TextBox ID="TbOption4" runat="server" CssClass="form-control w-75" Text='<%#Eval("option4") %>'></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="md-form md-outline">
                                            <asp:Label ID="LbCorrect" runat="server" Text="Select correct answer: "></asp:Label>
                                            <asp:DropDownList ID="DdlCorrect" runat="server">
                                                <asp:ListItem Value="N/A">-- Select --</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="text-right">
                                            <asp:LinkButton runat="server" ID="btnSaveQn" CommandName="saveqn" CommandArgument='<%#Eval("number") %>' CssClass="btn btn-success btn-sm">Save Question</asp:LinkButton>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="text-center mb-4">
                                        <h4>
                                            <asp:Label runat="server" ID="LbErr" Text="No Questions" CssClass="font-weight-bold" Visible="false"></asp:Label>
                                        </h4>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="text-right">
                                <asp:LinkButton ID="btnaddQuestion" CssClass="btn btn-info btn-sm rounded-0 mb-1" runat="server" OnClick="btnaddQuestion_Click"><i class="fas fa-plus mr-1"></i>Add Question</asp:LinkButton>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="text-right">
                    <asp:LinkButton ID="btnSaveQuiz" CssClass="btn btn-success btn-sm rounded-0 mb-1" runat="server" OnClick="btnSaveQuiz_Click">Save Quiz</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
