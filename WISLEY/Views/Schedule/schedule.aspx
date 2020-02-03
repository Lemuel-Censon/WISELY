<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/sidebar.master" AutoEventWireup="true" CodeBehind="schedule.aspx.cs" Inherits="WISLEY.Views.Schedule.schedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="col-12 border border-secondary">
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
                
                <div class="input-group md-form md-outline">
                    <input type="text" id="search" class="form-control" placeholder="Find by Title" />
                    <div class="input-group-append">
                        <button type="button" class="tn btn-md btn-info m-0 px-3 py-2 waves-effect" id="btnSearch"><i class="fas fa-search"></i></button>
                    </div>
                </div>

                <asp:Repeater ID="todolistRepeater" runat="server" OnItemCommand="todolist_ItemCommand" OnItemDataBound="todolistRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="card plannerCards">
                            <div class="card-body">
                                <p class="card-title font-weight-bold plannerTitle">Title: <%#Eval("todoTitle") %></p>
                                <hr />
                                <div class="row">
                                    <div class="col-lg-6">
                                        <p class="card-text">Description: <%#Eval("todoDescription") %></p>
                                    </div>
                                    <div class="col-lg-6">
                                        <i class="fas fa-clock mr-1"></i><span>Date: <%#Eval("todoDate") %></span>
                                    </div>
                                </div>
                                <div class="text-right">
                                    <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="delete" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnEdit" CssClass="btn btn-info btn-sm" Text="Edit" CommandName="edit" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
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

    <script src="<%= Page.ResolveUrl("~/Public/js/plannerscript.js") %>" type="text/javascript"></script>
</asp:Content>
