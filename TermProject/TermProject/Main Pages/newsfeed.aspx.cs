using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Data;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Classes;

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
            NavButtons nav = (NavButtons)LoadControl("NavButtons.ascx");
            headerButtons.Controls.Add(nav);

            loadPosts();
            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            loadPosts();
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["LoginStatus"] = "False";

            Response.Redirect("~/Login Pages/login.aspx");
        }


        public void loadPosts()
        {
            Encrypt encrypt = new Encrypt();
            List<NewsFeed> newsFeedList = new List<NewsFeed>();
            NewsFeed newsFeed = new NewsFeed();
            HttpCookie userCookie = Request.Cookies["UserCookie"];

            WebRequest request = WebRequest.Create("http://localhost:49241/api/GetAllNewsFeed?" + "loginID=" + encrypt.Decrypt(userCookie.Values["Username"].ToString()) + "&Password=" + encrypt.Decrypt((userCookie.Values["Password"].ToString())));

            WebResponse response = request.GetResponse();


            // Read the data from the Web Response, which requires working with streams.

            Stream theDataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(theDataStream);

            string data = reader.ReadToEnd();

            reader.Close();

            response.Close();

            // Deserialize a JSON string into a Team object.

            newsFeedList = JsonConvert.DeserializeObject<List<NewsFeed>>(data);

            foreach (NewsFeed x in newsFeedList)
            {
                UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                Label owner = new Label();

                owner.Text = x.Name;
                UpdatePanel1.ContentTemplateContainer.Controls.Add(owner);

                UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                Label label = new Label();

                label.Text = x.NewsFeedMessage;
                UpdatePanel1.ContentTemplateContainer.Controls.Add(label);

                Label label2 = new Label();

                label2.Text = "Comments";
                UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
                UpdatePanel1.ContentTemplateContainer.Controls.Add(label2);

                PostComments postComments = (PostComments)LoadControl("PostComments.ascx");
                UpdatePanel1.ContentTemplateContainer.Controls.Add(postComments);
                UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<br />"));
            }
        }
    }
}