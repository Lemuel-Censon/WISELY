<%@ Page Title="" Language="C#" MasterPageFile="~/group.Master" AutoEventWireup="true" CodeBehind="collab.aspx.cs" Inherits="WISLEY.collab" %>

<asp:Content ID="Content2" ContentPlaceHolderID="groupPosts" runat="server">
    <h3 class="font-weight-bold text-center">Collaboration Board</h3>
    <form runat="server">
        <div class="container">
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
                        <div class="col-lg-6 text-right">
                            <asp:Button CssClass="btn btn-success ml-auto" ID="btnpost" runat="server" Text="Post" OnClick="btnpost_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <% if (allPosts().Count > 0)
                { %>
            <div class="card mt-3">
                <% foreach (var post in allPosts())
                    { %>

                <div class="card-body">
                    <h4 class="card-title"><% =post.title %></h4>
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
                                    <i class="fas fa-clock mr-1"></i><span>Created on: <% =post.datecreated.ToShortDateString() %>
                                    </span>
                                </div>
                            </div>
                            <% =post.content %>
                        </div>
                    </div>
                    <hr />
                    <div class="row card-header border-0 font-weight-bold">
                        <div class="col-lg-6">
                            <%=allComments.Count.ToString() %> comment(s)
                        </div>
                        <div class="col-lg-6 text-right">
                            <asp:Button ID="btnView" CssClass="btn btn-sm btn-success" Text="View >>" runat="server" OnClick="btnView_Click" />
                        </div>
                    </div>
                    <hr />
                </div>


                <%} %>
            </div>
            <%} %><% else
                      { %>
            <div class="text-center mt-3">
                <h4 class="font-weight-bold">No Posts</h4>
            </div>
            <% } %>
        </div>
    </form>
</asp:Content>
