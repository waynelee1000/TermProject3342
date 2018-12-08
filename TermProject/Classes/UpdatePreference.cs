using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class UpdatePreference
    {
        StoredProcedure storedProcedure = new StoredProcedure();

        public void updateLoginPref(string loginID,string loginPreference)
        {
            storedProcedure.updateLoginPreference(loginID, loginPreference);
        }

        public void UpdatePrivacyPref(string LoginID, string PhotosPref, string ProfilePref, string ContactPref)
        {
            storedProcedure.UpdatePrivacy(LoginID, PhotosPref, ProfilePref, ContactPref);
        }
    }
}
