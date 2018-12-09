using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Photos
    {
        public int PhotoID { get; set; }
        public string LoginID { get; set; }
        public string PhotoURL { get; set; }
        public string Description { get; set; }
        public string Tagged { get; set; }
        public string Album { get; set; }

        public Photos()
        {

        }

        public Photos(int PhotoID, string LoginID, string PhotoURL, string Description, string Tagged, string Album)
        {
            this.PhotoID = PhotoID;
            this.LoginID = LoginID;
            this.PhotoURL = PhotoURL;
            this.Description = Description;
            this.Tagged = Tagged;
            this.Album = Album;
        }

        public List<Photos> GetUserPhotos(string LoginID)
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            DataSet photosDS = new DataSet();
            List <Photos> photoList = new List<Photos>();

            photosDS = storedProcedure.getPhotos(LoginID);

            if (photosDS.Tables[0].Rows.Count != 0)
            {
                foreach (int row in photosDS.Tables[0].Rows)
                {
                    Photos thePhoto = new Photos(
                        int.Parse(photosDS.Tables[0].Rows[row][0].ToString()),
                        photosDS.Tables[0].Rows[row][1].ToString(),
                        photosDS.Tables[0].Rows[row][2].ToString(),
                        photosDS.Tables[0].Rows[row][3].ToString(),
                        photosDS.Tables[0].Rows[row][4].ToString(),
                        photosDS.Tables[0].Rows[row][5].ToString());
                    photoList.Add(thePhoto);
                }
            }
            return photoList;
        }
    }
}
