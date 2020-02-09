<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="editGroup.aspx.cs" Inherits="WISLEY.Views.Group.editGroup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">


    <div class="container-fluid">
        <div class="row justify-content-around">
            <h1 class="col-12 text-center">Edit Group</h1>
            <div class="col-6 card-body border border-primary rounded z-depth-1">

                <div class="form-row justify-content-start mb-4">
                    <div class="col-2">
                        <label for="">Group Name</label>
                    </div>
                    <div class="col-10">
                        <asp:TextBox ID="groupNameTB" class="form-control" runat="server"></asp:TextBox>
                        <p class="small">This will be the name of your group </p>
                    </div>
                </div>

                <div class="form-row justify-content-start mb-4">
                    <div class="col-2">
                        <label for="groupDescriptionTB">Group Description</label>
                    </div>
                    <div class="col-10">
                        <asp:TextBox ID="groupDescriptionTB" TextMode="multiline" Columns="50" Rows="5" class="form-control" runat="server" MaxLength="300"></asp:TextBox>
                        <p class="small">Please tell us more about the group. </p>
                    </div>
                </div>


                <div class="row justify-content-end">
                                        <asp:Button ID="cancelBtn" runat="server" Text="Cancel" class="btn btn-danger" OnClick="redirectBack" />

                    <asp:Button ID="createGroupBtn" runat="server" Text="Update" class="btn btn-primary" OnClick="updateGroup" />

                </div>

            </div>


        </div>
                        <hr  class="col-12"/>

        <div class="row justify-content-center mt-4">
                            <h2 class="col-12 text-center">Disable Group </h2>

            <div class="col-6 card-body border border-primary rounded z-depth-1">
                <div class="row justify-content-center">
                <p class="text-center">
                    Disclaimer: Disabling the group will make the group hidden to students and they won't be able to access the group. Teachers are able to access the group and activate it.
                        Enabling the group makes the group visible to the student and give them access to its resources.

                </p>
                <asp:Button ID="diableGrpBtn" runat="server" Text="Disable Group" class="btn btn-danger"
                    data-toggle="modal" data-target="#disableGroupModal" OnClientClick="return false;" />
                    </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="disableGroupModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog " role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Disable Group Confirmation</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <% string grpName = getGroupDetails().name; %>
                    <p>Are you sure you want to disable <%= grpName %>?</p>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-white" data-dismiss="modal">Cancel</button>
                    <asp:Button ID="disableGroupBtn" runat="server" Text="Disable" class="btn btn-danger" OnClick="disableGroup" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
