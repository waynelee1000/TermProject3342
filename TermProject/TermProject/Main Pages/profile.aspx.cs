using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Data;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TermProject.Main_Pages
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProfilePicture.ImageUrl = "../ProfilePictures/person1.jpg";

            HttpCookie userCookie = Request.Cookies["UserCookie"];

            WebRequest request = WebRequest.Create("http://localhost:49241/api/values?" + "creditcardnumber=");

            WebResponse response = request.GetResponse();



            // Read the data from the Web Response, which requires working with streams.

            Stream theDataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(theDataStream);

            string data = reader.ReadToEnd();

            reader.Close();

            response.Close();

            // Deserialize a JSON string into a Team object.

            DataSet gvData = JsonConvert.DeserializeObject<DataSet>(data);
        }

    }
}