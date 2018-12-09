using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Photos")]
    public class PhotosController : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();

        [HttpGet]
        public List<String> GetPhotos(string LoginID)
        {

        }
    }
}