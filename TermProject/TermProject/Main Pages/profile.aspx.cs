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
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Theme = "Blue";
        }

        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                Encrypt encrypt = new Encrypt();
                //ProfilePicture.ImageUrl = "../ProfilePictures/person1.jpg";

                HttpCookie userCookie = Request.Cookies["UserCookie"];

                WebRequest request = WebRequest.Create("http://localhost:49241/api/MyProfile?" + "loginID=" + encrypt.Decrypt(userCookie.Values["Username"].ToString()) + "&Password=" + encrypt.Decrypt(userCookie.Values["Password"].ToString()));

                WebResponse response = request.GetResponse();



                // Read the data from the Web Response, which requires working with streams.

                Stream theDataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(theDataStream);

                string data = reader.ReadToEnd();

                reader.Close();

                response.Close();

                // Deserialize a JSON string

                User profileData = JsonConvert.DeserializeObject<User>(data);

                txtProfileName.Text = profileData.Name;
                txtProfileCellPhone.Text = profileData.PhoneNumber;
                txtProfileAddress.Text = profileData.Address;
                txtProfileCity.Text = profileData.City;
                txtProfileState.Text = profileData.State;
                txtProfileZipCode.Text = profileData.ZipCode.ToString();
                txtProfileOrgs.Text = profileData.Organization;
                imgProfile.ImageUrl = profileData.ProfilePictureURL;

                loadPosts();
            }

            NavButtons nav = (NavButtons)LoadControl("NavButtons.ascx");
            headerButtons.Controls.Add(nav);
        }

        protected void btnConfirmation_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Encrypt encrypt = new Encrypt();
            HttpCookie userCookie = Request.Cookies["UserCookie"];
            User user = new User();

            if (uploadProfilePicture.HasFile)
            {
                //create the path to save the file to
                string fileName = Path.Combine(Server.MapPath("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug11961/TermProject/storage/"), encrypt.Decrypt(userCookie.Values["Username"].ToString()) + "_" + uploadProfilePicture.FileName);
                //save the file to our local path
                uploadProfilePicture.SaveAs(fileName);
                imgProfile.ImageUrl = "http://cis-iis2.temple.edu/Fall2018/CIS3342_tug11961/TermProject/storage/" + encrypt.Decrypt(userCookie.Values["Username"].ToString()) + "_" + uploadProfilePicture.FileName;

                storedProcedure.addPhotos(encrypt.Decrypt(userCookie.Values["Username"].ToString()), imgProfile.ImageUrl.ToString());
            }

            if (uploadPhotos.HasFiles)
            {
                string fileName = Path.Combine(Server.MapPath("http://cis-iis2.temple.edu/Fall2018/CIS3342_tug11961/TermProject/storage/"), encrypt.Decrypt(userCookie.Values["Username"].ToString()) + "_" + uploadPhotos.FileName);
                //save the file to our local path
                uploadProfilePicture.SaveAs(fileName);
                imgProfile.ImageUrl = "http://cis-iis2.temple.edu/Fall2018/CIS3342_tug11961/TermProject/storage/" + encrypt.Decrypt(userCookie.Values["Username"].ToString()) + "_" + uploadPhotos.FileName;
                storedProcedure.addPhotos(encrypt.Decrypt(userCookie.Values["Username"].ToString()), imgProfile.ImageUrl.ToString());
            }
            user.LoginID = userCookie.Values["Username"].ToString();
            user.Password = userCookie.Values["Password"].ToString();
            user.Name = txtProfileName.Text;
            user.PhoneNumber = txtProfileCellPhone.Text;
            user.Address = txtProfileAddress.Text;
            user.City = txtProfileCity.Text;
            user.State = txtProfileState.Text;
            user.ZipCode = Int32.Parse(txtProfileZipCode.Text);
            user.Organization = txtProfileOrgs.Text;
            user.ProfilePictureURL = imgProfile.ImageUrl;

            string jsonUser = js.Serialize(user);

            WebRequest request = WebRequest.Create("http://localhost:49241/api/MyProfile?");
            request.Method = "POST";
            request.ContentType = "application/json";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());

            writer.Write(jsonUser);
            writer.Flush();
            writer.Close();

            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);

            string data = reader.ReadToEnd();

            reader.Close();
            response.Close();


        }

        protected void btnEditAddress_Click(object sender, EventArgs e)
        {
            if (txtProfileAddress.ReadOnly == true)
            {
                txtProfileAddress.ReadOnly = false;
            }
            else
            {
                txtProfileAddress.ReadOnly = true;
            }
        }
        protected void btnEditCell_Click(object sender, EventArgs e)
        {

            if (txtProfileCellPhone.ReadOnly == true)
            {
                txtProfileCellPhone.ReadOnly = false;
            }
            else
            {
                txtProfileCellPhone.ReadOnly = true;
            }
        }

        protected void btnEditCity_Click(object sender, EventArgs e)
        {
            if (txtProfileCity.ReadOnly == true)
            {
                txtProfileCity.ReadOnly = false;
            }
            else
            {
                txtProfileCity.ReadOnly = true;
            }
        }

        protected void btnEditState_Click(object sender, EventArgs e)
        {

            if (txtProfileState.ReadOnly == true)
            {
                txtProfileState.ReadOnly = false;
            }
            else
            {
                txtProfileState.ReadOnly = true;
            }
        }

        protected void btnEditZipCode_Click(object sender, EventArgs e)
        {
            if (txtProfileZipCode.ReadOnly == true)
            {
                txtProfileZipCode.ReadOnly = false;
            }
            else
            {
                txtProfileZipCode.ReadOnly = true;
            }
        }

        protected void btnEditOrg_Click(object sender, EventArgs e)
        {
            if (txtProfileOrgs.ReadOnly == true)
            {
                txtProfileOrgs.ReadOnly = false;
            }
            else
            {
                txtProfileOrgs.ReadOnly = true;
            }

        }
        protected void btnEditName_Click(object sender, EventArgs e)
        {
            if (txtProfileName.ReadOnly == true)
            {
                txtProfileName.ReadOnly = false;
            }
            else
            {
                txtProfileName.ReadOnly = true;
            }

        }

        protected void btnEditMode_Click(object sender, EventArgs e)
        {
            if (uploadProfilePicture.Visible == false)
            {
                uploadProfilePicture.Visible = true;
                btnEditName.Visible = true;
                btnEditCell.Visible = true;
                btnEditAddress.Visible = true;
                btnEditCity.Visible = true;
                btnEditState.Visible = true;
                btnEditZipCode.Visible = true;
                btnEditOrg.Visible = true;
                btnConfirmation.Visible = true;
            }
            else
            {
                uploadProfilePicture.Visible = false;
                btnEditName.Visible = false;
                btnEditCell.Visible = false;
                btnEditAddress.Visible = false;
                btnEditCity.Visible = false;
                btnEditState.Visible = false;
                btnEditZipCode.Visible = false;
                btnEditOrg.Visible = false;
                btnConfirmation.Visible = false;
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            loadPosts();
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            Encrypt encrypt = new Encrypt();
            HttpCookie userCookie = Request.Cookies["UserCookie"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            NewsFeed newsFeed = new NewsFeed(encrypt.Decrypt(userCookie.Values["Username"].ToString()), txtPostWall.Text);

            string jsonNews = js.Serialize(newsFeed);

            WebRequest request = WebRequest.Create("http://localhost:49241/api/NewsFeed");
            request.Method = "POST";
            request.ContentType = "application/json";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());

            writer.Write(jsonNews);
            writer.Flush();
            writer.Close();

            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);



            string data = reader.ReadToEnd();

            reader.Close();
            response.Close();
            loadPosts();
        }
        public void loadPosts()
        {
            Encrypt encrypt = new Encrypt();
            List<NewsFeed> newsFeedList = new List<NewsFeed>();
            NewsFeed newsFeed = new NewsFeed();
            HttpCookie userCookie = Request.Cookies["UserCookie"];

            WebRequest request = WebRequest.Create("http://localhost:49241/api/GetPersonalFeed?" + "loginID=" + encrypt.Decrypt(userCookie.Values["Username"].ToString()) + "&Password=" + encrypt.Decrypt((userCookie.Values["Password"].ToString())));

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