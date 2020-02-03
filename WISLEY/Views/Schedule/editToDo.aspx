<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/sidebar.Master" AutoEventWireup="true" CodeBehind="editToDo.aspx.cs" Inherits="WISLEY.Views.Schedule.editToDo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="card">
        <div class="card-body">
            <h3 class="text-center font-weight-bold">Edit To-do-list</h3>
            <asp:HiddenField runat="server" ID="todoID" />

            <asp:Label ID="LblToDoDate" runat="server" Text="Date selected: "></asp:Label>
            <asp:Label ID="LblSelectedDate" runat="server"></asp:Label>
            <%--<asp:TextBox ID="tbSelectedDate" runat="server" CssClass="form-control"></asp:TextBox>--%>
            
            <div class="md-form md-outline">
                <asp:Label ID="LblToDoTitle" runat="server" AssociatedControlID="tbEditTitle" Text="Title"></asp:Label>
                <asp:TextBox ID="tbEditTitle" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="md-form md-outline">
                <asp:Label ID="LblToDoDesc" runat="server" AssociatedControlID="tbEditDesc" Text="Description"></asp:Label>
                <asp:TextBox ID="tbEditDesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="7"></asp:TextBox>
            </div>

            <div class="row">
                <asp:Button runat="server" ID="btnBack" CssClass="btn btn-danger" OnClick="btnBack_Click" Text="Back" />
                <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="Update" />
            </div>
        </div>
    </div>
</asp:Content>
