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
        {/*
            try
            {
                if (Session["LoginStatus"].ToString() == "False")
                {
                    Response.Redirect("~/Login Pages/login.aspx");
                }
            }
            catch
            {
                Response.Redirect("~/Login Pages/login.aspx");
            }
            HttpCookie userCookie = Request.Cookies["UserCookie"];
            string prefereceString = userCookie.Values["Preference"].ToString();

            lbl_CurrentLoginPref.Text = prefereceString;*/
        }

        protected void btn_LoginPref_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserCookie"];

            string newLoginPref =  DDL_LoginPref.SelectedValue.ToString();

            updatePreference.updateLoginPref(userCookie.Values["Username"].ToString(), newLoginPref);

            lbl_CurrentLoginPref.Text = newLoginPref;

            userCookie.Values["Username"] = userCookie.Values["Username"].ToString();
            userCookie.Values["Password"] = userCookie.Values["Password"].ToString();
            userCookie.Values["Preference"] = newLoginPref;
            userCookie.Expires = new DateTime(2025, 1, 1);
            Response.Cookies.Add(userCookie);
            

        }

        protected void btn_PrivacyPref_Click(object sender, EventArgs e)
        {
            string newPhotosPref = photosDDL.SelectedValue.ToString();
            string newProfilePref = profileDDL.SelectedValue.ToString();
            string newContactPref = contactDDL.SelectedValue.ToString();

            HttpCookie userCookie = Request.Cookies["UserCookie"];

            userCookie.Values["Username"] = userCookie.Values["Username"].ToString();
            userCookie.Values["Password"] = userCookie.Values["Password"].ToString();
            userCookie.Values["PhotosPref"] = newPhotosPref;
            userCookie.Values["ProfilePref"] = newProfilePref;
            userCookie.Values["ContactPref"] = newContactPref;
        }
    }
}