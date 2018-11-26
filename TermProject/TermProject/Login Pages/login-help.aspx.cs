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

            Q1Lbl.Text = result[0];
            Q2Lbl.Text = result[1];
            
        }

        protected void sumbitBtn_Click(object sender, EventArgs e)
        {
            string userID = userTxt.Text;

            ForgotLogin getForgot = new ForgotLogin();
            string[] result = getForgot.getQuestions(userID);

            if(Q1Answer.Text == result[2] && Q2Answer.Text == result[3])
            {
                passwordLbl.Text = result[4];
            }
        }
    }
}