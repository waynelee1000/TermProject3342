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
    [Route("api/[controller]")]
    public class FindUserByLocation : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();

        // GET api/FindUsers?City=Philadelphia&State=PA
        [HttpGet]
        public DataSet FindUser(string City, string State)
        {
            DataSet userByLocation = storedProcedure.FindUsersByLocation(City, State);
            return userByLocation;
        }
    }


    [Route("api/[controller]")]
    public class FindUserByOrg : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();

        [HttpGet]
        public DataSet FindUser(string Organization)
        {
            DataSet userByLocation = storedProcedure.FindUsersByOrg(Organization);
            return userByLocation;
        }
    }
}
