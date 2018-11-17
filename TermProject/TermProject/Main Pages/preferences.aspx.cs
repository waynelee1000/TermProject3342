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
        Preference myPreference = new Preference("gClooney@Test.com");
        //Temperorary loginID since Login cookie hasn't been created yet
        UpdatePreference updatePreference = new UpdatePreference();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Theme = "Blue";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_CurrentLoginPref.Text = myPreference.LoginPreference;
        }

        protected void btn_LoginPref_Click(object sender, EventArgs e)
        {
           string newLoginPref =  DDL_LoginPref.SelectedValue.ToString();

           updatePreference.updateLoginPref("gClooney@Test.com", newLoginPref);

           lbl_CurrentLoginPref.Text = newLoginPref;

        }
    }
}