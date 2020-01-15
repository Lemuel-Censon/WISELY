<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WISLEY.profile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hidotheremail" />
    <h3 class="font-weight-bold text-center"><%if (LbEmail.Text == hidotheremail.Value)
                                                 { %>Your Profile<%} %></h3>
    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col-lg-4">
                    <div>
                        <img src="https://picsum.photos/120" class="mx-auto md-block">
                    </div>
                </div>
                <div class="col-lg-4">
                    <h3 class="font-weight-bold">
                        <asp:Label ID="LbName" runat="server"></asp:Label>
                    </h3>
                    <%
                        if (LbEmail.Text == hidotheremail.Value || LbPrivacy.Text == "Privacy is Off")
                        { %>
                    <h5>
                        <asp:Label ID="LbEmail" runat="server"></asp:Label>
                    </h5>
                    <div>
                        <asp:Label ID="LbDob" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="LbContact" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <asp:Label ID="LbNoOfBlogs" runat="server" Text="0"></asp:Label>
                            <asp:Label ID="Label1" runat="server" Text="Blogs"></asp:Label>
                        </div>
                        <div class="col-lg-4">
                            <asp:Label ID="LbFollowers" runat="server" Text="0"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text="Followers"></asp:Label>
                        </div>
                        <div class="col-lg-4">
                            <asp:Label ID="LbFollowing" runat="server" Text="0"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="Following"></asp:Label>
                        </div>
                    </div>
                    <%}
                        else
                        { %>
                    <div>
                        <h3><i class="fas fa-lock mr-1"></i>Account is private!</h3>
                    </div>
                    <% } %>
                </div>
                <div class="col-lg-4 text-right">
                    <h5>
                        <asp:Label ID="LbWISPoints" runat="server"></asp:Label><img src="https://vignette.wikia.nocookie.net/brawlstars/images/e/e8/Star_Points.png/revision/latest?cb=20190827015915" class="img-fluid col-lg-1" style="width: 60px;"></h5>
                    <h5 class="font-weight-bold">
                        <asp:Label runat="server" ID="LbType"></asp:Label></h5>
                    <h5>
                        <asp:Label ID="LbPrivacy" runat="server" Visible="false"></asp:Label>
                    </h5>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 mt-3">
                    <h5>Level 1 Newbie</h5>
                    <div class="progress">
                        <div class="progress-bar bg-success" role="progressbar" aria-valuenow="69" aria-valuemin="0" aria-valuemax="100" style="width: 69%">
                            69/100 XP
                        </div>
                    </div>
                </div>
                <%if (LbEmail.Text == hidotheremail.Value)
                    { %>
                <div class="col-lg-6 text-right">
                    <asp:Button CssClass="btn btn-sm btn-info" ID="btnchangeAvatar" runat="server" Text="Change Avatar" OnClick="btnchangeAvatar_Click" />
                    <asp:Button CssClass="btn btn-sm btn-info" ID="btneditProfile" runat="server" Text="Edit Profile" OnClick="btneditProfile_Click" />
                </div>
                <%} %>
            </div>
        </div>
    </div>
    <br />
    <div class="row mt-3">
        <div class="col-lg-4">
            <div class="card">
                <div class="card-body">
                    <h3 class="font-weight-bold text-center col-12">Quick Links</h3>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/index.aspx") %>"><i class="fas fa-home mr-1"></i>Home</a>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/Resources/resource.aspx") %>"><i class="fas fa-graduation-cap mr-1"></i>My Grades</a>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/Schedule/schedule.aspx") %>"><i class="fas fa-calendar-alt mr-1"></i>My Calendar</a>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/Resources/resource.aspx") %>"><i class="fas fa-code mr-1"></i>My Resources</a>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/Board/collab.aspx") %>"><i class="fas fa-users mr-1"></i>My Groups</a>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/Gacha/gacha.aspx") %>"><i class="fas fa-portrait mr-1"></i>Gacha</a>
                </div>
            </div>
        </div>
        <div class="col-lg-8">
            <ul class="nav nav-tabs" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" role="tab" data-toggle="tab" href="#about">About</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" role="tab" data-toggle="tab" href="#msgwall">Message Wall</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" role="tab" data-toggle="tab" href="#friends">Friends List</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" role="tab" data-toggle="tab" href="#posts">Posts</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" role="tab" data-toggle="tab" href="#badges">Badges</a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="about" class="tab-pane fade show active m-2 ml-2" role="tabpanel">
                    Currently Empty
                        <%if (LbEmail.Text == hidotheremail.Value)
                            { %>
                    <asp:Button CssClass="btn btn-sm btn-info" ID="btnEditBio" runat="server" Text="Edit Bio" OnClick="btnEditBio_Click" />
                    <%} %>
                </div>
                <div id="msgwall" class="tab-pane fade m-2 ml-2" role="tabpanel">
                    Currently Empty
                        <%if (LbEmail.Text == hidotheremail.Value)
                            { %>
                    <asp:Button CssClass="btn btn-sm btn-info" ID="btnEditCaption" runat="server" Text="Edit Caption" OnClick="btnEditCaption_Click" />
                    <%} %>
                </div>
                <div id="friends" class="tab-pane fade m-2 ml-2" role="tabpanel">
                    Currently Empty
                </div>
                <div id="posts" class="tab-pane fade m-2 ml-2" role="tabpanel">
                    <%if (postcount() > 0)
                        { %>
                    <asp:Repeater runat="server" ID="userpost" DataSourceID="userpostdata">
                        <ItemTemplate>
                            <div class="card-body">
                                <h4 class="card-title d-inline"><%#Eval("title") %></h4>
                                <div class="media mt-4 px-1">
                                    <img class="card-img-100 d-flex z-depth-1 mr-3" src="https://picsum.photos/100"
                                        alt="Generic placeholder image">
                                    <div class="media-body">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <h5 class="font-weight-bold mt-0">
                                                    <asp:LinkButton runat="server" ID="postlink"><%#Eval("userId") %></asp:LinkButton>
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
                                <hr />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:SqlDataSource runat="server" ID="userpostdata" ConnectionString="<%$ connectionStrings: ConnStr%>"></asp:SqlDataSource>
                    <%} %>
                    <%else
                        { %>Currently Empty
                        <%} %>
                </div>
                <div id="badges" class="tab-pane fade m-2 ml-2" role="tabpanel">
                    Currently Empty
                </div>
            </div>
        </div>
    </div>
</asp:Content>

