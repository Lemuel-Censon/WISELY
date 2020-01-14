<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="editGroup.aspx.cs" Inherits="WISLEY.Views.Group.editGroup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <h1 class="col-12 text-center">Edit Group</h1>
            <div class="col-6 card-body border border-primary">


                <div class="form-row justify-content-start mb-4">
                    <div class="col-2">
                        <label for="">Group Name</label>
                    </div>
                    <div class="col-10">
                        <% string grpName = getGroupDetails().name; %>
                        <p><%= grpName %></p>
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

                <div class="form-row justify-content-start mb-4">
                    <div class="col-2">
                        <label for="groupWeightageTB">Group Weightage</label>
                    </div>
                    <div class="col-10">
                        <asp:TextBox ID="groupWeightageTB" class="form-control" runat="server"></asp:TextBox>
                        <p class="small">This is the point weightage of this module group</p>

                    </div>
                </div>


                <div class="row justify-content-end">
                    <asp:Button ID="createGroupBtn" runat="server" Text="Update" class="btn btn-primary" OnClick="updateGroup"/>

                    <asp:Button ID="cancelBtn" runat="server" Text="Cancel" class="btn btn-danger" />


                </div>


            </div>
        </div>
    </div>
</asp:Content>
