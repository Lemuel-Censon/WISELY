<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WISLEY.profile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hidotheremail" />
    <asp:HiddenField runat="server" ID="userid" />
    <h3 class="font-weight-bold text-center mb-2"><%if (userid.Value == hidotheremail.Value)
                                                      { %>Your Profile<%} %></h3>
    <div class="row">
        <div class="col-lg-3">
            <div class="card">
                <div class="card-body">
                    <h3 class="font-weight-bold text-center col-12">Quick Links</h3>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/index.aspx") %>"><i class="fas fa-home mr-1"></i>Home</a>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/Schedule/schedule.aspx") %>"><i class="fas fa-calendar-alt mr-1"></i>My Calendar</a>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/Board/collab.aspx") %>"><i class="fas fa-users mr-1"></i>My Groups</a>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/Gacha/gacha.aspx") %>"><i class="fas fa-portrait mr-1"></i>Gacha</a>
                    <a class="btn btn-block btn-white text-left border-left border-danger rounded-0 mb-1 blue-text" href="<%= Page.ResolveUrl("~/Views/Quiztool/quizcreator.aspx") %>"><i class="fas fa-question-circle mr-1"></i>Quiz Creator</a>
                </div>
            </div>
        </div>
        <div class="col-lg-9">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <img class="img-fluid rounded mx-auto d-block border" onerror="this.src='<%=Page.ResolveUrl("~/Public/img/default.jpg") %>'" id="imageProfile" src="<%=user().profilesrc %>" alt="Image not available" />
                        </div>
                        <div class="col-lg-4">
                            <h3 class="font-weight-bold">
                                <asp:Label ID="LbName" runat="server"></asp:Label>
                            </h3>
                            <h5>
                                <asp:Label ID="LbEmail" runat="server"></asp:Label>
                            </h5>
                            <div>
                                <asp:Label ID="LbDob" runat="server"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="LbContact" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-4 text-right">
                            <h5>
                                <asp:Label ID="LbWISPoints" runat="server"></asp:Label>
                                WIS</h5>
                            <h5 class="font-weight-bold">
                                <asp:Label runat="server" ID="LbType"></asp:Label></h5>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 mt-3">
                        </div>
                        <%if (userid.Value == hidotheremail.Value)
                            { %>
                        <div class="col-lg-6 text-right">
                            <asp:Button CssClass="btn btn-sm btn-info" ID="btnchangeAvatar" runat="server" Text="Change Avatar" OnClick="btnchangeAvatar_Click" />
                            <asp:Button CssClass="btn btn-sm btn-info" ID="btneditProfile" runat="server" Text="Edit Profile" OnClick="btneditProfile_Click" />
                        </div>
                        <%} %>
                    </div>
                </div>
            </div>
            <div class="mt-3">
                <ul class="nav nav-tabs" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" role="tab" data-toggle="tab" href="#about">About</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" role="tab" data-toggle="tab" href="#posts">Posts</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" role="tab" data-toggle="tab" href="#badges">Badges</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" role="tab" data-toggle="tab" href="#quizzes">Quizzes</a>
                    </li>
                </ul>
                <div class="tab-content min-vh-35">
                    <div id="about" class="tab-pane fade show active m-2 ml-2" role="tabpanel">
                        <div>
                            <asp:Label ID="LbBio" runat="server"></asp:Label>
                            <%if (userid.Value == hidotheremail.Value)
                                { %>
                            <br />
                            <asp:Button CssClass="btn btn-sm btn-info" ID="btnEditBio" runat="server" Text="Edit Bio" OnClick="btnEditBio_Click" />
                            <%} %>
                            <div>
                                <div class="md-form md-outline">
                                    <asp:Label AssociatedControlID="TbBio" ID="LbBioDesc" runat="server" Text="Bio Description" Visible="False"></asp:Label>
                                    <asp:TextBox ID="TbBio" runat="server" CssClass="form-control" TextMode="MultiLine" Visible="False" Height="300px"></asp:TextBox>
                                    <div class="text-right flex-fill">
                                        <asp:Button CssClass="btn btn-danger" ID="btnCancelChanges" runat="server" Text="Cancel" Visible="False" OnClick="btnCancelChanges_Click" />
                                        <asp:Button CssClass="btn btn-success" ID="btnSaveChanges" runat="server" Text="Save Changes" Visible="False" OnClick="btnSaveChanges_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="posts" class="tab-pane fade m-2 ml-2" role="tabpanel">
                        <asp:Repeater runat="server" ID="userpost" OnItemCommand="userpost_ItemCommand" OnItemDataBound="userpost_ItemDataBound">
                            <ItemTemplate>
                                <div class="card-body">
                                    <h4 class="card-title d-inline"><%#Eval("title") %></h4>
                                    <div class="media mt-4 px-1 mb-4">
                                        <img class="card-img-100 d-flex z-depth-1 mr-3" src='<%#Eval("profilesrc") %>' onerror="this.src='<%=Page.ResolveUrl("~/Public/img/default.jpg") %>'"
                                            alt="Image not available">
                                        <div class="media-body">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <h5 class="font-weight-bold mt-0">
                                                        <asp:LinkButton runat="server" ID="postlink"><%#Eval("username") %></asp:LinkButton>
                                                    </h5>
                                                </div>
                                                <div class="col-lg-6 text-right">
                                                    <span class="text-muted"><i class="fas fa-clock mr-1"></i>Created on: <%#Eval("datecreated") %>
                                                    </span>
                                                </div>
                                            </div>
                                            <%#Eval("content")%>
                                            <asp:LinkButton runat="server" ID="btnDownload" CssClass="d-block" CommandName="download" CommandArgument='<%#Eval("groupId")+","+Eval("fileName") %>'><%#Eval("fileName") %></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card-header border-0 font-weight-bold">
                                        <div class="text-right">
                                            <asp:LinkButton runat="server" CommandName="viewpost" CommandArgument='<%#Eval("Id") %>' ID="btnView" Text="View >>" CssClass="btn btn-sm btn-success"></asp:LinkButton>
                                        </div>
                                    </div>
                                    <hr />
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="mb-4">
                                    <asp:Label runat="server" ID="LbErr" Text="Currently Empty" Visible="false"></asp:Label>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div id="badges" class="tab-pane fade m-2 ml-2" role="tabpanel">
                        <h4 class="mt-3">Unlocked Badges (<asp:Label ID="LbNofUnlockedBadges" runat="server"></asp:Label>)</h4>
                        <asp:Repeater ID="unlocked_badges" runat="server">
                            <ItemTemplate>
                                <div class="media-body">
                                    <div class="row">
                                        <div class="col-4">
                                            <img src='<%#Eval("src") %>' alt='<%#Eval("alt") %>' class="img-fluid" width="100" height="100" />
                                        </div>
                                        <div class="col-8">
                                            <p><i class="fas fa-exclamation-circle mr-1"></i><span class="font-weight-bold">Requirement: </span><%#Eval("requirement") %></p>
                                            <p><i class="fas fa-gift mr-1"></i><span class="font-weight-bold">Reward: </span><%#Eval("points") %> WIS</p>
                                            <p><i class="fas fa-clock mr-1"></i><span class="font-weight-bold">Achieved On: </span><%#Eval("dateachieved") %></p>
                                        </div>
                                    </div>
                                    <hr />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <h4 class="mt-3">Locked Badges (<asp:Label ID="LbNofLockedBadges" runat="server"></asp:Label>)</h4>
                        <asp:Repeater ID="locked_badges" runat="server" OnItemDataBound="locked_badges_ItemDataBound">
                            <ItemTemplate>
                                <div class="media-body">
                                    <div class="row">
                                        <div class="col-4">
                                            <img src='<%#Eval("src") %>' alt='<%#Eval("alt") %>' class="img-fluid" width="100" height="100" style="filter: grayscale(100%)" />
                                        </div>
                                        <div class="col-8">
                                            <p><i class="fas fa-exclamation-circle mr-1"></i><span class="font-weight-bold">Requirement: </span><%#Eval("requirement") %></p>
                                            <p><i class="fas fa-gift mr-1"></i><span class="font-weight-bold">Reward: </span><%#Eval("points") %> WIS</p>
                                        </div>
                                    </div>
                                    <hr />
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="mb-4">
                                    <asp:Label runat="server" ID="LbErr" Text="You have already unlocked all badges!" CssClass="font-weight-bold" Visible="false"></asp:Label>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div id="quizzes" class="tab-pane fade m-2 ml-2" role="tabpanel">
                        <asp:Repeater runat="server" ID="userquiz" OnItemCommand="userquiz_ItemCommand" OnItemDataBound="userquiz_ItemDataBound">
                            <ItemTemplate>
                                <div class="card-body">
                                    <div class="media mt-4 px-1">
                                        <div class="media-body">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <h5 class="font-weight-bold mt-0">
                                                        <%#Eval("title") %>
                                                    </h5>
                                                </div>
                                                <%if (userid.Value == hidotheremail.Value)
                                                    { %>
                                                <div class="col-lg-6 text-right">
                                                    <asp:LinkButton runat="server" ID="editquiz" CssClass="btn btn-info btn-sm" Text="Edit" CommandName="editquiz" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                                    <button type="button" class="btn btn-sm btn-danger" data-toggle="modal" data-target="#delmodal<%#Eval("Id") %>">
                                                        Delete
                                                    </button>
                                                </div>
                                                <div class="modal fade" id="delmodal<%#Eval("Id") %>" tabindex="-1" role="dialog"
                                                    aria-hidden="true">
                                                    <div class="modal-dialog" role="document">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <h5 class="modal-title">Are you sure you want to delete this quiz?</h5>
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                    <span aria-hidden="true">&times;</span>
                                                                </button>
                                                            </div>
                                                            <div class="modal-body text-center">
                                                                Deletion of this quiz cannot be reverted once confirmed!
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-sm btn-danger" data-dismiss="modal">No</button>
                                                                <asp:LinkButton runat="server" CommandName="deletequiz" CommandArgument='<%#Eval("Id") %>' ID="btnDelete" Text="Yes" CssClass="btn btn-sm btn-success"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%} %>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6"><%#Eval("description")%></div>
                                                <div class="col-lg-6 text-right">

                                                    <span class="text-muted"><i class="fas fa-clock mr-1"></i>Created on: <%#Eval("datecreated") %>
                                                    </span>
                                                    <br />
                                                    <span class="text-muted"><i class="fas fa-exclamation-circle mr-1"></i>No of. Questions: <%#Eval("totalquestions") %></span>
                                                </div>
                                            </div>
                                            <div class="text-right mt-2 card-header border-0 font-weight-bold">
                                                <asp:LinkButton runat="server" ID="viewquiz" CssClass="btn btn-success btn-sm" CommandName="viewquiz" CommandArgument='<%#Eval("Id") %>'>Take Quiz >></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="mb-4">
                                    <asp:Label runat="server" ID="LbErr" Text="Currently Empty" Visible="false"></asp:Label>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

