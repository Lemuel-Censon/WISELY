<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.master" AutoEventWireup="true" CodeBehind="viewnotif.aspx.cs" Inherits="WISLEY.Views.Notification.viewnotif" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">
        <div class="card">
            <div class="card-body">
                <h4 class="font-weight-bold text-center">Notifications</h4>
                <div class="mx-auto">
                    <ul class="nav nav-tabs rounded-0" role="tablist">
                        <li class="nav-item ml-0">
                            <a class="nav-link waves-light active show" data-toggle="tab" role="tab" href="#pnotifs">Posts</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link waves-light" data-toggle="tab" role="tab" href="#inotifs">Invites</a>
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
                                                    <asp:LinkButton runat="server" CommandName="viewprofile" CommandArgument='<%#Eval("senderId") %>'><%#Eval("senderName") %></asp:LinkButton>
                                                     posted 
                                                    <asp:LinkButton runat="server" CommandName="viewpost" CommandArgument='<%#Eval("postId") %>'><%#Eval("postName") %></asp:LinkButton>
                                                     in group 
                                                    <asp:LinkButton runat="server" CommandName="viewgroup" CommandArgument='<%#Eval("groupId") %>'><%#Eval("groupName") %></asp:LinkButton>
                                                </h5>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <div class="text-center mb-4">
                                        <h4>
                                            <asp:Label runat="server" ID="LbErr" Text="No Notifications" CssClass="font-weight-bold" Visible="false"></asp:Label>
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
