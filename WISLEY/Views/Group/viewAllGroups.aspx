<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="viewAllGroups.aspx.cs" Inherits="WISLEY.Views.Group.viewAllGroups" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-around">
            <h1 class="col-12 text-center mb-3">All Groups</h1>

            <div class="
                <% if (user().userType == "Teacher")
                {%>col-lg-3 <% }
                else
                { %> 
                col-lg-5
                <% } %>
                col-md-12 card-body border border-primary rounded z-depth-1">

                <div id="reorderListDiv" class="vh-50 overflow-auto">
                    <h2 class="col-12 text-center">Sidebar </h2>
                    <div class="border vh-40 overflow-auto">

                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <ajaxToolkit:ReorderList
                            ID="AllGroupReorderList"
                            runat="server"
                            AllowReorder="True"
                            DragHandleAlignment="Left" ItemInsertLocation="Beginning"
                            DataSourceID="SQLgroupData" DataKeyField="groupID"
                            SortOrderField="customOrder"
                            PostBackOnReorder="false"
                            OnItemCommand="AllGroupReorderList_groupOrderCommand"
                            OnItemDataBound="AllGroupReorderList_onItemDataBound">

                            <DragHandleTemplate>
                                <div class="mr-2">
                                    <a><i class="fas fa-bars align-middle"></i></a>
                                </div>
                            </DragHandleTemplate>

                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="grpName" Value='<%#Eval("name") %>' />

                                <div class="row justify-content-between m-0 ">
                                    <asp:HyperLink 
                                        class="align-middle col-10 align-content-between text-left m-0 h6 font-weight-normal"
                                        Style="text-transform: none;"
                                        NavigateUrl='<%# Eval("groupId", "~/Views/Board/collab.aspx?groupId={0}") %>'
                                        ID="grpNameLabel"
                                        runat="server">
                                    </asp:HyperLink>
