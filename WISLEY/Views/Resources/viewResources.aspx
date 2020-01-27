<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="viewResources.aspx.cs" Inherits="WISLEY.Views.Resources.viewResources" %>

<asp:Content ID="Content2" ContentPlaceHolderID="groupResources" runat="server">

    <% if (Request.QueryString["groupId"] != null)
        {
            string grpName = getGroupDetails().name;
            string grpDesc = getGroupDetails().description;
            string grpCode = getGroupDetails().joinCode;
            string grpId = getGroupDetails().id.ToString();
        }
    %>

    <div class="container-fluid">
    <h1> Test 1 2 3 </h1>
    <a class="btn btn-light" href="<%= Page.ResolveUrl("~/Views/Resources/resourceUpload.aspx?groupId=" + getGroupDetails().id.ToString())%>"> Upload Resource </a>
    

    </div>


</asp:Content>

