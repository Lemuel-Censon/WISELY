<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WISLEY.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="font-weight-bold text-center">Your Dashboard</h3>
    <form id="profile" runat="server" class="border">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-6">
                        <h3 class="font-weight-bold">John Smith </h3>
                        <p>@johnsmith </p>
                        <h5>Email: abc@mail.com </h5>
                        <h5>1 Blogs    51 Followers    51 Following </h5>
                    </div>
                    <div class="col-6 text-right">
                        <h5>420 WIS Points<img src="https://picsum.photos/50" class="col-1 img-fluid" style="width:60px;"></h5>
                        <h5 class="bg-info d-inline-block text-white" style="padding: 5px; border-radius: 10px; font-size: 15px;">Student</h5>
                    </div>
                    <div class="col-6">
                        <div class="progress">
                            <div class="progress-bar" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width:70%">
                                <span class="sr-only">70% Complete</span>
                            </div>
                        </div>
                    </div>
                    <div class="col-6 text-right">
                        <asp:Button CssClass="btn btn-primary ml-auto" ID="btneditProfile" runat="server" Text="Edit Profile" OnClick="btneditProfile_Click"/>
                    </div>
                </div>
            </div>
        </div>
            <div class="nav nav-tabs">
        <ul class="nav tabs-black rounded-0" id="myClassicTabShadow" role="tablist">
            <li class="nav-item m-0">
                <a class="nav-link waves-light active show" id="about-tab-classic-shadow" data-toggle="tab"
                    href="#about-classic-shadow" role="tab" aria-controls="about-classic-shadow"
                    aria-selected="true">About</a>
            </li>

            <li class="nav-item m-0">
                <a class="nav-link waves-light" id="msgwall-tab-classic-shadow" data-toggle="tab"
                    href="#msgwall-classic-shadow" role="tab" aria-controls="msgwall-classic-shadow"
                    aria-selected="true">Message Wall</a>
            </li>

            <li class="nav-item m-0">
                <a class="nav-link waves-light" id="friends-tab-classic-shadow" data-toggle="tab"
                    href="#friends-classic-shadow" role="tab" aria-controls="friends-classic-shadow"
                    aria-selected="true">Friends List</a>

            <li class="nav-item m-0">
                <a class="nav-link waves-light" id="blogs-tab-classic-shadow" data-toggle="tab"
                    href="#blogs-classic-shadow" role="tab" aria-controls="blogs-classic-shadow"
                    aria-selected="true">Blogs</a>
            </li>

            <li class="nav-item m-0">
                <a class="nav-link waves-light" id="badges-tab-classic-shadow" data-toggle="tab"
                    href="#badges-classic-shadow" role="tab" aria-controls="badges-classic-shadow"
                    aria-selected="true">Badges</a>
            </li>
        </ul>

        <div class="tab-content min-vh-80 p-0 border" id="myClassicTabContentShadow">
            <div class="tab-pane fade active show" id="about-classic-shadow" role="tabpanel"
                aria-labelledby="about-tab-classic-shadow">
                
                <div class="card card-body border-primary mx-5"> 
                    <div class="row justify-content-start">

                        <img src="https://picsum.photos/50" class="col-1 img-fluid">
                        <div class="col-3 align-content-center">
                            <h5 class=""> John Smith </h5>
                        </div>
                    </div>

                    <div class="row justify-content-start">
                        <p> Lorem ipsum dolor sit amet consectetur adipisicing elit. Molestias amet, cumque beatae vero facilis 
                        veritatis corporis nemo, quo culpa aliquid sapiente quasi hic sint doloremque aliquam? Quo consequuntur quis numquam?
                        </p>
                    </div>
                </div>
            </div>

            <div class="tab-pane fade" id="msgwall-classic-shadow" role="tabpanel"
                aria-labelledby="msgwall-tab-classic-shadow">
                My Message Wall
            </div>

            <div class="tab-pane fade" id="friends-classic-shadow" role="tabpanel"
                aria-labelledby="friends-tab-classic-shadow">
                My Friends
            </div>

            <div class="tab-pane fade" id="blogs-classic-shadow" role="tabpanel"
                aria-labelledby="blogs-tab-classic-shadow">
                My Blogs
            </div>

            <div class="tab-pane fade" id="badges-classic-shadow" role="tabpanel"
                aria-labelledby="msgwall-tab-classic-shadow">
                My Badges
            </div>
        </div>

    </div>
    </form>
</asp:Content>
