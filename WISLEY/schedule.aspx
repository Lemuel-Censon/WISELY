<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="schedule.aspx.cs" Inherits="WISLEY.schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="font-weight-bold text-center">Your Calendar</h3>
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-body">
                <asp:Calendar ID="calendarPlan" CssClass="calendarPlan" runat="server" BackColor="White" BorderColor="#0F65D0" BorderWidth="1px" DayNameFormat="Full" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="299px" ShowGridLines="True" Width="467px" OnSelectionChanged="calendarPlan_SelectionChanged">
                    <DayHeaderStyle CssClass="calendarHeader" BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" Font-Bold="True" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#308DF5" ForeColor="White" Font-Italic="False" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="#175BCC" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#0F65D0" ForeColor="White" />
                    <WeekendDayStyle BackColor="White" Font-Bold="True" ForeColor="Red" />
                </asp:Calendar>  
            </div>
        </div>  

        <br />

        <div class="card">
            <div class="card-body">
                <h3 class="font-weight-bold text-center">Your personal To-Do-List</h3>
                <h4 class="text-center">Currently empty</h4>
            </div>
        </div>
    </form>
</asp:Content>
