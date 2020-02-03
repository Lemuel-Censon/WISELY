<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/sidebar.Master" AutoEventWireup="true" CodeBehind="todoplan.aspx.cs" Inherits="WISLEY.todoplan" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="card">
        <div class="card-body">
            <h3 class="text-center font-weight-bold">Add To-do-list</h3>

            <asp:Label ID="LblToDoDate" runat="server" Text="Date selected: "></asp:Label>
            <asp:Label ID="LblSelectedDate" runat="server"></asp:Label>
            <%--<asp:TextBox ID="tbSelectedDate" runat="server" CssClass="form-control"></asp:TextBox>--%>
            
            <div class="md-form md-outline">
                <asp:Label ID="LblToDoTitle" runat="server" AssociatedControlID="tbTitle" Text="Title"></asp:Label>
                <asp:TextBox ID="tbTitle" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="md-form md-outline">
                <asp:Label ID="LblToDoDesc" runat="server" AssociatedControlID="tbDesc" Text="Description"></asp:Label>
                <asp:TextBox ID="tbDesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="7"></asp:TextBox>
            </div>

            <div class="row">
                <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#exitModal">Back</button>
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click" Text="Add" />
            </div>

            <div id="exitModal" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Are you sure you want to go back?</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>

                        <div class="modal-body text-center">
                            Once you exit out of this page, all unsave inputs will be gone!
                        </div>

                        <div class="modal-footer">
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-danger btn-sm" OnClick="btnBack_Click" Text="Yes" />
                            <asp:Button ID="btnSaveInputs" runat="server" CssClass="btn btn-info btn-sm" Text="Save inputs" OnClick="btnSaveInputs_Click" />
                            <button type="button" class="btn btn-secondary btn-sm" data-dismiss="modal">Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