<%--                                   CommandName="redirectToGroup" CommandArgument="<%#Eval("groupId").ToString()%>"--%>

                                    <div class="align-middle col-2 align-content-between m-0 row justify-content-end dropdown">
                                        <a class="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            <i class="fas fa-ellipsis-v align-middle text-right text-grey"></i>
                                        </a>
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="hideGroupLabel" runat="server" Text='Hide Group'
                                                CommandName="hideGroup" CommandArgument='<%#Eval("groupId") %>'
                                                class="dropdown-item" />

                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </ajaxToolkit:ReorderList>
                    </div>

                </div>

                <asp:SqlDataSource ID="SQLgroupData"
                    ConnectionString="<%$ connectionStrings: ConnStr%>"
                    OldValuesParameterFormatString="original_{0}"
                    runat="server"
                    UpdateCommand='UPDATE [GroupUserRelations] SET [customOrder] = @customOrder WHERE [groupID] = @original_groupID and [userEmail] = @userEmail'>

                    <UpdateParameters>
                        <asp:Parameter Name="userEmail" Type="String" />
                        <asp:Parameter Name="show" Type="Int32" />
                        <asp:Parameter Name="customOrder" Type="Int32" />
                        <asp:Parameter Name="original_groupID" Type="Int32" />
                    </UpdateParameters>


                </asp:SqlDataSource>
                <asp:Button ID="cancelBtn" runat="server" Text="Back" class="btn btn-primary" OnClick="back" />

            </div>

            <div class="
                <% if (user().userType == "Teacher")
                {%>col-lg-3 <% }
                else
                { %> 
                col-lg-5
                <% } %>
                col-md-12 card-body border border-primary rounded z-depth-1">
                <h2 class="col-12 text-center">Hidden Groups </h2>
                <div class="border vh-40">
                    <asp:Repeater
                        runat="server" ID="hiddenGroupsBtns"
                        DataSourceID="SQLhiddenGroupData"
                        OnItemCommand="hiddenGroupsBtns_groupOrderCommand"
                        OnItemDataBound="repeaterGroupsBtns_onItemDataBound">

                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="grpName" Value='<%#Eval("name") %>' />


                            <div class="white border list-item pr-0 p-3 mb-3 z-depth-1 mx-1 row justify-content-between">
                                <asp:HyperLink class="align-middle col-10 align-content-between text-left m-0 h6 font-weight-normal"
                                    Style="text-transform: none;"
                                    NavigateUrl='<%# Eval("groupId", "~/Views/Board/collab.aspx?groupId={0}") %>'
                                    ID="grpNameLabel"
                                    runat="server">
                                </asp:HyperLink>

                                <div class="align-middle col-2 align-content-between m-0 row justify-content-end dropdown">
                                    <a class="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="fas fa-ellipsis-v align-middle text-right text-grey"></i>
                                    </a>
                                    <div class="dropdown-menu">
                                        <asp:LinkButton ID="showGroupLabel" runat="server" Text='Show Group'
                                            CommandName="showGroup" CommandArgument='<%#Eval("groupId") %>'
                                            class="dropdown-item" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                        <FooterTemplate>
                            <div class="row col-12 justify-content-center align-content-start <% if (hiddenGroupsBtns.Items.Count == 0)
                                { %> visible <%}
                                else
                                { %> invisible <%} %>">
                                <h6 class="text-center col-12 pb-2">All Groups are active
                                </h6>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <asp:SqlDataSource ID="SQLhiddenGroupData"
                        ConnectionString="<%$ connectionStrings: ConnStr%>"
                        runat="server" />
                </div>
            </div>
            <% if (user().userType == "Teacher")
                {%>
            <div class="col-lg-3 col-md-12 card-body border border-primary rounded z-depth-1">
                <h2 class="col-12 text-center">Disabled Groups </h2>
                <div class="border vh-40">
                    <asp:Repeater
                        runat="server" ID="inactiveGroupsBtns" DataSourceID="SQLinactiveGroupData"
                        OnItemCommand="inactiveGroupsBtns_groupOrderCommand"
                        OnItemDataBound="repeaterGroupsBtns_onItemDataBound">

                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="grpName" Value='<%#Eval("name") %>' />

                            <div class="white border list-item pr-0 p-3 mb-3 z-depth-1 mx-1 row justify-content-between">
                                <asp:HyperLink class="align-middle col-10 align-content-between text-left m-0 h6 font-weight-normal"
                                    Style="text-transform: none;"
                                    NavigateUrl='<%# Eval("groupId", "~/Views/Board/collab.aspx?groupId={0}") %>'
                                    ID="grpNameLabel"
                                    runat="server">
                                </asp:HyperLink>

                                <div class="align-middle col-2 align-content-between m-0 row justify-content-end dropdown">
                                    <a class="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="fas fa-ellipsis-v align-middle text-right text-grey"></i>
                                    </a>
                                    <div class="dropdown-menu">
                                        <asp:LinkButton ID="showGroupLabel" runat="server" Text='Enable Group'
                                            CommandName="activateGroup" CommandArgument='<%#Eval("groupId") %>'
                                            class="dropdown-item" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                        <FooterTemplate>
                            <div class="row col-12 justify-content-center align-content-start <% if (inactiveGroupsBtns.Items.Count == 0)
                                { %> visible <%}
                                else
                                { %> invisible <%} %>">
                                <h6 class="text-center col-12 pb-2">There are no inactive groups
                                </h6>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <asp:SqlDataSource ID="SQLinactiveGroupData"
                        ConnectionString="<%$ connectionStrings: ConnStr%>"
                        runat="server" />
                </div>
            </div>
            <% } %>
        </div>
    </div>

    <script>
        $("#contentHolder1_AllGroupReorderList__rbl").addClass("list-group")
        $("#contentHolder1_AllGroupReorderList__rbl").children().addClass("white border list-item pr-0 p-3 mb-3 z-depth-1 mx-1")
        $("#contentHolder1_AllGroupReorderList__rbl").children().css("list-style", "none")
        //$("#contentHolder1_AllGroupReorderList__rbl").children().addClass("btn btn-white pr-0")

    </script>

</asp:Content>


