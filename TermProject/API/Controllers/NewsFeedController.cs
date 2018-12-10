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
    [Route("api/NewsFeed")]
    public class NewsFeedController : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();

        [HttpPost]
        public string Post([FromBody] NewsFeed newsFeed)
        {
            try
            {
                storedProcedure.AddNewsFeed(newsFeed.LoginID.ToString(), newsFeed.NewsFeedMessage.ToString());
                return "Message Posted";
            }
            catch
            {
                return "Failed to Post";
            }
        }
    }

    [Produces("application/json")]
    [Route("api/GetPersonalFeed")]
    public class GetPersonalFeedController : Controller
    {
        DBConnect db = new DBConnect();
        StoredProcedure storedProcedure = new StoredProcedure();
        Encrypt encrypt = new Encrypt();

        [HttpGet]
        public List<NewsFeed> GetPersonalFeed(string loginID, string Password)
        {
            List<NewsFeed> newsFeedsList = new List<NewsFeed>();
            DataSet personalFeed = new DataSet();

            personalFeed = storedProcedure.GetNewsFeed(loginID);

            string oldkey = "-1";
            foreach (DataRow rows in personalFeed.Tables[0].Rows)
            {
                if (oldkey == "-1")
                {
                    NewsFeed newsFeed = new NewsFeed();
                    newsFeed.LoginID = rows["LoginID"].ToString();
                    newsFeed.NewsFeedMessage = rows["NewsFeed"].ToString();
                    newsFeedsList.Add(newsFeed);
                }
                else if (oldkey != rows["NewsFeedID"].ToString())
                {
                    NewsFeed newsFeed = new NewsFeed();
                    newsFeed.LoginID = rows["LoginID"].ToString();
                    newsFeed.NewsFeedMessage = rows["NewsFeed"].ToString();
                    newsFeedsList.Add(newsFeed);
                }
                oldkey = rows["NewsFeedID"].ToString();

            }

            return newsFeedsList;
        }
    }
}