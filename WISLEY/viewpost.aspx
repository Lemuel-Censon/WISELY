<%@ Page Title="" Language="C#" MasterPageFile="~/group.Master" AutoEventWireup="true" CodeBehind="viewpost.aspx.cs" Inherits="WISLEY.viewpost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="groupPosts" runat="server">
    <form runat="server">
        <div class="container">
            <div class="card mt-3">
                <div class="card-body">
                    <h4 class="card-title"><% =post().title %></h4>
                    <div class="media mt-4 px-1">
                        <img class="card-img-100 d-flex z-depth-1 mr-3" src="https://picsum.photos/100"
                            alt="Generic placeholder image">
                        <div class="media-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <h5 class="font-weight-bold mt-0">
                                        <a href="#">Danny Newman</a>
                                    </h5>
                                </div>
                                <div class="col-lg-6">
                                    <i class="fas fa-clock mr-1 "></i><span>Created on: <% =post().datecreated.ToShortDateString() %>
                                    </span>
                                </div>
                            </div>
                            <% =post().content %>
                        </div>
                    </div>
                    <hr />
                    <h5 class="text-center my-3">Comments</h5>
                    <div class="accordion" role="tablist" id="commentacc" aria-multiselectable="true">
                        <div class="card">
                            <div class="card-header" role="tab" id="commhead">
                                <a data-toggle="collapse" data-parent="#commentacc" href="#comms" aria-expanded="true"
                                    aria-controls="comms">
                                    <div class="card-header border-0 font-weight-bold"><%=allComments().Count.ToString() %> comment(s)<i class="fas fa-angle-down mr-1"></i></div>
                                </a>
                            </div>
                            <div id="comms" class="show" role="tabpanel" aria-labelledby="commhead" data-parent="#commentacc">
                                <div class="card-body">
                                    <div class="md-form md-outline">
                                        <asp:Label ID="LbComment" AssociatedControlID="tbcomment" runat="server" Text="Comment"></asp:Label>
                                        <asp:TextBox ID="tbcomment" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="4"></asp:TextBox>
                                    </div>
                                    <div class="text-right">
                                        <asp:Button CssClass="btn btn-success btn-sm ml-auto" ID="btncomment" runat="server" Text="Post" OnClick="btncomment_Click" />
                                    </div>
                                    <hr />
                                    <% if (allComments().Count > 0)
                                        { %><% foreach (var comment in allComments())
                                                { %>
                                    <div class="media d-block d-md-flex mt-4">
                                        <img class="card-img-64 d-flex mx-auto mb-3" src="https://picsum.photos/100"
                                            alt="Generic placeholder image">
                                        <div class="media-body text-center text-md-left ml-md-3 ml-0">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <h5 class="font-weight-bold mt-0">
                                                        <a href="#">Howard</a>
                                                    </h5>
                                                </div>
                                                <div class="col-lg-6">
                                                    <i class="fas fa-clock mr-1"></i><span>Posted on: <% =comment.datecreate.ToShortDateString() %></span>
                                                </div>
                                            </div>
                                            <%=comment.content %>
                                        </div>
                                    </div>
                                    <hr />
                                    <%} %>
                                    <%} %>
                                    <% else
                                        { %>
                                    <h5 class="mt-3 font-weight-bold">No Comments</h5>
                                    <%} %>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

