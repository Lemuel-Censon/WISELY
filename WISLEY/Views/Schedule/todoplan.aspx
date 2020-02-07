<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/sidebar.Master" AutoEventWireup="true" CodeBehind="todoplan.aspx.cs" Inherits="WISLEY.todoplan" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="card">
        <div class="card-body">
            <h3 class="text-center font-weight-bold">Add To-do-list</h3>

            <asp:Label ID="LblToDoDate" CssClass="font-weight-bold" runat="server" Text="Date selected: "></asp:Label>
            <asp:Label ID="LblSelectedDate" CssClass="font-weight-bold" runat="server"></asp:Label>
            <%--<asp:TextBox ID="tbSelectedDate" runat="server" CssClass="form-control"></asp:TextBox>--%>
            
            <div class="md-form md-outline">
                <asp:Label ID="LblToDoTitle" runat="server" AssociatedControlID="tbTitle" Text="Title"></asp:Label>
                <asp:TextBox ID="tbTitle" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="md-form md-outline">
                <asp:Label ID="LblToDoDesc" runat="server" AssociatedControlID="tbDesc" Text="Description"></asp:Label>
                <asp:TextBox ID="tbDesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="7"></asp:TextBox>
            </div>

            <div class="text-right">
                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-danger" OnClick="btnBack_Click" Text="Back" />
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click" Text="Add" />
            </div>
        </div>
    </div>
</asp:Content>
