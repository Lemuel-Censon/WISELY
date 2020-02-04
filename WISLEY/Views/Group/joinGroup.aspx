<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="joinGroup.aspx.cs" Inherits="WISLEY.Views.Group.joinGroup" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">

    <div class="container-fluid">
        <div class="row justify-content-center">
            <h1 class="col-12 text-center">Join Group</h1>
            <div class="col-6 card-body border border-primary">


                <div class="form-row justify-content-start mb-4">
                    <div class="col-2">
                        <label for="groupCodeTB">Group Code</label>
                    </div>
                    <div class="col-10">
                        <asp:TextBox ID="groupCodeTB" class="form-control" runat="server"></asp:TextBox>
                        <p class="small">Please enter the code of the group you want to join </p>
                    </div>
                </div>

                <div class="row justify-content-end">
                    <asp:Button ID="cancelBtn" runat="server" Text="Cancel" class="btn btn-danger" OnClick="back"/>
                    <asp:Button ID="createGroupBtn" runat="server" Text="Join" class="btn btn-primary" OnClick="join" />
                </div>


            </div>
        </div>
    </div>

</asp:Content>
