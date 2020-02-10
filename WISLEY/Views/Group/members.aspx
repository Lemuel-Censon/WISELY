<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="members.aspx.cs" Inherits="WISLEY.Views.Group.members" %>

<asp:Content ID="Content4" ContentPlaceHolderID="groupMembers" runat="server">
    <div class="container">


        <asp:Repeater
            runat="server" ID="memberList" DataSourceID="memberData" OnItemCommand="memberCommands" OnItemDataBound="memberList_ItemDataBound">
            <ItemTemplate>
                <div class="row justify-content-start p-1 py-3 m-2 border border-rounded border-light">
                    <asp:HiddenField runat="server" ID="userEmail" Value='<%#Eval("email") %>' />

                    <div class="col-2">
                        <img src='<%# Eval("profilesrc") %>' onerror="this.src='<%=Page.ResolveUrl("~/Public/img/default.jpg") %>'"
                            class="img-fluid img-thumbnail" />
                    </div>

                    <div class="col-6">
                        <h3 class=""><%#Eval("name")%> </h3>
                        <h5><%# Eval("accType") %> </h5>
                    </div>

                    <div class="col-4">
                        <asp:LinkButton ID="userDeleteBtn" runat="server" Text='Remove From Group' CommandName="removeFromGroup" CommandArgument='<%#Eval("email") %>'
                            class="btn btn-block btn-outline-danger text-left border border-primary rounded-0 mb-1"
                            Style="text-transform: unset;" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


        <asp:SqlDataSource ID="memberData"
            ConnectionString="<%$ connectionStrings: ConnStr%>"
            runat="server"></asp:SqlDataSource>
    </div>
</asp:Content>
<%--
    
--%>