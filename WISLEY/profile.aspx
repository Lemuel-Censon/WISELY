<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WISLEY.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" class="col-12 row justify-content-around" runat="server">
        <h3 class="font-weight-bold text-center col-12">Your Dashboard</h3>
        <div class="card col-12 p-1">
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-4">
                        <div>
                            <img src="https://picsum.photos/100" class="mx-auto md-block" style="width: 160px; float: left;">
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <h3 class="font-weight-bold">John Smith </h3>
                        <p>
                            <asp:Label ID="LbUsername" runat="server" Text="@johnsmith"></asp:Label>
                        </p>
                        <h5>Email: 
                        <asp:Label ID="LbEmail" runat="server" Text="abc@mail.com"></asp:Label>
                        </h5>
                        <p style="width: 300px;">
                            <asp:Label ID="LbNoOfBlogs" runat="server" Text="1"></asp:Label>
                            <asp:Label ID="Label1" runat="server" Text="Blogs"></asp:Label>
                            &nbsp;&nbsp;
                        <asp:Label ID="LbFollowers" runat="server" Text="51"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text="Followers"></asp:Label>
                            &nbsp;&nbsp;
                        <asp:Label ID="LbFollowing" runat="server" Text="51"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="Following"></asp:Label>
                        </p>

                    </div>
                    <div class="col-lg-4 text-right">
                        <h5>420 WIS Points<img src="https://vignette.wikia.nocookie.net/brawlstars/images/e/e8/Star_Points.png/revision/latest?cb=20190827015915" class="col-lg-1 img-fluid" style="width: 60px;"></h5>
                        <h5 class="bg-info d-inline-block text-white" style="padding: 5px; border-radius: 10px; font-size: 15px;">Student</h5>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 mt-1">
                        <h5>Level 1: Rank Newbie</h5>
                        <div class="progress">
                            <div class="progress-bar progress-bar-striped progress-bar-animated bg-success" role="progressbar" aria-valuenow="69" aria-valuemin="0" aria-valuemax="100" style="width: 69%">
                                69/100 XP
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 text-right">
                        <asp:Button CssClass="btn btn-primary p-2 ml-auto" ID="btnchangeAvatar" runat="server" Text="Change Avatar" OnClick="btnchangeAvatar_Click" />
                        <asp:Button CssClass="btn btn-primary p-2 ml-auto" ID="btneditProfile" runat="server" Text="Edit Profile" OnClick="btneditProfile_Click" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="col-4 p-2">
            <div class="card-body">
                <h3 class="font-weight-bold text-center col-12">Quick Links</h3>
                <ul style="list-style-type: none; line-height: 4;">
                    <li><a href="index.aspx"><i class="fa fa-home"></i>&nbsp;Home Page</a></li>
                    <li><a href="index.aspx"><i class="fa fa-graduation-cap"></i>&nbsp;My Grades</a></li>
                    <li><a href="index.aspx"><i class="fa fa-calendar"></i>&nbsp;My Calendar</a></li>
                    <li><a href="index.aspx"><i class="fa fa-code"></i>&nbsp;My Resources</a></li>
                    <li><a href="index.aspx"><i class="fa fa-group"></i>&nbsp;My Groups</a></li>
                    <li><a href="index.aspx"><i class="fa fa-photo"></i>&nbsp;Gacha</a></li>
                </ul>
            </div>
        </div>
        <div class="col-8 p-2">
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
                </div>
                <div id="msgwall" class="container tab-pane fade">
                    <br>
                    <asp:Label ID="Label4" runat="server" Text="My Message Wall"></asp:Label>
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
    </form>
</asp:Content>
