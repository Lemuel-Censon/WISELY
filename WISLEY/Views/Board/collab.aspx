<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/group.Master" AutoEventWireup="true" CodeBehind="collab.aspx.cs" Inherits="WISLEY.collab" %>

<asp:Content ID="Content2" ContentPlaceHolderID="groupPosts" runat="server">
    <h3 class="font-weight-bold text-center mt-2">Collaboration Board</h3>
    <form runat="server">
        <div class="container">
            <asp:ScriptManager runat="server" ID="postscript">
            </asp:ScriptManager>
            <div class="card">
                <div class="card-body">
                    <div class="md-form md-outline">
                        <asp:Label ID="LbPost" AssociatedControlID="tbtitle" runat="server" Text="Post Title"></asp:Label>
                        <asp:TextBox ID="tbtitle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="md-form md-outline">
                        <asp:Label ID="LbDesc" AssociatedControlID="tbcontent" runat="server" Text="Post Description"></asp:Label>
                        <asp:TextBox ID="tbcontent" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="6"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="custom-file">
                                <asp:FileUpload ID="fileUpload" runat="server" CssClass="custom-file-input" />
                                <asp:Label ID="LbFile" AssociatedControlID="fileUpload" runat="server" Text="Upload a file" CssClass="custom-file-label"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-6 text-right">
                            <asp:Button CssClass="btn btn-success ml-auto" ID="btnpost" runat="server" Text="Post" OnClick="btnpost_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <% if (postcount() > 0)
                {
            %>
            <div class="card mt-3">
                <div class="card-body">
                    <div class="row">
                        <div class="col-12 col-md-12 order-1 order-md-3 mt-2 mt-md-0">
                            <div class="input-group md-form md-outline">
                                <input type="text" id="search" class="form-control" placeholder="Search by Title" />
                                <div class="input-group-append">
                                    <button type="button" class="btn btn-md btn-info m-0 px-3 py-2 waves-effect" id="searchbut"><i class="fas fa-search"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                </div>
                <div id="postcon">
                    <asp:UpdatePanel runat="server" ID="postpanel" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Repeater runat="server" ID="postinfo" DataSourceID="postdata" OnItemCommand="postinfo_ItemCommand">
                                <ItemTemplate>
                                    <div class="card-body postcards" id="post<%#Eval("Id") %>">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <h4 class="card-title posttitle" runat="server" id="posttitle" data-title='<%#Eval("title") %>'><%#Eval("title") %></h4>
                                                <asp:TextBox runat="server" ID="tbUptitle" CssClass="form-control" Text='<%#Eval("title") %>' Visible="false"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-6 text-right">
                                                <asp:Button runat="server" CommandName="editpost" ID="btnEdit" Text="Edit" CssClass="btn btn-sm btn-info" />
                                            </div>
                                        </div>
                                        <div class="media mt-4 px-1">
                                            <img class="card-img-100 d-flex z-depth-1 mr-3" src="https://picsum.photos/100"
                                                alt="Generic placeholder image">
                                            <div class="media-body">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <h5 class="font-weight-bold mt-0">
                                                            <a href="#">Danny Newman</a>
                                                        </h5>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <i class="fas fa-clock mr-1"></i><span>Created on: <%#Eval("datecreated") %>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div runat="server" id="postcontent">
                                                    <%#Eval("content") %>
                                                </div>
                                                <asp:TextBox runat="server" ID="tbUpcontent" TextMode="MultiLine" Rows="6" CssClass="form-control" Text='<%#Eval("content") %>' Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="card-header border-0 font-weight-bold">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <asp:Button runat="server" CommandName="cancel" ID="btncancel" Text="Cancel" CssClass="btn btn-sm btn-danger" Visible="false" />
                                                </div>
                                                <div class="text-right col-lg-6">
                                                    <asp:Button runat="server" CommandName="save" CommandArgument='<%#Eval("Id") %>' ID="btnSave" Text="Save Changes" CssClass="btn btn-sm btn-success" Visible="false" />
                                                    <asp:Button runat="server" CommandName="viewpost" CommandArgument='<%#Eval("Id") %>' ID="btnView" Text="View >>" CssClass="btn btn-sm btn-success" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:SqlDataSource ID="postdata"
                        ConnectionString="<%$ connectionStrings: ConnStr%>"
                        SelectCommand="SELECT * FROM POST ORDER BY Id DESC"
                        runat="server"></asp:SqlDataSource>
                </div>
            </div>
            <%} %><% else
                      { %>
            <div class="text-center mt-3">
                <h4 class="font-weight-bold">No Posts</h4>
            </div>
            <% } %>
        </div>
    </form>
    <script src="<%= Page.ResolveUrl("~/Public/js/collabscript.js") %>" type="text/javascript"></script>
</asp:Content>
