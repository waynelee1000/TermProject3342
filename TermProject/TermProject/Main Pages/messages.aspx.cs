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
            if (!IsPostBack)
            {
                // Get user's name
                Encrypt encrypt = new Encrypt();
                HttpCookie userCookie = Request.Cookies["UserCookie"];
                string UserName = userCookie.Values["Name"].ToString();
                string LoginID = encrypt.Decrypt(userCookie.Values["Username"].ToString());

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
                String[] friendArray = theFriend.GetNameArray(myFriends);

                // Bind friend data to ddl
                newThreadCBL.DataSource = friendArray;
                newThreadCBL.DataBind();

                // Hide elements until button is pressed
                newThreadCBL.Style["visibility"] = "hidden";
                newThreadBtn.Style["visibility"] = "hidden";
                showFriendsBtn.Style["visibility"] = "visible";

                //
                string threadID = threadsDDL.SelectedValue;
                DataSet myDS = new DataSet();
                myDS = storedProcedure.GetMessages(threadID);
                threadGrid.DataSource = myDS;
                threadGrid.DataBind();
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

        protected void newThreadBtn_Click(object sender, EventArgs e)
        {
            List<String> selected = new List<String>();
            foreach (ListItem item in newThreadCBL.Items)
            {
                if (item.Selected)
                {
                    selected.Add(item.Value);
                }
            }
            if (selected.Count == 0)
            {
                return;
            }
            else
            {
                string newThreadTitle = "";
                foreach (string item in selected)
                {
                    newThreadTitle += (item + ", ");
                }
                StoredProcedure storedProcedure = new StoredProcedure();
                HttpCookie userCookie = Request.Cookies["UserCookie"];
                string messageText = "New Thread Created";
                string userName = userCookie.Values["Name"];
                storedProcedure.SendMessage(messageText, newThreadTitle, userName);
                Response.Redirect("~/Main Pages/messages.aspx");
            }

        }

        protected void threadGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void threadsDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            string threadID = threadsDDL.SelectedValue;
            StoredProcedure storedProcedure = new StoredProcedure();
            DataSet myDS = new DataSet();
            myDS = storedProcedure.GetMessages(threadID);
            threadGrid.DataSource = myDS;
            threadGrid.DataBind();
        }

        protected void showFriendsBtn_Click(object sender, EventArgs e)
        {
            newThreadCBL.Style["visibility"] = "visible";
            showFriendsBtn.Style["visibility"] = "hidden";
            newThreadBtn.Style["visibility"] = "visible";
        }

        protected void messageBtn_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserCookie"];
            string messageText = messageTxt.Text;
            string threadID = threadsDDL.SelectedValue;
            string userName = userCookie.Values["Name"];

            StoredProcedure storedProcedure = new StoredProcedure();

            storedProcedure.SendMessage(messageText, threadID, userName);
            Response.Redirect("~/Main Pages/messages.aspx");
        }
    }
}