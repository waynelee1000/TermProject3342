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
        User user = new User();

        [HttpGet]
        public User MyProfile(string loginID, string Password)
        {
            DataSet myProfile = storedProcedure.GetMyProfile(loginID, Password);

            try
            {
                string name = myProfile.Tables[0].Rows[0]["Name"].ToString();
                string number = myProfile.Tables[0].Rows[0]["PhoneNumber"].ToString();
                string address = myProfile.Tables[0].Rows[0]["StreetAddress"].ToString();
                string city = myProfile.Tables[0].Rows[0]["City"].ToString();
                string state = myProfile.Tables[0].Rows[0]["State"].ToString();
                int zipcode = Int32.Parse(myProfile.Tables[0].Rows[0]["ZipCode"].ToString());
                string org = myProfile.Tables[0].Rows[0]["Organization"].ToString();
                string profilepic = myProfile.Tables[0].Rows[0]["ProfilePictureURL"].ToString();

                User user = new User(name, number, address, city, state, zipcode, org, profilepic);
                return user;
            }
            catch
            {
                User user = new User();
                return user;
            }

        }
        [HttpPost]
        public string Post([FromBody] User user)
        {
            Encrypt encrypt = new Encrypt();
            try
            {
                storedProcedure.UpdateMyProfile(encrypt.Decrypt(user.LoginID).ToString(), encrypt.Decrypt(user.Password).ToString(), user.Name, user.PhoneNumber, user.Address, user.City, user.State, user.ZipCode, user.Organization, user.ProfilePictureURL);
                return "Updated Profile";
            }
            catch
            {
                return "Failed to Update Profile";
            }
        }
    }
}