using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Friends")]
    public class FriendsController : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();
        
        [HttpGet]
        public List<Friend> GetFriendsList(string requestingID, string requestedID)
        {
            List<Friend> userFriends = new List<Friend>();
            int checkFriend = storedProcedure.checkFriendStatus(requestingID, requestedID);

            if (checkFriend == 0)
            {
                return userFriends;
            } else
            {
                Friend friends = new Friend();
                userFriends = friends.Friendlist(requestedID);
                return userFriends;
            }
        }

        [HttpGet]
        public Friend[] GetFriendsArray(string requestingID, string requestedID)
        {
            Friend friends = new Friend();
            Boolean checkFriend = friends.checkFriends(requestingID, requestedID);

            if (checkFriend == true)
            {
                Friend[] userFriends = new Friend[] { };
                return userFriends;
            }
            else
            {
                Friend[] userFriends = friends.FriendArray(requestedID);
                return userFriends;
            }
        }
    }
}