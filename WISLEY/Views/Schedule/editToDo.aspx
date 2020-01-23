<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/sidebar.Master" AutoEventWireup="true" CodeBehind="editToDo.aspx.cs" Inherits="WISLEY.Views.Schedule.editToDo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="card">
        <div class="card-body">
            <h3 class="text-center font-weight-bold">Edit To-do-list</h3>

            <asp:Label ID="LblToDoDate" runat="server" CssClass="font-weight-bold" Text="Date selected for your to-do-list: "></asp:Label>
            <asp:Label ID="LblSelectedDate" runat="server" CssClass="font-weight-bold"></asp:Label>
            <%--<asp:TextBox ID="tbSelectedDate" runat="server" CssClass="form-control"></asp:TextBox>--%>
            
            <div class="md-form md-outline">
                <asp:Label ID="LblToDoTitle" runat="server" AssociatedControlID="tbEditTitle" CssClass="font-weight-bold" Text="Title of your to-do-list"></asp:Label>
                <asp:TextBox ID="tbEditTitle" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="md-form md-outline">
                <asp:Label ID="LblToDoDesc" runat="server" AssociatedControlID="tbEditDesc" CssClass="font-weight-bold" Text="Description of your to-do-list"></asp:Label>
                <asp:TextBox ID="tbEditDesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="7"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
