<%@ Page Title="" Language="C#" MasterPageFile="~/sidebar.Master" AutoEventWireup="true" CodeBehind="group.aspx.cs" Inherits="WISLEY.group" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="card card-body border-primary rounded-top mb-3">
        <div class="row justify-content-center">
            <h1 class="text-center">Test </h1>
        </div>

    </div>


    <ul class="nav nav-tabs" id="myClassicTabShadow" role="tablist">
        <li class="nav-item">
            <a class="nav-link waves-light active show" id="posts-tab-classic-shadow" data-toggle="tab"
                href="#posts-classic-shadow" role="tab" aria-controls="posts-classic-shadow"
                aria-selected="true">Posts</a>
        </li>

        <li class="nav-item">
            <a class="nav-link" id="resources-tab-classic-shadow" data-toggle="tab"
                href="#resources-classic-shadow" role="tab" aria-controls="resources-classic-shadow"
                aria-selected="true">Resources</a>
        </li>

        <li class="nav-item">
            <a class="nav-link" id="assignments-tab-classic-shadow" data-toggle="tab"
                href="#assignments-classic-shadow" role="tab" aria-controls="assignments-classic-shadow"
                aria-selected="true">Assignments</a>

        <li class="nav-item">
            <a class="nav-link" id="members-tab-classic-shadow" data-toggle="tab"
                href="#members-classic-shadow" role="tab" aria-controls="members-classic-shadow"
                aria-selected="true">Members</a>
        </li>
    </ul>

    <div class="tab-content min-vh-80 border" id="myClassicTabContentShadow">
        <div class="tab-pane fade active show" id="posts-classic-shadow" role="tabpanel"
            aria-labelledby="posts-tab-classic-shadow">

            <div class="card card-body border-primary mx-5">
                <div class="row justify-content-start">

                    <img src="https://picsum.photos/50" class="col-1 img-fluid">
                    <div class="col-3 align-content-center">
                        <h5 class="">John Smith </h5>
                    </div>
                </div>

                <div class="row justify-content-start">
                    <p>
                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Molestias amet, cumque beatae vero facilis 
                        veritatis corporis nemo, quo culpa aliquid sapiente quasi hic sint doloremque aliquam? Quo consequuntur quis numquam?
                    </p>
                </div>
            </div>
        </div>

        <div class="tab-pane fade" id="resources-classic-shadow" role="tabpanel"
            aria-labelledby="resources-tab-classic-shadow">
            Hi
            <% foreach (var site in Sites) { %>
            <!-- loop through the list -->
            <div>
                <%= site %>
                <!-- write out the name of the site -->
            </div>
            <% } %>
            <!--End the for loop -->
        </div>

        <div class="tab-pane fade" id="assignments-classic-shadow" role="tabpanel"
            aria-labelledby="assignments-tab-classic-shadow">
            Hi
        </div>

        <div class="tab-pane fade" id="members-classic-shadow" role="tabpanel"
            aria-labelledby="members-tab-classic-shadow">
            Hi
        </div>
    </div>



</asp:Content>
