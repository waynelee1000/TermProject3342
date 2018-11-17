using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Preference
    {
        public string LoginID { get; set; }
        public string LoginPreference { get; set; }
        public string Privacy { get; set; }

        public Preference()
        {

        }
        
        public Preference(string loginID, string loginPreference, string privacy)
        {
            this.LoginID =  loginID;
            this.LoginPreference = loginPreference;
            this.Privacy = privacy;
        }
    }
}