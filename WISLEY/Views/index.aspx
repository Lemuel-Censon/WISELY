<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WISLEY.index" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">

        <div class="row min-vh-80 mx-0">
            <div class="col-lg-6">
                <img src="<%= Page.ResolveUrl("~/Public/img/Teaching.png")%>" class="img-fluid min-vh-80 mt-n4 ml-3" alt="WISELY" />
            </div>
            <div class="col-lg-6">

                <div class="text-left py-5 px-4">
                    <div class="py-5">
                        <h2 class="h1-responsive mb-0 mb-md-2 text-primary">Welcome to WISELY</h2>
                        <p class="d-none d-md-block">WISELY is a platform for students and teachers to teach and learn in a fun way.</p>
                        <p class="d-none d-md-block">Join us today as a student or teacher for a fun experience in learning!</p>
                        <a class="btn btn-md btn-outline-info" href="<%= Page.ResolveUrl("~/Views/Auth/register.aspx") %>">
                            <i class="fas fa-user-plus mr-1"></i>Get Started
                        </a>
                    </div>
                </div>
            </div>
        </div>


        <div class="light-blue lighten-5 vh-50 pt-3">
            <h2 class="text-center font-weight-bold">Why WISELY?</h2>
            <div class="row mx-0">
                <div class="col-12 col-md-3 col-lg-4 d-flex align-items-stretch mt-4">
                    <div class="card w-100">
                        <div class="card-body d-flex flex-column">
                            <div class="d-flex mt-2">
                                <div class="flex-fill">
                                    <h4 class="card-title mb-0 font-weight-bold text-center">Collaboration</h4>
                                </div>
                            </div>
                            <hr class="w-100" />
                            <div class="flex-fill">
                                <p class="card-text font-weight-bold">Have a question but far away from teachers or friends?</p>
                                <p class="card-text">WISELY offers a collaboration board where students can post questions and obtain explanations through comments posted by others.</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-3 col-lg-4 d-flex align-items-stretch mt-4">
                    <div class="card w-100">
                        <div class="card-body d-flex flex-column">
                            <div class="d-flex mt-2">
                                <div class="flex-fill">
                                    <h4 class="card-title mb-0 font-weight-bold text-center">Schedule Planner</h4>
                                </div>
                            </div>
                            <hr class="w-100" />
                            <div class="flex-fill">
                                <p class="card-text font-weight-bold">Having trouble with time management?</p>
                                <p class="card-text">WISELY provides a schedule planner that lets you see upcoming events and plan your day.</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-3 col-lg-4 d-flex align-items-stretch mt-4">
                    <div class="card w-100">
                        <div class="card-body d-flex flex-column">
                            <div class="d-flex mt-2">
                                <div class="flex-fill">
                                    <h4 class="card-title mb-0 font-weight-bold text-center">Gacha</h4>
                                </div>
                            </div>
                            <hr class="w-100" />
                            <div class="flex-fill">
                                <p class="card-text font-weight-bold">It is difficult to be motivated to study.</p>
                                <p class="card-text">
                                    That's why we have come up with a Gacha that gives you avatars.
                                As you learn new content, points will be added to your profile. These points can then be used to pull from the Gacha.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
