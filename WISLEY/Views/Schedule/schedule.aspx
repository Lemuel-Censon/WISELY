<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="schedule.aspx.cs" Inherits="WISLEY.schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="col-12 border border-secondary">
        <form id="form1" runat="server">
            <div class="card">
                <div class="card-body" style="margin:0 auto;">
                    <h3 class="text-center font-weight-bold">My Calendar</h3>
                    <asp:Calendar ID="calendarPlan" runat="server" BackColor="White" BorderColor="Black" Font-Names="Arial Black" Font-Size="10pt" ForeColor="Black" Height="430px" Width="878px" ShowGridLines="True" OnSelectionChanged="calendarPlan_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" VerticalAlign="Middle" />
                        <DayStyle Width="14%" Font-Bold="True" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#1F78C0" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <TodayDayStyle BackColor="#4899E1" Font-Bold="True" />
                        <WeekendDayStyle Font-Bold="True" ForeColor="Red" />
                    </asp:Calendar>
                </div>
            </div>

            <br/>

            <div class="card">
                <div class="card-body">
                    <h3 class="text-center font-weight-bold">Your personal To-Do-List(s)</h3>
                    <br/>
                    <h5 class="text-center font-weight-bold">Currently Empty
                    </h5>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
