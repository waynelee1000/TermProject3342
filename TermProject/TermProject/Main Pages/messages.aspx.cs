using Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject.Main_Pages
{
    public partial class messages : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Theme = "Blue";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get user's name
            Encrypt encrypt = new Encrypt();
            HttpCookie userCookie = Request.Cookies["UserCookie"];
            string UserName = userCookie.Values["Name"].ToString();
            string LoginID = userCookie.Values["Username"].ToString();

            // Get thread data from database
            StoredProcedure storedProcedure = new StoredProcedure();
            DataSet threadsData = new DataSet();
            threadsData = storedProcedure.GetThreads(UserName);

            // Bind thread data to DDL
            threadsDDL.DataSource = threadsData.Tables[0];
            threadsDDL.DataTextField = "ThreadID";
            threadsDDL.DataValueField = "ThreadID";
            threadsDDL.DataBind();

            // Get users friend array for new thread DDL
            Friend theFriend = new Friend();
            Friend[] myFriends = theFriend.FriendArray(LoginID);

            // Bind friend data to ddl
            newThreadDDL.DataSource = myFriends;
            newThreadDDL.DataBind();

            NavButtons nav = (NavButtons)LoadControl("NavButtons.ascx");
            headerButtons.Controls.Add(nav);

        }

        protected void newThreadBtn_Click(object sender, EventArgs e)
        {

        }

        protected void threadGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void threadsDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}