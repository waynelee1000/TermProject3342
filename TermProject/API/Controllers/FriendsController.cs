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
        /*
        [HttpGet]
        public DataSet GetFriends(string requestingID, string requestedID, int friendKey)
        {
            
        }*/
    }
}