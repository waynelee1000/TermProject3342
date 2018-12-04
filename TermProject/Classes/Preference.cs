using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Classes
{
    public class Preference
    {
        public string LoginID { get; set; }
        public string LoginPreference { get; set; }
        public string PrivacyProfile { get; set; }
        public string PrivacyPhoto { get; set; }
        public string PrivacyContactInfo { get; set; }

        public Preference()
        {

        }
        
        public Preference(string loginID, string loginPreference, string privacyprofile, string privacyphoto, string privacycontactinfo)
        {
            this.LoginID =  loginID;
            this.LoginPreference = loginPreference;
            this.PrivacyProfile = privacyprofile;
            this.PrivacyPhoto = privacyphoto;
            this.PrivacyContactInfo = privacycontactinfo;
        }

        public Preference(string loginID)
        {
            DataSet myDS = new DataSet();
            StoredProcedure storedProcedure = new StoredProcedure();
            this.LoginID = loginID;

            myDS = storedProcedure.getPreference(loginID);

            if (myDS.Tables[0].Rows.Count != 0)
            {
                this.LoginPreference = myDS.Tables[0].Rows[0][1].ToString();
                this.PrivacyProfile = myDS.Tables[0].Rows[0][2].ToString();
                this.PrivacyPhoto = myDS.Tables[0].Rows[0][3].ToString();
                this.PrivacyContactInfo = myDS.Tables[0].Rows[0][4].ToString();
            }
        }
    }
}