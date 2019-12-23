<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WISLEY.index" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div id="carousel" class="carousel slide carousel-fade z-depth-3">
        <div class="carousel-inner" role="listbox">
            <div class="carousel-item active">
                <div class="view">
                    <img class="d-block w-100" src="https://picsum.photos/1600/600" alt="Learning" />
                </div>
                <div class="carousel-caption d-flex align-items-center">
                    <div class="animated fadeInDown mask rgba-black-light rounded z-depth-1 p-4 w-100">
                        <h1 class="h1-responsive mb-0 mb-md-2">Welcome to WISELY</h1>
                        <p class="d-none d-md-block">
                            A platform for students and teachers to learn and teach in a fun way.
                        </p>
                    </div>
                </div>
            </div>
            <div class="carousel-item">
                <div class="view">
                    <img class="d-block w-100" src="https://picsum.photos/1600/600" alt="Gacha" />
                </div>
                <div class="carousel-caption d-flex align-items-center">
                    <div class="animated fadeInDown mask rgba-black-light rounded z-depth-1 p-4 w-100">
                        <h1 class="h1-responsive mb-0 mb-md-2">Register on WISELY</h1>
                        <p class="d-none d-md-block">
                            Join us today as a Student or Teacher for a fun experience in learning!
                        </p>

                        <a class="btn btn-md btn-info" href="register.aspx">
                            <i class="fas fa-user-plus mr-1"></i>Get Started
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#carousel" role="button" data-slide="prev">
            <i class="fas fa-chevron-left fa-lg"></i>
        </a>
        <a class="carousel-control-next" href="#carousel" role="button" data-slide="next">
            <i class="fas fa-chevron-right fa-lg"></i>
        </a>
    </div>
    <div class="mt-3">
        <h1 class="text-center font-weight-bold">Why WISELY?</h1>
        <div class="row">
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
