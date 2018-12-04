using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Classes
{
    public class Friend
    {
        public string LoginID { get; set; }
        public string FriendLoginID { get; set; }
        public int FriendCode { get; set; }

        public Friend()
        {

        }
        public Friend(string loginID, string friendLoginID, int friendcode)
        {
            this.LoginID = loginID;
            this.FriendLoginID = friendLoginID;
            this.FriendCode = friendcode;
        }

        public List<Friend> Friendlist(string loginID)
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            DataSet friendData = new DataSet();
            List<Friend> friendList = new List<Friend>();
            string friendName = "";
            friendData = storedProcedure.getFriend(loginID);

            if (friendData.Tables[0].Rows.Count != 0)
            {
                foreach (int row in friendData.Tables[0].Rows)
                {
                    if (friendData.Tables[0].Rows[row][1].ToString()!= loginID)
                    {
                        friendName = friendData.Tables[0].Rows[row][1].ToString();
                    }
                    else
                    {
                        friendName = friendData.Tables[0].Rows[row][2].ToString();
                    }
                    Friend friend = new Friend(loginID, friendName, int.Parse(friendData.Tables[0].Rows[row][0].ToString()));
                    friendList.Add(friend);
                }
            }

            return friendList;

        }
    }
}
