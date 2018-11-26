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
                HttpCookie userCookie = Request.Cookies["UserCookie"];
                string prefereceString = userCookie.Values["Preference"].ToString();

                if (prefereceString != "automatic")
                {
                    if (Session["LoginStatus"].ToString() == "False")
                    {
                        Response.Redirect("~/Login Pages/login.aspx");
                    }
                }
                else
                {
                    Session["LoginStatus"] = true;
                }

            }
            catch
            {
                Response.Redirect("~/Login Pages/login.aspx");
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {

        }
    }
}