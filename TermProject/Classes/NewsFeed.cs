using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class NewsFeed
    {
        public string LoginID { get; set; }
        public string NewsFeedMessage { get; set; }
        public string Name { get; set; }

        public NewsFeed()
        {

        }

        public NewsFeed(string loginid, string message)
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            this.LoginID = loginid;
            this.NewsFeedMessage = message;
            this.Name = storedProcedure.GetName(loginid);
        }
    }
}
