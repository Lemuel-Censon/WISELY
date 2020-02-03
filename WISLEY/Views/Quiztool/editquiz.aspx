<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="editquiz.aspx.cs" Inherits="WISLEY.Views.Quiztool.editquiz" %>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <h5 class="card-title mb-4">Quiz Id: #<asp:Label ID="LbQuizId" runat="server"></asp:Label></h5>
                <p>Number of Questions: <asp:Label ID="LbQuestionCount" runat="server"></asp:Label></p>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbTitle" ID="LbTitle" runat="server" Text="Enter quiz title"></asp:Label>
                    <asp:TextBox ID="TbTitle" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbDesc" ID="LbDesc" runat="server" Text="Enter quiz description"></asp:Label>
                    <asp:TextBox ID="TbDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="300px"></asp:TextBox>
                </div>
                <div id="questions">
                    <asp:Repeater runat="server" ID="question" OnItemCommand="question_ItemCommand" OnItemDataBound="question_ItemDataBound">
                        <ItemTemplate>
                            <div class="card-body">
                                <h5 class="card-title mb-4">Question <asp:Label ID="LbQuestionNo" runat="server" Text="1"></asp:Label></h5>
                                <div class="md-form md-outline">
                                    <asp:Label AssociatedControlID="TbQuestion" ID="LbQuestion" runat="server" Text="Enter question"></asp:Label>
                                    <asp:TextBox ID="TbQuestion" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div>
                                    <div class="md-form md-outline">
                                        <asp:Label AssociatedControlID="TbOption1" ID="LbOption1" runat="server" Text="Option 1"></asp:Label>
                                        <asp:TextBox ID="TbOption1" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="md-form md-outline">
                                        <asp:Label AssociatedControlID="TbOption2" ID="LbOption2" runat="server" Text="Option 2"></asp:Label>
                                        <asp:TextBox ID="TbOption2" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="md-form md-outline">
                                        <asp:Label AssociatedControlID="TbOption3" ID="LbOption3" runat="server" Text="Option 3"></asp:Label>
                                        <asp:TextBox ID="TbOption3" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="md-form md-outline">
                                        <asp:Label AssociatedControlID="TbOption4" ID="LbOption4" runat="server" Text="Option 4"></asp:Label>
                                        <asp:TextBox ID="TbOption4" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="md-form md-outline">
                                    <asp:Label ID="LbCorrect" runat="server" Text="Select correct answer: "></asp:Label>
                                    <asp:DropDownList ID="DdlCorrect" runat="server" OnSelectedIndexChanged="DdlCorrect_SelectedIndexChanged">
                                        <asp:ListItem Value="N/A">-- Select --</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="text-center mb-4">
                                <h4>
                                    <asp:Label runat="server" ID="LbErr" Text="Currently Empty" CssClass="font-weight-bold" Visible="false"></asp:Label>
                                </h4>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="text-right">
                    <asp:Button ID="btnaddQuestion" CssClass="btn btn-block btn-info text-left rounded-0 mb-1 text-center" runat="server" Text="+ Add Question" Onclick="btnaddQuestion_Click"/>
                    <asp:Button ID="btnSaveQuiz" CssClass="btn btn-block btn-success text-left rounded-0 mb-1 text-center" runat="server" Text="Save Quiz" Onclick="btnSaveQuiz_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
