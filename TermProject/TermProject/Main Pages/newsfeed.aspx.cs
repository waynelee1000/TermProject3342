using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.Main_Pages
{
    public partial class newsfeed : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Theme = "Blue";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
        {
                if (Session["LoginStatus"].ToString() == "False")
                {
                    Response.Redirect("~/Login Pages/login.aspx");
                }
                else
                {
                    Session["LoginStatus"] = "True";
                }

            }
            catch
            {
                Response.Redirect("~/Login Pages/login.aspx");
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["LoginStatus"] = "False";

            Response.Redirect("~/Login Pages/login.aspx");
        }

        protected void prefBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main Pages/preferences.aspx");
        }

        protected void messagesBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main Pages/messages.aspx");
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main Pages/profile.aspx");
        }
    }
}