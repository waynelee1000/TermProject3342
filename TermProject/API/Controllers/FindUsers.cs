using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Utilities;
using System.Data.SqlClient;
using Classes;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FindUserByLocation : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();
        User user = new User();

        // GET api/FindUsers?City=Philadelphia&State=PA
        [HttpGet]
        public List<User> FindUser(string City, string State)
        {
            DataSet userByLocation = storedProcedure.FindUsersByLocation(City, State);
            try
            {
                List<User> userList = new List<User>();

                foreach (DataRow row in userByLocation.Tables[0].Rows)
                {
                    string name = row["Name"].ToString();
                    string address = row["StreetAddress"].ToString();
                    string city = row["City"].ToString();
                    string state = row["State"].ToString();
                    int zipcode = Int32.Parse(row["ZipCode"].ToString());
                    string org = row["Organization"].ToString();
                    string profilepic = row["ProfilePictureURL"].ToString();
                    User user = new User(name, address, city, state, zipcode, org, profilepic);


                    userList.Add(user);
                }
                return userList;
            }
            catch
            {
                List<User> userList = new List<User>();
                return userList;
            }
        }
    }

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FindUserByOrg : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();
        User user = new User();

        [HttpGet]
        public List<User> FindUser(string Organization)
        {
            DataSet userByOrg = storedProcedure.FindUsersByOrg(Organization);
            try
            {
                List<User> userList = new List<User>();

                foreach (DataRow row in userByOrg.Tables[0].Rows)
                {
                    string name = row["Name"].ToString();
                    string address = row["StreetAddress"].ToString();
                    string city = row["City"].ToString();
                    string state = row["State"].ToString();
                    int zipcode = Int32.Parse(row["ZipCode"].ToString());
                    string org = row["Organization"].ToString();
                    string profilepic = row["ProfilePictureURL"].ToString();
                    User user = new User(name, address, city, state, zipcode, org, profilepic);

                   
                    userList.Add(user);
                }
                return userList;
            }
            catch
            {
                List<User> userList = new List<User>();
                return userList;
            }
        }
    }

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FindUserByName : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();

        [HttpGet]
        public DataSet FindUser(string name)
        {
            DataSet userByName = storedProcedure.FindUserByName(name);
            return userByName;
        }
    }
}
