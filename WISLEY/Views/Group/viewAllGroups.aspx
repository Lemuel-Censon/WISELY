<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="viewAllGroups.aspx.cs" Inherits="WISLEY.Views.Group.viewAllGroups" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <h1 class="col-12 text-center">View All Group</h1>
            <div class="col-6 card-body border border-primary">

                <div class="min-vh-30 max-vh-30 overflow-auto sortable">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <ajaxToolkit:ReorderList
                        ID="ReorderList1"
                        runat="server"
                        AllowReorder="True"
                        DragHandleAlignment="Left" ItemInsertLocation="Beginning"
                        DataSourceID="SQLgroupData" DataKeyField="groupID"
                        SortOrderField="customOrder"
                        PostBackOnReorder="False">
                        <DragHandleTemplate>
                            <div class="btn btn-danger">
                            </div>
                        </DragHandleTemplate>

                        <ItemTemplate>
                            <asp:LinkButton ID="grpBtns" runat="server" Text='<%#Eval("name")%>'
                                class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1" Style="text-transform: unset;" />
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

            </div>
        </div>
    </div>



</asp:Content>
