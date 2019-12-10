<%@ Page Title="" Language="C#" MasterPageFile="~/sidebar.Master" AutoEventWireup="true" CodeBehind="collab.aspx.cs" Inherits="WISLEY.collab" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sidebarContent" runat="server">
    <h3 class="font-weight-bold text-center">Collaboration Board</h3>
    <form runat="server">
        <div class="card">
            <div class="card-body">
                <label for="tbtitle">Post title: </label>
                <asp:TextBox ID="tbtitle" runat="server" CssClass="form-control"></asp:TextBox>
                <hr />
                <label for="tbcontent">Description: </label>
                <asp:TextBox ID="tbcontent" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="6"></asp:TextBox>
                <div class="row">
                    <div class="col-lg-6">
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="col-lg-6 text-right">
                        <asp:Button CssClass="btn btn-success ml-auto" ID="btnpost" runat="server" Text="Post" OnClick="btnpost_Click" />
                    </div>
                </div>
            </div>
        </div>
        <% if (allPosts.Count > 0)
            { %>
        <% foreach (var post in allPosts)
            { %>
        <div class="card mt-3">
            <div class="card-body">
                <h4 class="card-title"><% =post.title %></h4>
                <p class="card-text">By: </p>
                <i class="far fa-clock"></i><span>Created on: <% =post.datecreated.ToShortDateString() %></span>
                <hr />
                <p class="card-text"><% =post.content %></p>
            </div>
        </div>

        <%} %>

        <%} %>
        <% else
        { %>
        <div class="text-center mt-3">
            <h4 class="font-weight-bold">No posts</h4>
        </div>
        <% } %>
    </form>
</asp:Content>
