<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WISLEY.profile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <form id="form1" class="col-12 row justify-content-around" runat="server">
        <h3 class="font-weight-bold text-center col-12">Your Dashboard</h3>
        <div class="card col-7 border border-danger'">
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-4">
                        <div class="col-lg-12">
                            <img src="https://picsum.photos/100" class="mx-auto md-block" style="width: 160px; float: left;">
                        </div>
                        <div class="col-lg-12 text-center">
                            <asp:Button CssClass="btn btn-primary p-2 ml-auto" ID="btnchangeAvatar" runat="server" Text="Change Avatar" OnClick="btnchangeAvatar_Click" />
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
                        <asp:Button CssClass="btn btn-primary p-2 ml-auto" ID="btneditProfile" runat="server" Text="Edit Profile" OnClick="btneditProfile_Click" />
                    </div>
                </div>
            </div>
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
                    <a class="nav-link" data-toggle="tab" href="#blogs">Blogs</a>
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
                <div id="blogs" class="container tab-pane fade">
                    <br>
                    <asp:Label ID="Label6" runat="server" Text="My Blogs"></asp:Label>
                </div>
                <div id="badges" class="container tab-pane fade">
                    <br>
                    <asp:Label ID="Label7" runat="server" Text="My Badges"></asp:Label>
                </div>
            </div>
        </div>
        <div class="col-5 border border-danger">
            <h3 class="font-weight-bold text-center col-12">Quick Links</h3>
        </div>

    </form>
</asp:Content>
