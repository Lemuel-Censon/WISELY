<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="members.aspx.cs" Inherits="WISLEY.Views.Group.members" %>

<asp:Content ID="Content4" ContentPlaceHolderID="groupMembers" runat="server">
    <div class="container">


    <asp:Repeater
        runat="server" ID="memberList" DataSourceID="memberData"
        >
        <ItemTemplate>
            <div class="row justify-content-start p-1 py-3 m-2 border border-rounded border-light">
                <div class="col-2">
                    <img src="https://picsum.photos/100" />
                </div>

                <div class="col-10">
                    <h3 class=""> <%#Eval("name")%> </h3>
                    <h5> <%# Eval("accType") %> </h5>
                </div>

            </div>
        </ItemTemplate>
    </asp:Repeater>


    <asp:SqlDataSource ID="memberData"
        ConnectionString="<%$ connectionStrings: ConnStr%>"
        runat="server"></asp:SqlDataSource>
    </div>
</asp:Content>
