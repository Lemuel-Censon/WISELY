<%@ Page Title="" Language="C#" MasterPageFile="~/group.Master" AutoEventWireup="true" CodeBehind="collab.aspx.cs" Inherits="WISLEY.collab" %>

<asp:Content ID="Content2" ContentPlaceHolderID="groupPosts" runat="server">
    <h3 class="font-weight-bold text-center">Collaboration Board</h3>
    <form runat="server">
        <div class="container">
            <div class="card">
                <div class="card-body">
                    <label for="tbtitle">Post title: </label>
                    <asp:TextBox ID="tbtitle" runat="server" CssClass="form-control"></asp:TextBox>
                    <hr />
                    <label for="tbcontent">Description: </label>
                    <asp:TextBox ID="tbcontent" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="6"></asp:TextBox>
                    <div class="row">
                        <div class="col-lg-4">
                            <asp:FileUpload ID="fileUpload" runat="server" />
                            <asp:Label ID="LbStatus" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-4">
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-4 text-right">
                            <asp:Button CssClass="btn btn-success ml-auto" ID="btnpost" runat="server" Text="Post" OnClick="btnpost_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <% if (allPosts.Count > 0)
                { %>
            <% foreach (var post in allPosts)
                { %>
            <%foreach (var id in post.SelectIDs())
                { %>
            <div class="card mt-3">
                <div class="card-body">
                    <h4 class="card-title"><% =post.title %></h4>
                    <p class="card-text">By: </p>
                    <i class="fas fa-clock"></i><span class="card-text">Created on: <% =post.datecreated.ToShortDateString() %></span>
                    <hr />
                    <p class="card-text"><% =post.content %></p>
                    <div class="accordion" role="tablist" id="commentacc<%=id %>" aria-multiselectable="true">
                        <div class="card">
                            <div class="card-header" role="tab" id="commhead">
                                <a data-toggle="collapse" data-parent="#commentacc<%=id %>" href="#comms<%=id %>" aria-expanded="true"
                                    aria-controls="comms<%=id %>">
                                    <h5 class="mb-0">Comments (<%=allComments.Count.ToString() %>)<i class="fas fa-angle-down rotate-icon"></i>
                                    </h5>
                                </a>
                            </div>
                            <div id="comms<%=id %>" class="collapse" role="tabpanel" aria-labelledby="commhead" data-parent="#commentacc">
                                <div class="card-body">
                                    <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" CssClass="btn btn-sm btn-info" OnClick="btnAddComment_Click" />
                                    <% if (allComments.Count > 0)
                                        { %><% foreach (var comment in allComments)
                                                { %>
                                    <div class="border border-dark">
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <p class="card-text"></p>
                                            </div>
                                            <div class="col-lg-4">
                                                <i class="fas fa-clock"></i><span class="card-text">Posted on: <% =comment.datecreate.ToShortDateString() %></span>
                                            </div>
                                        </div>
                                        <div class="text-left p-2">
                                            <p>
                                                <% =comment.content %>
                                            </p>
                                        </div>
                                    </div>
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
                <%} %>


                <%} %>            <%} %><% else
                                            { %>
                <div class="text-center mt-3">
                    <h4 class="font-weight-bold">No Posts</h4>
                </div>
                <% } %>
            </div>
        </div>
    </form>
</asp:Content>
