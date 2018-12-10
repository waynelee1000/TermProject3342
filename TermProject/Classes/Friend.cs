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

            try
            {
                if (friendData.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in friendData.Tables[0].Rows)
                    {
                        if (row[1].ToString() != loginID)
                        {
                            friendName = row[1].ToString();
                        }
                        else
                        {
                            friendName = row[2].ToString();
                        }
                        Friend friend = new Friend(loginID, friendName, int.Parse(row[0].ToString()));
                        friendList.Add(friend);
                    }
                }
            }
            catch
            {

            }

            return friendList;

        }

        public Boolean checkFriends(string loginID, string friendID)
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            DataSet friendsData = new DataSet();

            int checkFriend = storedProcedure.checkFriendStatus(loginID, friendID);
            if (checkFriend == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public Friend[] FriendArray(string loginID)
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            DataSet friendData = new DataSet();

            string friendName = "";
            friendData = storedProcedure.getFriend(loginID);

            Friend[] friendArr = new Friend[friendData.Tables[0].Rows.Count];

            if (friendData.Tables[0].Rows.Count != 0)
            {
                foreach (int row in friendData.Tables[0].Rows)
                {
                    if (friendData.Tables[0].Rows[row][1].ToString() != loginID)
                    {
                        friendName = friendData.Tables[0].Rows[row][1].ToString();
                    }
                    else
                    {
                        friendName = friendData.Tables[0].Rows[row][2].ToString();
                    }
                    Friend friend = new Friend(loginID, friendName, int.Parse(friendData.Tables[0].Rows[row][0].ToString()));
                    friendArr[row] = friend;
                }
            }

            return friendArr;

        }
    }
}
