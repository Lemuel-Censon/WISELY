<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.master" AutoEventWireup="true" CodeBehind="viewnotif.aspx.cs" Inherits="WISLEY.Views.Notification.viewnotif" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">
        <div class="card">
            <div class="card-body">
                <h4 class="font-weight-bold text-center">Notifications</h4>
                <div class="mx-auto">
                    <ul class="nav nav-tabs rounded-0" role="tablist">
                        <li class="nav-item ml-0">
                            <a class="nav-link waves-light active show" data-toggle="tab" role="tab" href="#pnotifs">Posts
                                <%if (notifcount()[0] > 0)
                                    { %>
                                <span class="font-weight-bold text-danger">!</span>
                                <%} %>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link waves-light" data-toggle="tab" role="tab" href="#cnotifs">Comments
                                                            <%if (notifcount()[1] > 0)
                                                                { %>
                                <span class="font-weight-bold text-danger">!</span>
                                <%} %>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link waves-light" data-toggle="tab" role="tab" href="#inotifs">Groups
                                                            <%if (notifcount()[2] > 0)
                                                                { %>
                                <span class="font-weight-bold text-danger">!</span>
                                <%} %>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link waves-light" data-toggle="tab" role="tab" href="#bnotifs">Badges
                                <%if (notifcount()[3] > 0)
                                    { %>
                                <span class="font-weight-bold text-danger">!</span>
                                <%} %>
                            </a>
                        </li>
                    </ul>
                </div>

                <div class="tab-content p-0">
                    <div class="tab-pane fade active show" role="tabpanel" id="pnotifs">
                        <div class="row justify-content-center mx-auto p-2 col-12">
                            <asp:Repeater runat="server" ID="postnotifs" OnItemCommand="postnotifs_ItemCommand" OnItemDataBound="postnotifs_ItemDataBound">
                                <ItemTemplate>
                                    <div class="col-12 row justify-content-between z-depth-1 my-2">
                                        <div class="col-8 row mx-auto my-3">
                                            <div class="pl-2 align-self-center pt-1">
                                                <h5>
                                                    <asp:LinkButton runat="server" CommandName="viewprofile" CommandArgument='<%#Eval("senderEmail") %>'><%#Eval("senderName") %></asp:LinkButton>
                                                    posted 
                                                    <asp:LinkButton runat="server" CommandName="viewpost" CommandArgument='<%#Eval("postId") %>'><%#Eval("postName") %></asp:LinkButton>
                                                    in group 
                                                    <asp:LinkButton runat="server" CommandName="viewgroup" CommandArgument='<%#Eval("groupId") %>'><%#Eval("groupName") %></asp:LinkButton>
                                                </h5>
                                            </div>
                                        </div>
                                        <div class="col-2 align-self-center pt-2 row justify-content-end mx-auto">
                                            <h6 class="text-muted text-right">
                                                <%#Eval("datecreated") %>
                                            </h6>
                                        </div>
                                        <asp:LinkButton runat="server" CssClass="close mx-auto align-self-center" CommandName="clearnotif" CommandArgument='<%#Eval("Id") %>'>
                                            <span aria-hidden="true">&times;</span>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="text-center mt-2">
                                        <h4>
                                            <asp:Label runat="server" ID="LbErr" Text="No Notifications" Visible="false"></asp:Label>
                                        </h4>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="tab-pane fade" role="tabpanel" id="cnotifs">
                        <div class="row justify-content-center mx-auto p-2 col-12">
                            <asp:Repeater runat="server" ID="commentnotifs" OnItemCommand="commentnotifs_ItemCommand" OnItemDataBound="commentnotifs_ItemDataBound">
                                <ItemTemplate>
                                    <div class="col-12 row justify-content-between z-depth-1 my-2">
                                        <div class="col-8 row mx-auto my-3">
                                            <div class="pl-2 align-self-center pt-1">
                                                <h5>
                                                    <asp:LinkButton runat="server" CommandName="viewprofile" CommandArgument='<%#Eval("senderEmail") %>'><%#Eval("senderName") %></asp:LinkButton>
                                                    commented on your post  
                                                    <asp:LinkButton runat="server" CommandName="viewpost" CommandArgument='<%#Eval("postId") %>'><%#Eval("postName") %></asp:LinkButton>
                                                    in group 
                                                    <asp:LinkButton runat="server" CommandName="viewgroup" CommandArgument='<%#Eval("groupId") %>'><%#Eval("groupName") %></asp:LinkButton>
                                                </h5>
                                            </div>
                                        </div>
                                        <div class="col-2 align-self-center pt-2 row justify-content-end mx-auto">
                                            <h6 class="text-muted text-right">
                                                <%#Eval("datecreated") %>
                                            </h6>
                                        </div>
                                        <asp:LinkButton runat="server" CssClass="close mx-auto align-self-center" CommandName="clearnotif" CommandArgument='<%#Eval("Id") %>'>
                                            <span aria-hidden="true">&times;</span>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="text-center mt-2">
                                        <h4>
                                            <asp:Label runat="server" ID="LbErr" Text="No Notifications" Visible="false"></asp:Label>
                                        </h4>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="tab-pane fade" role="tabpanel" id="inotifs">
                        <div class="row justify-content-center mx-auto p-2 col-12">
                            <asp:Repeater runat="server" ID="invitenotifs" OnItemCommand="invitenotifs_ItemCommand" OnItemDataBound="invitenotifs_ItemDataBound">
                                <ItemTemplate>
                                    <div class="col-12 row justify-content-between z-depth-1 my-2">
                                        <div class="col-8 row mx-auto my-3">
                                            <div class="pl-2 align-self-center pt-1">
                                                <h5>You have been added to group
                                                    <asp:LinkButton runat="server" CommandName="viewgroup" CommandArgument='<%#Eval("groupId") %>'><%#Eval("groupName") %></asp:LinkButton>
                                                    by 
                                                    <asp:LinkButton runat="server" CommandName="viewprofile" CommandArgument='<%#Eval("senderEmail") %>'><%#Eval("senderName") %></asp:LinkButton>
                                                </h5>
                                            </div>
                                        </div>
                                        <div class="col-2 align-self-center pt-2 row justify-content-end mx-auto">
                                            <h6 class="text-muted text-right">
                                                <%#Eval("datecreated") %>
                                            </h6>
                                        </div>
                                        <asp:LinkButton runat="server" CssClass="close mx-auto align-self-center" CommandName="clearnotif" CommandArgument='<%#Eval("Id") %>'>
                                            <span aria-hidden="true">&times;</span>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="text-center mt-2">
                                        <h4>
                                            <asp:Label runat="server" ID="LbErr" Text="No Notifications" Visible="false"></asp:Label>
                                        </h4>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="tab-pane fade" role="tabpanel" id="bnotifs">
                        <div class="row justify-content-center mx-auto p-2 col-12">
                            <asp:Repeater runat="server" ID="badgenotifs" OnItemCommand="badgenotifs_ItemCommand" OnItemDataBound="badgenotifs_ItemDataBound">
                                <ItemTemplate>
                                    <div class="col-12 row justify-content-between z-depth-1 my-2">
                                        <div class="col-8 row mx-auto my-3">
                                            <div class="pl-2 align-self-center pt-1">
                                                <h5> You have earned the badge 
                                                    <asp:LinkButton runat="server" CommandName="viewprofile"><%#Eval("badgeName") %></asp:LinkButton>!
                                                </h5>
                                            </div>
                                        </div>
                                        <div class="col-2 align-self-center pt-2 row justify-content-end mx-auto">
                                            <h6 class="text-muted text-right">
                                                <%#Eval("datecreated") %>
                                            </h6>
                                        </div>
                                        <asp:LinkButton runat="server" CssClass="close mx-auto align-self-center" CommandName="clearnotif" CommandArgument='<%#Eval("Id") %>'>
                                            <span aria-hidden="true">&times;</span>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="text-center mt-2">
                                        <h4>
                                            <asp:Label runat="server" ID="LbErr" Text="No Notifications" Visible="false"></asp:Label>
                                        </h4>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
