using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace TermProject
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Theme = "Login";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserCookie"];

            if (Session["LoginStatus"] != null)
            {
                if (Session["LoginStatus"].ToString() == "False")
                {
                    if (userCookie.Values["Preference"].ToString() == "automatic")
                    {
                        login_emailTxt.Text = userCookie.Values["Username"].ToString();
                        Preference preference = new Preference(login_emailTxt.Text);

                        userCookie.Values["Username"] = login_emailTxt.Text;
                        userCookie.Values["Password"] = "";
                        userCookie.Values["Preference"] = preference.LoginPreference;
                        userCookie.Expires = new DateTime(2025, 1, 1);
                        Response.Cookies.Add(userCookie);

                    }
                    else if (userCookie.Values["Preference"].ToString() == "assist")
                    {
                        login_emailTxt.Text = userCookie.Values["Username"].ToString();
                    }
                }

                else
                {

                    if (userCookie.Values["Preference"].ToString() == "automatic")
                    {
                        login_emailTxt.Text = userCookie.Values["Username"].ToString();
                        Session["LoginStatus"] = "True";

                        Response.Redirect(url: "~/Main Pages/newsfeed.aspx");

                    }
                    else if (userCookie.Values["Preference"].ToString() == "assist")
                    {
                        login_emailTxt.Text = userCookie.Values["Username"].ToString();
                    }
                }
            }
            else
            {
                if (userCookie != null)
                {
                    if (userCookie.Values["Preference"].ToString() == "automatic")
                    {
                        login_emailTxt.Text = userCookie.Values["Username"].ToString();
                    }
                    else if (userCookie.Values["Preference"].ToString() == "assist")
                    {
                        login_emailTxt.Text = userCookie.Values["Username"].ToString();
                    }
                }

            }
        }
        protected void login_Btn_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            string result = userLogin.loginUser(login_emailTxt.Text, login_passwordTxt.Text);
            if (result != "Error")
            {
                Preference preference = new Preference(login_emailTxt.Text);

                HttpCookie userCookie = new HttpCookie("UserCookie");

                userCookie.Values["Username"] = login_emailTxt.Text;
                userCookie.Values["Password"] = login_passwordTxt.Text;
                userCookie.Values["Preference"] = preference.LoginPreference;
                userCookie.Expires = new DateTime(2025, 1, 1);
                Response.Cookies.Add(userCookie);
                Session["LoginStatus"] = "True";

                lblErrorLogin.Text = "";

                Session["LoginStatus"] = "True";

                Response.Redirect(url: "~/Main Pages/newsfeed.aspx");
            }
            else
            {
                lblErrorLogin.Text = "Incorrect Username or Password";
            }
        }

        protected void register_Btn_Click(object sender, EventArgs e)
        {
            UserRegistration userRegistration = new UserRegistration();
            User user = new User();
            // Validation
            if (register_emailTxt.Text == "" || register_passwordTxt.Text == "" || register_FirstNameTxt.Text == "" || register_LastNameTxt.Text == "" ||
                register_PhoneTxt.Text == "" || register_streetTxt.Text == "" || register_stateTxt.Text == "" || register_zipCodeTxt.Text == "" ||
                register_securityQ1Txt.Text == "" || register_securityQ2Txt.Text == "" || register_securityA1Txt.Text == "" || register_securityA2Txt.Text == "")
            {
                lblTest.Text = "Please fill out all fields";
                return;
            }

            user.LoginID = register_emailTxt.Text;
            user.Password = register_passwordTxt.Text;
            user.Name = register_FirstNameTxt.Text + " " + register_LastNameTxt.Text;
            user.PhoneNumber = register_PhoneTxt.Text;
            user.Address = register_streetTxt.Text + " " + register_stateTxt.Text + " " + register_zipCodeTxt.Text;
            user.SecurityQuestion1 = register_securityQ1Txt.Text;
            user.SecurityQuestion2 = register_securityQ2Txt.Text;
            user.SecurityAnswer1 = register_securityA1Txt.Text;
            user.SecurityAnswer2 = register_securityA2Txt.Text;

            lblTest.Text = userRegistration.registerUser(user);


            // Changed to redirect to preferences page -zach
            Response.Redirect("~/Main Pages/preferences.aspx");
        }
    }
}