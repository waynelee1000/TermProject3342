using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace TermProject.Main_Pages
{
    public partial class preferences : System.Web.UI.Page
    {

        //Temperorary loginID since Login cookie hasn't been created yet
        UpdatePreference updatePreference = new UpdatePreference();
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
            HttpCookie userCookie = Request.Cookies["UserCookie"];
            string prefereceString = userCookie.Values["Preference"].ToString();
            lbl_CurrentLoginPref.Text = prefereceString;
        }

        protected void btn_LoginPref_Click(object sender, EventArgs e)
        {
            Encrypt encrypt = new Encrypt();
            HttpCookie userCookie = Request.Cookies["UserCookie"];

            string newLoginPref =  DDL_LoginPref.SelectedValue.ToString();

            updatePreference.updateLoginPref(encrypt.Decrypt(userCookie.Values["Username"]).ToString(), newLoginPref);

            lbl_CurrentLoginPref.Text = newLoginPref;

            string PhotoStatus = userCookie.Values["PrivacyPhoto"].ToString();
            string ProfileStatus = userCookie.Values["PrivacyProfile"].ToString(); ;
            string ContactStatus = userCookie.Values["PrivacyContactInfo"].ToString();

            userCookie.Values["Username"] = userCookie.Values["Username"].ToString();
            userCookie.Values["Password"] = userCookie.Values["Password"].ToString();
            userCookie.Values["Preference"] = newLoginPref;
            userCookie.Values["PrivacyPhoto"] = PhotoStatus;
            userCookie.Values["PrivacyProfile"] = ProfileStatus;
            userCookie.Values["PrivacyContactInfo"] = ContactStatus;
            userCookie.Expires = new DateTime(2025, 1, 1);
            Response.Cookies.Add(userCookie);
            

        }

        protected void btn_PrivacyPref_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserCookie"];
            Encrypt encrypt = new Encrypt();

            string newPhotosPref = photosDDL.SelectedValue.ToString();
            string newProfilePref = profileDDL.SelectedValue.ToString();
            string newContactPref = contactDDL.SelectedValue.ToString();

            updatePreference.UpdatePrivacyPref(encrypt.Decrypt(userCookie.Values["Username"].ToString()), newPhotosPref, newProfilePref, newContactPref);

            userCookie.Values["Username"] = userCookie.Values["Username"].ToString();
            userCookie.Values["Password"] = userCookie.Values["Password"].ToString();
            userCookie.Values["Preference"] = userCookie.Values["Preference"].ToString();
            userCookie.Values["PhotosPref"] = newPhotosPref;
            userCookie.Values["ProfilePref"] = newProfilePref;
            userCookie.Values["ContactPref"] = newContactPref;

            userCookie.Expires = new DateTime(2025, 1, 1);
            Response.Cookies.Add(userCookie);
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