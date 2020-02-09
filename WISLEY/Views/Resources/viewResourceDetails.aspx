<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="viewResourceDetails.aspx.cs" Inherits="WISLEY.Views.Resources.viewResourceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid vh-90">
        <div class="row h-100">

            <% if(getFileInfo().Extension == ".pdf") { %>
            <%--            <% string filePath = getFilePath(); %>--%>
            <iframe runat="server" id="PDFiframe" class="col-9 border border-dark p-0 h-100"
                frameborder="0"></iframe>
            <% } 
            else if(getFileInfo().Extension == ".png" || getFileInfo().Extension == ".gif" || getFileInfo().Extension == ".jpg" || getFileInfo().Extension == ".jpeg") { %>
            <div class="col-9 align-content-between h-100">
                <div class="row justify-content-center h-100 overflow-auto">
                    <img runat="server" id="imgHolder" class="img-fluid mx-auto my-auto w-75"
                        frameborder="0" />
                </div>
            </div>
            <% } else { %>
            <div class="col-9 align-content-between h-100">
                <div class="row justify-content-center h-100 overflow-auto">
                    <img runat="server" id="fileImg" class="img-fluid mx-auto my-auto col-1 w-25"
                        frameborder="0" />
                    <h5 class="col-12 text-center">File Preview not available for this file</h5>
                </div>
            </div>
            <% } %>

            <div class="col-3 border-left border-primary z-depth-1 py-4 h-100">
                <div class="row mx-0 h-75">
                    <div>
                        <h2 class="text-center col-12">File Details </h2>
                        <hr class="col-12 hr-primary" />
                        <h5 class="col-12"><b>File Name:</b></h5>
                        <p class="col-12"> <%= getFileInfo().Name %></p>
                        <h5 class="col-12"><b>Group:</b></h5>
                        <p class="col-12"> <%= getGroupDetails().name %></p>
                        <h5 class="col-12"><b>Resource Type:</b></h5>
                        <p class="col-12"> <%= Request.QueryString["resourceType"] %></p>
                    </div>

                </div>

                <div class="row justify-content-around mx-0 h-10 pt-5">
                    <div class="col pt-5">
                        <button runat="server"
                            class="btn btn-sm btn-block btn-outline-primary text-left mb-1 text-center m-0"
                            onserverclick="backToResource">
                            Back
                        </button>
                    </div>
                    <div class="col pt-5">
                        <button runat="server"
                            class="btn btn-sm btn-block btn-outline-success text-left mb-1 text-center m-0"
                            onserverclick="downloadResource">
                            Download
                        </button>
                    </div>
                </div>




            </div>
        </div>

    </div>

    <%--     src="<%= Page.ResolveUrl("~/Public/uploads/groupResources/18/Practical/T06_Web_Service.pdf") %>" --%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
