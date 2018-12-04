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
    public class FindUsers : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();

        // GET api/values/5
        [HttpGet]
        public DataSet FindUserByLocation(string City, string State)
        {
            DataSet userByLocation = storedProcedure.FindUsersByLocation(City, State);
            return userByLocation;
        }

    }
}
