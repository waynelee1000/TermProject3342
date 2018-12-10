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
                    if (friendData.Tables[0].Rows[row][1].ToString() != loginID)
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
                for (int row=0; row < (friendData.Tables[0].Rows.Count - 1); row++)
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

        public string[] GetNameArray(Friend[] friendArray)
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            string[] newArray = new string[friendArray.Length-1]; 
            for (int i = 0; i < friendArray.Length -1; i++)
            {
                Friend thisFriend = new Friend();
                thisFriend = friendArray[i];
                string thisLogin = thisFriend.LoginID;
                string thisName = storedProcedure.GetName(thisLogin);
                newArray[i] = thisName;
            }
            return newArray;
        }
    }
}
