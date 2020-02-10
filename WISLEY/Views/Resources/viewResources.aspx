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

        <div class="row justify-content-center">
            <div class="col-12">
                <asp:Repeater
                    runat="server" ID="resHeaders" DataSourceID="resTypeData">
                    <ItemTemplate>
                        <div class="accordion my-1" id="accordion<%#Eval("resourceType").ToString().Replace(" ", "")%>">
                            <div class="card z-depth-0">

                                <div class="border-bottom border-primary p-1 row justify-content-between collapsed" id="heading<%#Eval("resourceType").ToString().Replace(" ", "")%>"
                                    data-toggle="collapse" data-target="#collapse<%#Eval("resourceType").ToString().Replace(" ", "")%>" aria-expanded="false" aria-controls="collapseOne">
                                    <h4 class="mb-0 mx-2 col-7">
                                        <%#Eval("resourceType")%>
                                    </h4>
                                    <h4 class="mb-0 mx-3 col-3 text-right">
                                        <i id="arrow<%#Eval("resourceType").ToString().Replace(" ", "")%>" class="fas fa-angle-down"></i>

                                    </h4>

                                    <script>
                                        console.log('heading<%#Eval("resourceType").ToString().Replace(" ", "")%>')
                                        arrowHeader<%#Eval("resourceType").ToString().Replace(" ", "")%> = $('#heading<%#Eval("resourceType").ToString().Replace(" ", "")%>')
                                        arrow<%#Eval("resourceType").ToString().Replace(" ", "")%> = $('#arrow<%#Eval("resourceType").ToString().Replace(" ", "")%>')
                                        arrowHeader<%#Eval("resourceType").ToString().Replace(" ", "")%>.click(function () {
                                            console.log("Clicked")
                                            if (arrow<%#Eval("resourceType").ToString().Replace(" ", "")%>.hasClass("fa-angle-down")) {
                                            arrow<%#Eval("resourceType").ToString().Replace(" ", "")%>.addClass("fa-angle-up")
                                            arrow<%#Eval("resourceType").ToString().Replace(" ", "")%>.removeClass("fa-angle-down")
                                        }
                                        else {
                                            arrow<%#Eval("resourceType").ToString().Replace(" ", "")%>.addClass("fa-angle-down")
                                            arrow<%#Eval("resourceType").ToString().Replace(" ", "")%>.removeClass("fa-angle-up")
                                            }

                                        })
                                    </script>
                                </div>

                                <div id="collapse<%#Eval("resourceType").ToString().Replace(" ", "")%>"
                                    class="collapse"
                                    aria-labelledby="heading<%#Eval("resourceType").ToString().Trim()%>" data-parent="#accordion<%#Eval("resourceType").ToString().Replace(" ", "")%>">
                                    <div class="card-body row py-0">
                                        <asp:Repeater
                                            runat="server" ID="resFileHeaders" DataSourceID="resTypeFilesData" OnItemCommand="downloadCommand">
                                            <ItemTemplate>

                                                <asp:LinkButton ID="groupRedirect" runat="server" Text='<%#Eval("fileName")%>' CommandName="View" CommandArgument='<%#Eval("resourceType")+","+Eval("fileName") %>'
                                                    class="col-12 my-2" Style="text-transform: unset;" />

                                            </ItemTemplate>

                                            <FooterTemplate>

                                                <% if (resHeaders.Items.Count < 1) { %>
                                                <div class="row">
                                                    <h3 class="col-12 text-center">There are no resources uploaded for this resource section </h3>
                                                </div>
                                                <%}%>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>

                                <asp:SqlDataSource ID='resTypeFilesData' runat='server' ConnectionString="<%$ connectionStrings: ConnStr%>"
                                    SelectCommand='<%# getQuery(Eval("resourceType"), Eval("grpId")) %>' />

                            </div>
                        </div>
                    </ItemTemplate>

                    <FooterTemplate>
                        <% if (resHeaders.Items.Count < 1)
                    { %>
                        <div class="row">
                            <h3 class="col-12 text-center">There are no resources uploaded for this group</h3>
                        </div>
                        <%}%>
                    </FooterTemplate>
                </asp:Repeater>

                <asp:SqlDataSource ID="resTypeData"
                    ConnectionString="<%$ connectionStrings: ConnStr%>"
                    runat="server"></asp:SqlDataSource>
            </div>
        </div>
        <% if (user().userType == "Teacher")
            { %>
        <div class="row justify-content-center">
            <a class="btn btn-outline-success"
                href="<%= Page.ResolveUrl("~/Views/Resources/resourceUpload.aspx?groupId=" + getGroupDetails().id.ToString())%>">Upload Resource </a>
        </div>
        <%} %>
    </div>


</asp:Content>

