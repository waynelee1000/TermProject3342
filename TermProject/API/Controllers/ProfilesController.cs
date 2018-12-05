using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Utilities;
using System.Data.SqlClient;
using Classes;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/MyProfile")]
    public class ProfilesController : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();

        [HttpGet]
        public DataSet MyProfile(string loginID, string Password)
        {
            DataSet myProfile = storedProcedure.GetMyProfile(loginID, Password);
            return myProfile;
        }
    }
}