using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Resources;

namespace WISLEY.Views.Resources
{
    public partial class resourceUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (Request.QueryString["groupId"] != null)
                {
                    User user = new User().SelectByEmail(Session["email"].ToString());
                    if (user.userType != "Teacher")
                    {
                        Session["error"] = "You must be a teacher to upload resources!";
                        Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
                    }
                    else
                    {
                        if (!Page.IsPostBack)
                        {
                            int grpId = int.Parse(Request.QueryString["groupId"]);
                            List<grpResourceType> grpRsTypes = new BLL.Group.Group().getGroupResourceTypes(grpId);
                            ddlResourceType.Items.Insert(0, "Select Type");

                            for (int i = 0; i < grpRsTypes.Count; i++)
                            {
                                ListItem item = new ListItem(grpRsTypes[i].resourceType, grpRsTypes[i].resourceType);
                                ddlResourceType.Items.Insert(i + 1, item);
                            }

                        }
                    }
                }
                else
                {
                    Session["error"] = "A group must be chosen to upload resources!";
                    Response.Redirect(Page.ResolveUrl("~/Views/Auth/login.aspx"));
                }
            }
            else
            {
                Session["error"] = "You must be logged in to edit a group!";
                Response.Redirect(Page.ResolveUrl("~/Views/Auth/login.aspx"));
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void uploadResource(object sender, EventArgs e)
        {
            string resourceType = null;
            string folderPath = null;

            if (!newResourceGroupTB.ReadOnly)
            {
                if (String.IsNullOrEmpty(newResourceGroupTB.Text.ToString()))
                {
                    toast(this, ("Please enter a resource type or choose an existing one"), "Error", "error");
                }
                else
                {
                    resourceType = newResourceGroupTB.Text.ToString();
                    grpResourceType resourceTypeObj = new grpResourceType(resourceType, int.Parse(Request.QueryString["groupId"]));
                    int newResourceResult = resourceTypeObj.insertResourceType();

                    if (newResourceResult != 1)
                    {
                        resourceType = null;
                        toast(this, ("Creating new resource type failed. Please contact system administrator."), "Error", "error");

                    }
                    else
                    {
                        folderPath = Server.MapPath("~/Public/uploads/groupResources/") + Request.QueryString["groupId"] + "/"
                        + resourceType + "/";
                        Directory.CreateDirectory(folderPath);
                    }

                }
            }
            else
            {
                resourceType = ddlResourceType.SelectedValue;
                folderPath = Server.MapPath("~/Public/uploads/groupResources/") + Request.QueryString["groupId"] + "/"
                            + resourceType + "/";
                Directory.CreateDirectory(folderPath);
            }

            if (resourceUploadController.HasFile && resourceType != null)
            {
                string filename = Path.GetFileName(resourceUploadController.FileName);

                grpResource resource = new grpResource(filename, resourceType, int.Parse(Request.QueryString["groupId"]));
                int result = resource.insertResource();

                if (result == 1)
                {
                    System.Diagnostics.Debug.WriteLine("Upload success. Check DB");

                    try
                    {
                        resourceUploadController.SaveAs(folderPath + filename);
                        Session["success"] = "Resources uploaded successfully!";
                        Response.Redirect("~/Views/Resources/viewResources.aspx?groupId=" + Request.QueryString["groupId"]);

                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Upload status: The file could not be uploaded. The following error occured: " + ex.Message);

                    }

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Failed");

                }


            }
        }

        protected void backToViewResources(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Resources/viewResources.aspx?groupId=" + Request.QueryString["groupId"]);

        }


        protected void onSelectResourceType(object sender, EventArgs e)
        {
            if (ddlResourceType.SelectedValue != "Select Type")
            {
                newResourceGroupTB.ReadOnly = true;
            }
            else
            {
                newResourceGroupTB.ReadOnly = false;
            }
        }



    }
}