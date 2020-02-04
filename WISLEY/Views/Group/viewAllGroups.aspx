<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="viewAllGroups.aspx.cs" Inherits="WISLEY.Views.Group.viewAllGroups" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <h1 class="col-12 text-center">View All Group</h1>
            <div class="col-6 card-body border border-primary">

                <div id="reorderListDiv" class="min-vh-30 max-vh-30 overflow-auto">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <ajaxToolkit:ReorderList
                        ID="AllGroupReorderList"
                        runat="server"
                        AllowReorder="True"
                        DragHandleAlignment="Left" ItemInsertLocation="Beginning"
                        DataSourceID="SQLgroupData" DataKeyField="groupID"
                        SortOrderField="customOrder"
                        PostBackOnReorder="False"
                        >

                        <DragHandleTemplate>
                            <div>
                                <i class="fas fa-bars"></i>

                            </div>
                        </DragHandleTemplate>

                        <ItemTemplate>
                            <asp:LinkButton ID="grpBtns" runat="server" Text='<%#Eval("name")%>'
                                Style="text-transform: unset;" />
                        </ItemTemplate>
                    </ajaxToolkit:ReorderList>

                </div>

                <asp:SqlDataSource ID="SQLgroupData"
                    ConnectionString="<%$ connectionStrings: ConnStr%>"
                    OldValuesParameterFormatString="original_{0}"
                    runat="server"
                    UpdateCommand='UPDATE [GroupUserRelations] SET [customOrder] = @customOrder WHERE [groupID] = @original_groupID'>

                    <UpdateParameters>
                        <asp:Parameter Name="userEmail" Type="String" />
                        <asp:Parameter Name="show" Type="Int32" />
                        <asp:Parameter Name="customOrder" Type="Int32" />
                        <asp:Parameter Name="original_groupID" Type="Int32" />
                    </UpdateParameters>


                </asp:SqlDataSource>
                <asp:Button ID="cancelBtn" runat="server" Text="Back" class="btn btn-primary" OnClick="back" />

            </div>
        </div>
    </div>

    <script>
        $("#contentHolder1_AllGroupReorderList__rbl").addClass("list-group")
        $("#contentHolder1_AllGroupReorderList__rbl").children().addClass("btn btn-white list-item")
    </script>

</asp:Content>
