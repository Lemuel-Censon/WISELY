<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="addMember.aspx.cs" Inherits="WISLEY.Views.Group.inviteStudent" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <h1 class="col-12 text-center">Add Student
            </h1>
            <div class="col-6 card-body border border-primary vh-30 overflow-auto">
                <asp:Repeater
                    runat="server" ID="userListBtns"
                    OnItemCommand="addMemberCommand">
                    <ItemTemplate>
                        <div class="row justify-content-start p-1 py-3 m-2 border border-rounded border-light">
                            <div class="col-2">
                                <img src='<%#Eval("profilesrc") %>' onerror="this.src='<%=Page.ResolveUrl("~/Public/img/default.jpg") %>'"
                                    class="img-fluid img-thumbnail" />
                            </div>

                            <div class="col-6">
                                <h3 class=""><%#Eval("name")%> </h3>
                                <h5><%# Eval("userType") %> </h5>
                            </div>

                            <div class="col-4">
                                <asp:LinkButton ID="userBtns" runat="server" Text='Add to Group' CommandName="addToGroup" CommandArgument='<%#Eval("email") %>'
                                    class="btn btn-block btn-white text-left border border-primary rounded-0 mb-1" Style="text-transform: unset;" />
                            </div>

                        </div>





                    </ItemTemplate>

                    <FooterTemplate>
                        <% if (userListBtns.Items.Count == 0)
                            { %>
                        <div class="row col-12 justify-content-center align-content-start">

                            <h6 class="text-center col-12 pb-2">There are no users to be added.
                            </h6>

                        </div>
                        <%} %>
                    </FooterTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
