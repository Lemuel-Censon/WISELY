<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WISLEY.profile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hidotheremail" />
        <%if (LbEmail.Text == hidotheremail.Value)
            { %>
        <h3 class="font-weight-bold text-center">Your Dashboard</h3>
        <%} %>
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-4">
                        <div>
                            <img src="https://picsum.photos/120" class="mx-auto md-block">
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <h3 class="font-weight-bold">Bryan</h3>
                        <h5>Email: 
                        <asp:Label ID="LbEmail" runat="server"></asp:Label>
                        </h5>
                        <div class="row">
                            <div class="col-lg-4">
                                <asp:Label ID="LbNoOfBlogs" runat="server" Text="1"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text="Blog(s)"></asp:Label>
                            </div>
                            <div class="col-lg-4">
                                <asp:Label ID="LbFollowers" runat="server" Text="51"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text="Follower(s)"></asp:Label>
                            </div>
                            <div class="col-lg-4">
                                <asp:Label ID="LbFollowing" runat="server" Text="51"></asp:Label>
                                <asp:Label ID="Label3" runat="server" Text="Following"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 text-right">
                        <h5>420 WIS Points<img src="https://vignette.wikia.nocookie.net/brawlstars/images/e/e8/Star_Points.png/revision/latest?cb=20190827015915" class="img-fluid col-lg-1" style="width: 60px;"></h5>
                        <h5>Student</h5>
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
                <ul class="nav nav-pills" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" data-toggle="tab" href="#about">About</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#msgwall">Message Wall</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#friends">Friends List</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#posts">Posts</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#badges">Badges</a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div id="about" class="container tab-pane active">
                        <br>
                        <asp:Label ID="LbAbout" runat="server" Text="Tell us more about yourself!"></asp:Label>
                        <br />
                        <asp:Button CssClass="btn btn-primary p-2 ml-auto" ID="btnEditBio" runat="server" Text="Edit Bio" OnClick="btnEditBio_Click" />
                    </div>
                    <div id="msgwall" class="container tab-pane fade">
                        <br>
                        <asp:Label ID="LbMsgWall" runat="server" Text="Welcome to my message wall!"></asp:Label>
                        <br />
                        <asp:Button CssClass="btn btn-primary p-2 ml-auto" ID="btnEditCaption" runat="server" Text="Edit Caption" OnClick="btnEditCaption_Click" />
                    </div>
                    <div id="friends" class="container tab-pane fade">
                        <br>
                        <asp:Label ID="Label5" runat="server" Text="My Friends"></asp:Label>
                    </div>
                    <div id="posts" class="container tab-pane fade">
                        <br>
                        <asp:Label ID="Label6" runat="server" Text="My Posts"></asp:Label>
                    </div>
                    <div id="badges" class="container tab-pane fade">
                        <br>
                        <asp:Label ID="Label7" runat="server" Text="My Badges"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

