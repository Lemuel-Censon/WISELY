<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="collab.aspx.cs" Inherits="WISLEY.collab" %>

<asp:Content ID="Content2" ContentPlaceHolderID="groupPosts" runat="server">
    <% string inGroup = Request.QueryString["groupId"];  %>
    <% if (String.IsNullOrEmpty(inGroup))
        {%>
    <h3 class="font-weight-bold text-center mt-2">Collaboration Board</h3>
    <%} %>
    <div class="container">
        <asp:ScriptManager runat="server" ID="postscript">
        </asp:ScriptManager>
        <asp:Label runat="server" ID="LbEmail" Visible="false"></asp:Label>
        <div class="card">
            <div class="card-body">
                <div class="md-form md-outline">
                    <asp:Label ID="LbPost" AssociatedControlID="tbtitle" runat="server" Text="Post Title"></asp:Label>
                    <asp:TextBox ID="tbtitle" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <hr />
                <div class="md-form md-outline">
                    <asp:Label ID="LbDesc" AssociatedControlID="tbcontent" runat="server" Text="Post Description"></asp:Label>
                    <asp:TextBox ID="tbcontent" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="6"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="custom-file">
                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="custom-file-input" />
                            <asp:Label ID="LbFile" AssociatedControlID="fileUpload" runat="server" Text="Upload a file" CssClass="custom-file-label"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <asp:DropDownList runat="server" ID="ddlgrp" Visible="false" CssClass="custom-select"></asp:DropDownList>
                    </div>
                </div>
                <div class="text-right">
                    <asp:Button CssClass="btn btn-success ml-auto" ID="btnpost" runat="server" Text="Post" OnClick="btnpost_Click" />
                </div>
            </div>
        </div>
        <div class="card mt-3">
            <div class="card-body">
                <div class="row">
                    <div class="col-12 col-md-6 order-3 order-md-2">
                        <select class="md-form md-outline custom-select sort-select">
                            <option selected disabled>Sort By</option>
                            <option>Oldest first</option>
                            <option>Newest first</option>
                            <option>Most Viewed</option>
                            <option>Most Liked</option>
                        </select>
                    </div>
                    <div class="col-12 col-md-6 order-1 order-md-3 mt-2 mt-md-0">
                        <div class="input-group md-form md-outline">
                            <input type="text" id="search" class="form-control" placeholder="Search by Title" />
                            <div class="input-group-append">
                                <button type="button" class="btn btn-md btn-info m-0 px-3 py-2 waves-effect" id="searchbut"><i class="fas fa-search"></i></button>
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
            </div>
            <asp:UpdatePanel runat="server" ID="postpanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="postcon">
                        <asp:Repeater runat="server" ID="postinfo" OnItemCommand="postinfo_ItemCommand" OnItemDataBound="postinfo_ItemDataBound">
                            <ItemTemplate>
                                <div class="postcards" data-id='<%#Eval("Id") %>' data-views='<%#Eval("views") %>' data-likes='<%#Eval("likes") %>'>
                                    <div class="card-body" id="post<%#Eval("Id") %>">
                                        <asp:HiddenField runat="server" ID="postuserID" Value='<%#Eval("userId") %>' />
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <h4 class="card-title posttitle" runat="server" id="posttitle" data-title='<%#Eval("title") %>'><%#Eval("title") %></h4>
                                                <asp:TextBox runat="server" ID="tbUptitle" CssClass="form-control" Text='<%#Eval("title") %>' Visible="false"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-6 text-right">
                                                <asp:LinkButton runat="server" CommandName="like" CommandArgument='<%#Eval("Id") %>' ID="btnLike" CssClass="btn btn-sm btn-danger" Visible="false"><i class="fas fa-heart"></i></asp:LinkButton>
                                                <asp:LinkButton runat="server" CommandName="editpost" ID="btnEdit" Text="Edit" CssClass="btn btn-sm btn-info"></asp:LinkButton>
                                                <div runat="server" id="delete" class="d-inline">
                                                    <button type="button" class="btn btn-sm btn-danger" data-toggle="modal" data-target="#delmodal<%#Eval("Id") %>">
                                                        Delete
                                                    </button>
                                                </div>
                                                <div class="modal fade" id="delmodal<%#Eval("Id") %>" tabindex="-1" role="dialog"
                                                    aria-hidden="true">
                                                    <div class="modal-dialog" role="document">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <h5 class="modal-title">Are you sure you want to delete this post?</h5>
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                    <span aria-hidden="true">&times;</span>
                                                                </button>
                                                            </div>
                                                            <div class="modal-body text-center">
                                                                Deletion of this post cannot be reverted once confirmed!
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-sm btn-danger" data-dismiss="modal">No</button>
                                                                <asp:LinkButton runat="server" CommandName="delpost" CommandArgument='<%#Eval("Id") %>' ID="btnDelete" Text="Yes" CssClass="btn btn-sm btn-success"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="media mt-4 px-1">
                                            <img class="card-img-100 d-flex z-depth-1 mr-3" src="https://picsum.photos/100"
                                                alt="Generic placeholder image">
                                            <div class="media-body">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <h5 class="font-weight-bold mt-0">
                                                            <asp:LinkButton runat="server" ID="viewprofile" CommandName="viewprofile" CommandArgument='<%#Eval("userId") %>' Text='<%#Eval("username") %>'></asp:LinkButton>
                                                        </h5>
                                                    </div>
                                                    <div class="col-lg-6 text-right">
                                                        <i class="fas fa-clock mr-1"></i><span>Created on: <%#Eval("datecreated") %>
                                                        </span>
                                                        <div class="mt-2">
                                                            <i class="fas fa-eye mr-1"></i><span><%#Eval("views") %>
                                                            </span>
                                                        </div>
                                                        <div>
                                                            <i class="fas fa-heart mr-1"></i><span><%#Eval("likes") %>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div runat="server" id="postcontent">
                                                    <%#Eval("content") %>
                                                </div>
                                                <asp:TextBox runat="server" ID="tbUpcontent" TextMode="MultiLine" Rows="6" CssClass="form-control" Text='<%#Eval("content") %>' Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="card-header border-0 font-weight-bold">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:LinkButton runat="server" CommandName="cancel" ID="btncancel" Text="Cancel" CssClass="btn btn-sm btn-danger" Visible="false"></asp:LinkButton>
                                                </div>
                                                <div class="text-right col-lg-6">
                                                    <asp:LinkButton runat="server" CommandName="save" CommandArgument='<%#Eval("Id") %>' ID="btnSave" Text="Save Changes" CssClass="btn btn-sm btn-success" Visible="false"></asp:LinkButton>
                                                    <asp:LinkButton runat="server" CommandName="viewpost" CommandArgument='<%#Eval("Id") %>' ID="btnView" Text="View >>" CssClass="btn btn-sm btn-success"></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="text-center mb-4">
                                    <h4>
                                        <asp:Label runat="server" ID="LbErr" Text="No Posts" CssClass="font-weight-bold" Visible="false"></asp:Label>
                                    </h4>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script src="<%= Page.ResolveUrl("~/Public/js/collabscript.js") %>" type="text/javascript"></script>
</asp:Content>
