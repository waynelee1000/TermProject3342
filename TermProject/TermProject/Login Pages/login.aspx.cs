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
            if (!IsPostBack){
                HttpCookie userCookie = Request.Cookies["UserCookie"];
                UserLogin userLogin = new UserLogin();

                Encrypt encrypt = new Encrypt();

                if (Session["LoginStatus"] != null)
                {
                    if (Session["LoginStatus"].ToString() == "False")
                    {
                        if (userCookie.Values["Preference"].ToString() == "automatic")
                        {
                            login_emailTxt.Text = encrypt.Decrypt(userCookie.Values["Username"].ToString());
                            Preference preference = new Preference(login_emailTxt.Text);

                            userCookie.Values["Username"] = encrypt.EncryptLogin(login_emailTxt.Text);
                            userCookie.Values["Password"] = encrypt.EncryptPass(login_passwordTxt.Text);
                            userCookie.Values["Preference"] = preference.LoginPreference;
                            userCookie.Values["PrivacyProfile"] = preference.PrivacyProfile;
                            userCookie.Values["PrivacyPhoto"] = preference.PrivacyPhoto;
                            userCookie.Values["PrivacyContactInfo"] = preference.PrivacyContactInfo;
                            userCookie.Values["Name"] = userLogin.GetName(login_emailTxt.Text);
                            userCookie.Expires = new DateTime(2025, 1, 1);
                            Response.Cookies.Add(userCookie);

                        }
                        else if (userCookie.Values["Preference"].ToString() == "assist")
                        {
                            login_emailTxt.Text = encrypt.Decrypt(userCookie.Values["Username"].ToString());
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
                            login_emailTxt.Text = encrypt.Decrypt(userCookie.Values["Username"].ToString());
                        }
                    }
                }
                else
                {
                    if (userCookie != null)
                    {
                        if (userCookie.Values["Preference"].ToString() == "automatic")
                        {
                            login_emailTxt.Text = encrypt.Decrypt(userCookie.Values["Username"].ToString());
                            login_passwordTxt.Text = encrypt.Decrypt(userCookie.Values["Password"].ToString());

                            Session["LoginStatus"] = "True";

                            Response.Redirect(url: "~/Main Pages/newsfeed.aspx");
                        }
                        else if (userCookie.Values["Preference"].ToString() == "assist")
                        {
                            login_emailTxt.Text = encrypt.Decrypt(userCookie.Values["Username"].ToString());
                        }
                    }

                }
            }
            
        }
        protected void login_Btn_Click(object sender, EventArgs e)
        {
            Encrypt encrypt = new Encrypt();
            UserLogin userLogin = new UserLogin();
            string loginID = login_emailTxt.Text;
            string password = login_passwordTxt.Text;
            string result = userLogin.loginUser(loginID, password);
            if (result != "Error")
            {
                Preference preference = new Preference(login_emailTxt.Text);

                HttpCookie userCookie = new HttpCookie("UserCookie");
                
                userCookie.Values["Username"] = encrypt.EncryptLogin(login_emailTxt.Text);
                userCookie.Values["Password"] = encrypt.EncryptPass(login_passwordTxt.Text);
                userCookie.Values["Preference"] = preference.LoginPreference;
                userCookie.Values["PrivacyProfile"] = preference.PrivacyProfile;
                userCookie.Values["PrivacyPhoto"] = preference.PrivacyPhoto;
                userCookie.Values["PrivacyContactInfo"] = preference.PrivacyContactInfo;
                userCookie.Values["Name"] = userLogin.GetName(login_emailTxt.Text);
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
                register_PhoneTxt.Text == "" || register_streetTxt.Text == "" || register_stateTxt.Text == "" || register_zipCodeTxt.Text == "" || register_cityTxt.Text == "" ||
                register_securityQ1Txt.Text == "" || register_securityQ2Txt.Text == "" || register_securityA1Txt.Text == "" || register_securityA2Txt.Text == "")
            {
                lblTest.Text = "Please fill out all fields";
                return;
            }

            user.LoginID = register_emailTxt.Text;
            user.Password = register_passwordTxt.Text;
            user.Name = register_FirstNameTxt.Text + " " + register_LastNameTxt.Text;
            user.PhoneNumber = register_PhoneTxt.Text;
            user.Address = register_streetTxt.Text;
            user.ZipCode = int.Parse(register_zipCodeTxt.Text);
            user.City = register_cityTxt.Text;
            user.State = register_stateTxt.Text;
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