<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="createGroup.aspx.cs" Inherits="WISLEY.Views.Group.createGroup" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <h1 class="col-12 text-center">Create Group</h1>
            <div class="col-6 card-body border border-primary">


                    <div class="form-row justify-content-start mb-4">
                        <div class="col-2">
                            <label for="groupNameTB">Group Name</label>
                        </div>
                        <div class="col-10">
                            <asp:TextBox ID="groupNameTB" class="form-control" runat="server"></asp:TextBox>
                            <%--<input type="text" id="groupName" class="form-control">--%>
                            <p class="small">This will be the name of your group </p>
                        </div>
                    </div>

                    <div class="form-row justify-content-start mb-4">
                        <div class="col-2">
                            <label for="groupDescriptionTB">Group Description</label>
                        </div>
                        <div class="col-10">
                            <asp:TextBox ID="groupDescriptionTB" TextMode="multiline" Columns="50" Rows="5" MaxLength="300" class="form-control" runat="server"></asp:TextBox>
                            <p class="small">Please tell us more about the group. </p>

                            <%--<textarea class="form-control rounded-0" id="groupDescription" rows="3" placeholder="">
                        </textarea>--%>
                        </div>
                    </div>

<%--                    <div class="form-row justify-content-start mb-4">
                        <div class="col-2">
                            <label for="groupWeightageTB">Group Weightage</label>
                        </div>
                        <div class="col-10">
                            <asp:TextBox ID="groupWeightageTB" class="form-control" runat="server"></asp:TextBox>
                            <p class="small">This is the point weightage of this module group</p>

                        </div>
                    </div>--%>


                    <div class="row justify-content-end">
                        <asp:Button ID="createGroupBtn" runat="server" Text="Create" class="btn btn-primary" OnClick="CreateGroup" />

                        <asp:Button ID="cancelBtn" runat="server" Text="Cancel" class="btn btn-danger" />


                    </div>

 
            </div>
        </div>
    </div>


</asp:Content>
