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

    <div class="container-fluid mt-2">

        <asp:Repeater
            runat="server" ID="resHeaders" DataSourceID="resTypeData">
            <ItemTemplate>
                <div class="accordion my-1" id="accordion<%#Eval("resourceType").ToString().Replace(" ", "")%>">
                    <div class="card z-depth-0">
                        <div class="card-header p-1 row justify-content-between" id="heading<%#Eval("resourceType").ToString().Replace(" ", "")%>" data-toggle="collapse" data-target="#collapse<%#Eval("resourceType").ToString().Replace(" ", "")%>" aria-expanded="true" aria-controls="collapseOne">
                            <h3 class="mb-0 mx-3 col-7">
                                <%#Eval("resourceType")%>
 
                            </h3>
                            <h3 class="mb-0 mx-3 col-3 text-right">
                                <i id="arrow<%#Eval("resourceType").ToString().Replace(" ", "")%>" class="fas fa-angle-down"></i>

                            </h3>


                        </div>

                        <div id="collapse<%#Eval("resourceType").ToString().Replace(" ", "")%>" class="collapse show" aria-labelledby="heading<%#Eval("resourceType").ToString().Trim()%>" data-parent="#accordion<%#Eval("resourceType").ToString().Replace(" ", "")%>">
                            <div class="card-body row">
                                <asp:Repeater
                                    runat="server" ID="resFileHeaders" DataSourceID="resTypeFilesData" OnItemCommand="downloadCommand">
                                    <ItemTemplate>

                                        <asp:LinkButton ID="groupRedirect" runat="server" Text='<%#Eval("fileName")%>' CommandName="Download" CommandArgument='<%#Eval("resourceType")+","+Eval("fileName") %>'
                                            class="col-12 my-2" Style="text-transform: unset;" />

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                        <asp:SqlDataSource ID='resTypeFilesData' runat='server' ConnectionString="<%$ connectionStrings: ConnStr%>"
                            SelectCommand='<%# getQuery(Eval("resourceType")) %>' />

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:SqlDataSource ID="resTypeData"
            ConnectionString="<%$ connectionStrings: ConnStr%>"
            runat="server"></asp:SqlDataSource>

                <% if (user().userType == "Teacher")
            { %>
        <a class="btn btn-light" href="<%= Page.ResolveUrl("~/Views/Resources/resourceUpload.aspx?groupId=" + getGroupDetails().id.ToString())%>">Upload Resource </a>
        <%} %>
    </div>


</asp:Content>

