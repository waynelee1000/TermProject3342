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

                // Deserialize a JSON string into a Team object.

                User profileData = JsonConvert.DeserializeObject<User>(data);

                txtProfileName.Text = profileData.Name;
                txtProfileCellPhone.Text = profileData.PhoneNumber;
                txtProfileAddress.Text = profileData.Address;
                txtProfileCity.Text = profileData.City;
                txtProfileState.Text = profileData.State;
                txtProfileZipCode.Text = profileData.ZipCode.ToString();
                txtProfileOrgs.Text = profileData.Organization;
                imgProfile.ImageUrl = profileData.ProfilePictureURL;
            }
            

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
                string fileName = Path.Combine(Server.MapPath("~/ProfilePictures"), encrypt.Decrypt(userCookie.Values["Username"].ToString())+"_"+uploadProfilePicture.FileName);
                //save the file to our local path
                uploadProfilePicture.SaveAs(fileName);
                imgProfile.ImageUrl = "../ProfilePictures/"+encrypt.Decrypt(userCookie.Values["Username"].ToString())+"_"+uploadProfilePicture.FileName;


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
        protected void btnEditCell_Click (object sender, EventArgs e)
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

    }
}