using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

namespace TermProject.Login_Pages
{
    public partial class login_help : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Theme = "Login";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getSecurityBtn_Click(object sender, EventArgs e)
        {
            string userID = userTxt.Text;

            ForgotLogin getForgot = new ForgotLogin();
            string[] result = getForgot.getQuestions(userID);

            try
            {
                Q1Lbl.Text = result[0].ToString();
                Q2Lbl.Text = result[1].ToString();
                Q1Answer.Visible = true;
                Q2Answer.Visible = true;
                sumbitBtn.Visible = true;
            }
            catch
            {
                lblRecoveryError.Text = "Incorrect UserName";
            }

            
        }

        protected void sumbitBtn_Click(object sender, EventArgs e)
        {
            string userID = userTxt.Text;

            ForgotLogin getForgot = new ForgotLogin();
            string[] result = getForgot.getQuestions(userID);

            if(Q1Answer.Text == result[2] && Q2Answer.Text == result[3])
            {
                passwordLbl.Text = "Password:"+result[4];
            }
        }
    }
}