<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="viewResources.aspx.cs" Inherits="WISLEY.Views.Resources.viewResources" %>

<asp:Content ID="Content2" ContentPlaceHolderID="groupResources" runat="server">

    <% if (Request.QueryString["groupId"] != null)
        {
            string grpName = getGroupDetails().name;
            string grpDesc = getGroupDetails().description;
            string grpCode = getGroupDetails().joinCode;
            string grpId = getGroupDetails().id.ToString();
        }
    %>

    <div class="container-fluid">

        <%--                <%foreach (var grpResType in getDirectories()) { 
            string name = grpResType.resourceType;
             %>

            <h1> <%= name %></h1>

                <%foreach (var files in getFileNames(name)) { %>
             
                <h4 runat="server" onclick=""> <%= files %></h4>
                <%} %>
        <%} %>--%>


        <asp:Repeater
            runat="server" ID="resHeaders" DataSourceID="resTypeData">
            <ItemTemplate>
                <h1><%#Eval("resourceType")%></h1>



                <asp:Repeater
                    runat="server" ID="resFileHeaders" DataSourceID="resTypeFilesData" OnItemCommand="downloadCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="groupRedirect" runat="server" Text='<%#Eval("fileName")%>' CommandName="Download" CommandArgument='<%#Eval("resourceType")+","+Eval("fileName") %>'
                            class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1" Style="text-transform: unset;" />
                      
                    </ItemTemplate>
                </asp:Repeater>



                <asp:SqlDataSource ID='resTypeFilesData' runat='server' ConnectionString="<%$ connectionStrings: ConnStr%>"
                    SelectCommand='<%# getQuery(Eval("resourceType")) %>' />


            </ItemTemplate>
        </asp:Repeater>

        <asp:SqlDataSource ID="resTypeData"
            ConnectionString="<%$ connectionStrings: ConnStr%>"
            runat="server"></asp:SqlDataSource>

        <a class="btn btn-light" href="<%= Page.ResolveUrl("~/Views/Resources/resourceUpload.aspx?groupId=" + getGroupDetails().id.ToString())%>">Upload Resource </a>


    </div>


</asp:Content>

