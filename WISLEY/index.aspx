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
                    <img class="d-block w-100" src="https://picsum.photos/1600/600" alt="Posts" />
                </div>
                <div class="carousel-caption d-flex align-items-center">
                    <div class="animated fadeInDown mask rgba-black-light rounded z-depth-1 p-4 w-100">
                        <h1 class="h1-responsive mb-0 mb-md-2">Need help solving a difficult problem?</h1>
                        <p class="d-none d-md-block">
                            WISELY provides a posts system where you can post questions and get answers.
                        </p>
                    </div>
                </div>
            </div>
            <div class="carousel-item">
                <div class="view">
                    <img class="d-block w-100" src="https://picsum.photos/1600/600" alt="Schedule" />
                </div>
                <div class="carousel-caption d-flex align-items-center">
                    <div class="animated fadeInDown mask rgba-black-light rounded z-depth-1 p-4 w-100">
                        <h1 class="h1-responsive mb-0 mb-md-2">Have trouble managing your time?</h1>
                        <p class="d-none d-md-block">
                            Here at WISELY, you can plan your own schedule and see upcoming events.
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
                        <h1 class="h1-responsive mb-0 mb-md-2">Have no motivation?</h1>
                        <p class="d-none d-md-block">
                            WISELY offers an experience system and a gacha to motivate you to learn more.
                        </p>
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
</asp:Content>
