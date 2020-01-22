<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="viewpost.aspx.cs" Inherits="WISLEY.viewpost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="groupPosts" runat="server">
    <div class="container">
        <div class="card mt-3">
            <asp:Label runat="server" ID="LbEmail" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="LbPostID" Visible="false"></asp:Label>
            <asp:HiddenField runat="server" ID="LbUserID" />
            <asp:Repeater runat="server" ID="post" DataSourceID="postdata" OnItemCommand="post_ItemCommand">
                <ItemTemplate>
                    <div class="card-body">
                        <asp:Button runat="server" ID="btnback" CssClass="btn btn-sm btn-danger" Text="<< Back" OnClick="btnback_Click" />
                        <h4 class="card-title d-inline"><%#Eval("title") %></h4>
                        <div class="media mt-4 px-1">
                            <img class="card-img-100 d-flex z-depth-1 mr-3" src="https://picsum.photos/100"
                                alt="Generic placeholder image">
                            <div class="media-body">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <h5 class="font-weight-bold mt-0">
                                            <asp:LinkButton runat="server" ID="postlink" CommandName="viewpost" CommandArgument='<%#Eval("userId") %>'><%#Eval("name") %></asp:LinkButton>
                                        </h5>
                                    </div>
                                    <div class="col-lg-6">
                                        <i class="fas fa-clock mr-1 "></i><span>Created on: <%#Eval("datecreated") %>
                                        </span>
                                    </div>
                                </div>
                                <%#Eval("content")%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource runat="server" ID="postdata" ConnectionString="<%$ connectionStrings: ConnStr%>"></asp:SqlDataSource>
            <hr />
            <h5 class="text-center my-3">Comments</h5>
            <div class="accordion" role="tablist" id="commentacc" aria-multiselectable="true">
                <div class="card">
                    <div class="card-header" role="tab" id="commhead">
                        <a data-toggle="collapse" data-parent="#commentacc" href="#comms" aria-expanded="true"
                            aria-controls="comms">
                            <div class="card-header border-0 font-weight-bold"><%=commcount().ToString() %> comment(s)<i class="fas fa-angle-down ml-1"></i></div>
                        </a>
                    </div>
                    <div id="comms" class="show" role="tabpanel" aria-labelledby="commhead" data-parent="#commentacc">
                        <div class="card-body">
                            <asp:ScriptManager runat="server" ID="commscript">
                            </asp:ScriptManager>
                            <div class="md-form md-outline">
                                <asp:Label ID="LbComment" AssociatedControlID="tbcomment" runat="server" Text="Comment"></asp:Label>
                                <asp:TextBox ID="tbcomment" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="4"></asp:TextBox>
                            </div>
                            <div class="text-right">
                                <asp:Button CssClass="btn btn-success btn-sm ml-auto" ID="btncomment" runat="server" Text="Post" OnClick="btncomment_Click" />
                            </div>
                            <hr />
                            <asp:UpdatePanel runat="server" ID="commpanel" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Repeater runat="server" DataSourceID="commentdata" ID="commentinfo" OnItemCommand="commentinfo_ItemCommand" OnItemDataBound="commentinfo_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="media d-block d-md-flex mt-4">
                                                <img class="card-img-64 d-flex mx-auto mb-3" src="https://picsum.photos/100"
                                                    alt="Generic placeholder image">
                                                <div class="media-body text-center text-md-left ml-md-3 ml-0">
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <h5 class="font-weight-bold mt-0">
                                                                <asp:LinkButton runat="server" ID="viewprofile" CommandName="viewprofile" CommandArgument='<%#Eval("userId") %>' Text='<%#Eval("name") %>'></asp:LinkButton>
                                                                <asp:HiddenField runat="server" ID="commuserID" Value='<%#Eval("userId") %>' />
                                                            </h5>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <i class="fas fa-clock mr-1"></i><span>Posted on: <%#Eval("datecreated") %></span>
                                                            <div class="row">
                                                                <div class="col-lg-6 text-left">
                                                                    <asp:Button runat="server" CommandName="editcomm" ID="btnEdit" Text="Edit" CssClass="btn btn-sm btn-info" />
                                                                </div>
                                                                <div class="col-lg-6 text-left">
                                                                    <button type="button" id="delconfirm" class="btn btn-sm btn-danger d-inline-block" data-toggle="modal" data-target="#delmodal<%#Eval("Id") %>">
                                                                        Delete
                                                                    </button>
                                                                </div>
                                                            </div>
                                                            <div class="modal fade" id="delmodal<%#Eval("Id") %>" tabindex="-1" role="dialog"
                                                                aria-hidden="true">
                                                                <div class="modal-dialog" role="document">
                                                                    <div class="modal-content">
                                                                        <div class="modal-header">
                                                                            <h5 class="modal-title">Are you sure you want to delete this comment?</h5>
                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                <span aria-hidden="true">&times;</span>
                                                                            </button>
                                                                        </div>
                                                                        <div class="modal-body text-center">
                                                                            Deletion of this comment cannot be reverted once confirmed!
                                                                        </div>
                                                                        <div class="modal-footer">
                                                                            <button type="button" class="btn btn-sm btn-danger" data-dismiss="modal">No</button>
                                                                            <asp:Button runat="server" CommandName="delcomm" CommandArgument='<%#Eval("Id") %>' ID="btnDelete" Text="Yes" CssClass="btn btn-sm btn-success" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div runat="server" id="commcontent">
                                                        <%#Eval("content") %>
                                                    </div>
                                                    <asp:TextBox runat="server" ID="tbUpcomm" CssClass="form-control" Text='<%#Eval("content") %>' TextMode="MultiLine" Rows="4" Visible="false"></asp:TextBox>
                                                    <div runat="server" id="editbtns" class="text-right" visible="false">
                                                        <asp:Button runat="server" CommandName="cancel" ID="btncancel" Text="Cancel" CssClass="btn btn-sm btn-danger" />
                                                        <asp:Button runat="server" CommandName="save" CommandArgument='<%#Eval("Id") %>' ID="btnsave" Text="Save Changes" CssClass="btn btn-sm btn-success" />
                                                    </div>
                                                </div>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <div class="text-center mb-4">
                                                <h4>
                                                    <asp:Label runat="server" ID="LbErr" Text="No Comments" CssClass="font-weight-bold" Visible="false"></asp:Label>
                                                </h4>
                                            </div>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <asp:SqlDataSource ID="commentdata"
                                        ConnectionString="<%$ connectionStrings: ConnStr%>"
                                        runat="server"></asp:SqlDataSource>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

