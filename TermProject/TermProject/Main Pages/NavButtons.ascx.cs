using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.Main_Pages
{
    public partial class NavButtons : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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