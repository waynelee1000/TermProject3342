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

        }

        protected void login_Btn_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            string result = userLogin.loginUser(login_emailTxt.Text, login_passwordTxt.Text);
            if (result != "Error")
            {
                Response.Redirect(url: "~/Main Pages/newsfeed.aspx");
            }
        }

        protected void register_Btn_Click(object sender, EventArgs e)
        {
            UserRegistration userRegistration = new UserRegistration();
            User user = new User();

            user.LoginID = register_emailTxt.Text;
            user.Password = register_passwordTxt.Text;
            user.Name = register_FirstNameTxt.Text + " " +register_LastNameTxt.Text;
            user.PhoneNumber = register_PhoneTxt.Text;
            user.Address = register_streetTxt.Text + " " + register_stateTxt.Text + " " + register_zipCodeTxt.Text;
            user.SecurityQuestion1 = register_securityQ1Txt.Text;
            user.SecurityQuestion2 = register_securityQ2Txt.Text;
            user.SecurityAnswer1 = register_securityA1Txt.Text;
            user.SecurityAnswer2 = register_securityA2Txt.Text;

            lblTest.Text = userRegistration.registerUser(user);


            // Changed to redirect to preferences page -zach
            Response.Redirect("preferences.aspx");
        }
    }
}