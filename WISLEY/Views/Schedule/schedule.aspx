<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="schedule.aspx.cs" Inherits="WISLEY.Views.Schedule.schedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="groupPosts" runat="server">
    <link rel="stylesheet" type="text/css" href="<%= Page.ResolveUrl("~/Public/css/planner.css") %>" />

    <div class="col-12">
        <div class="card">
            <div class="card-body m-0 m-auto">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <h3 class="text-center font-weight-bold">My Calendar</h3>
                        <asp:Calendar ID="calendarPlan" CssClass="planner" runat="server" BackColor="White" BorderColor="Black" Font-Names="Arial Black" ForeColor="Black" Height="430px" Width="690px" ShowGridLines="True" OnSelectionChanged="calendarPlan_SelectionChanged" OnDayRender="calendarPlan_DayRender">
                            <DayHeaderStyle BackColor="#CCCCCC" CssClass="plannerDay" Font-Bold="True" ForeColor="#333333" Height="10pt" VerticalAlign="Middle" />
                            <DayStyle Width="14%" Font-Bold="True" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="Black" Font-Bold="True" />
                            <OtherMonthDayStyle ForeColor="#999999" Font-Bold="False" />
                            <SelectedDayStyle BackColor="#1F78C0" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                            <TitleStyle BackColor="#4CCAEF" Font-Bold="True" Font-Size="13pt" ForeColor="Black" Height="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <TodayDayStyle BackColor="#4899E1" Font-Bold="True" />
                            <WeekendDayStyle Font-Bold="True" ForeColor="Red" />
                        </asp:Calendar>
                    </div>
                </div>
            </div>
        </div>

        <br />

        <div class="card">
            <div class="card-body">
                <h4 class="text-center font-weight-bold">Your To-Do-Lists</h4>
                <p class="text-center font-weight-bold">Total To-do-lists: <%=ToDoListcount().ToString() %></p>
                
                <%--<label class="switch">
                    <input type="checkbox" />
                    <div class="slider"></div>
                </label>--%>

                <div class="input-group md-form md-outline">
                    <input type="text" id="search" class="form-control" placeholder="Find by Title" />
                    <div class="input-group-append">
                        <button type="button" class="btn btn-md btn-info m-0 px-3 py-2 waves-effect" id="btnSearch"><i class="fas fa-search"></i></button>
                    </div>
                </div>

                <asp:Repeater ID="todolistRepeater" runat="server" OnItemCommand="todolist_ItemCommand" OnItemDataBound="todolistRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="card plannerCards">
                            <div class="card-body">
                                <p class="card-title font-weight-bold plannerTitle" data-pname="<%#Eval("todoTitle") %>"><%#Eval("todoTitle") %></p>
                                <hr />
                                <div class="row">
                                    <div class="col-lg-6">
                                        <p class="card-text"><%#Eval("todoDescription") %></p>
                                    </div>
                                    <div class="col-lg-6">
                                        <i class="fas fa-clock mr-1"></i><span><%#Eval("todoDate") %></span>
                                    </div>
                                </div>
                                <hr />
                                <div class="text-right">
                                    <button type="button" id="btnDel" class="btn btn-danger btn-sm" data-toggle="modal" data-target="#deleteModal<%#Eval("Id") %>">Delete</button>
                                    <asp:LinkButton runat="server" ID="btnEdit" CssClass="btn btn-info btn-sm" Text="Edit" CommandName="edit" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                </div>

                                <div class="modal fade" id="deleteModal<%#Eval("Id") %>" tabindex="-1" role="dialog" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title">Are you sure you want to delete this to-do-list?</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>

                                            <div class="modal-body text-center">
                                                Deletion of this to-do-list cannot be reverted once confirmed!
                                            </div>

                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-sm btn-danger" data-dismiss="modal">No</button>
                                                <asp:LinkButton runat="server" CommandName="delToDo" CommandArgument='<%#Eval("Id") %>' ID="btnDelete" Text="Yes" CssClass="btn btn-sm btn-success"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="text-center mb-4">
                            <h4>
                                <asp:Label runat="server" ID="LbErr" Text="No Plans at the moment" CssClass="font-weight-bold" Visible="false"></asp:Label>
                            </h4>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <script src="<%= Page.ResolveUrl("~/Public/js/planners.js") %>" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="groupResources" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="groupAssignments" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="groupMembers" runat="server">
</asp:Content>
