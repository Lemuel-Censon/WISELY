<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="resourceUpload.aspx.cs" Inherits="WISLEY.Views.Resources.resourceUpload" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">

        <div class="row justify-content-center">
            <h1 class="col-12 text-center">Upload Resource</h1>
            <div class="col-7 card-body border border-primary">


                <div class="form-row justify-content-start mb-4">
                    <div class="col-3">
                        <label for="groupCodeTB">File: </label>
                    </div>
                    <div class="col-6">
                        <asp:FileUpload ID="resourceUploadController" runat="server" />
                        <p class="small">Please upload a file </p>  
                    </div>
                </div>

                <div class="form-row justify-content-start mb-4">
                    <div class="col-3">
                        <label for="groupCodeTB">File Resource Type: </label>
                    </div>
                    <div class="col-4">
                        <asp:DropDownList runat="server" ID="ddlResourceType" Visible="true" 
                            onselectedindexchanged ="onSelectResourceType"
                            AutoPostBack="True" CssClass="custom-select"></asp:DropDownList>
                        <p class="small">Place file in existing resource type </p>
                    </div>
                    <div class="col-1 row justify-content-center">
                        <p class="mt-1">or</p>
                        
                    </div>

                    <div class="col-4">
                        <asp:TextBox ID="newResourceGroupTB" class="form-control" runat="server"></asp:TextBox>
                        <p class="small">Create a new resource type </p>
                    </div>
                </div>



                <div class="row justify-content-end">
                    <asp:Button ID="cancelBtn" runat="server" Text="Cancel" class="btn btn-danger" OnClick="backToViewResources" />
                    <asp:Button ID="createGroupBtn" runat="server" Text="Upload" class="btn btn-primary" OnClick="uploadResource" />
                </div>


            </div>
        </div>

    </div>
</asp:Content>
