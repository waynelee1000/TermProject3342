using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Classes
{
    public class StoredProcedure
    {
        DBConnect db = new DBConnect();

        public string chkUserExist(string loginID)
        {
            try
            {
                SqlCommand sqlChkUserExist = new SqlCommand();
                sqlChkUserExist.CommandType = CommandType.StoredProcedure;
                sqlChkUserExist.CommandText = "TP_GetUserAccount";
                sqlChkUserExist.Parameters.Add(new SqlParameter("@LoginID", loginID));

                DataSet mydata = db.GetDataSetUsingCmdObj(sqlChkUserExist);
                string ID = mydata.Tables[0].Rows[0][0].ToString();
                return ID;
            }
            catch
            {
                return "False";
            }
        }

        public void addUser(string loginID, string password, string name, string phoneNumber, string address, int zipcode, string city, string state, string securityQuestion1,
            string securityQuestion2, string securityAnswer1, string securityAnswer2)
        {
            SqlCommand sqlAddUser = new SqlCommand();
            sqlAddUser.CommandType = CommandType.StoredProcedure;
            sqlAddUser.CommandText = "TP_AddUser";
            sqlAddUser.Parameters.Add(new SqlParameter("@LoginID", loginID));
            sqlAddUser.Parameters.Add(new SqlParameter("@Password", password));
            sqlAddUser.Parameters.Add(new SqlParameter("@Name", name));
            sqlAddUser.Parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
            sqlAddUser.Parameters.Add(new SqlParameter("@Address", address));
            sqlAddUser.Parameters.Add(new SqlParameter("@SecurityQuestion1", securityQuestion1));
            sqlAddUser.Parameters.Add(new SqlParameter("@SecurityQuestion2", securityQuestion2));
            sqlAddUser.Parameters.Add(new SqlParameter("@SecurityAnswer1", securityAnswer1));
            sqlAddUser.Parameters.Add(new SqlParameter("@SecurityAnswer2", securityAnswer2));
            sqlAddUser.Parameters.Add(new SqlParameter("@LoginPreference", "Default"));
            sqlAddUser.Parameters.Add(new SqlParameter("@ZipCode", zipcode));
            sqlAddUser.Parameters.Add(new SqlParameter("@City", city));
            sqlAddUser.Parameters.Add(new SqlParameter("@State", state));
            sqlAddUser.Parameters.Add(new SqlParameter("@ProfilePictureURL", "../ProfilePictures/defaultImage.jpg"));
            sqlAddUser.Parameters.Add(new SqlParameter("@Organization", "N/A"));
            sqlAddUser.Parameters.Add(new SqlParameter("@PrivacyProfile", "Public"));
            sqlAddUser.Parameters.Add(new SqlParameter("@PrivacyPhoto", "Public"));
            sqlAddUser.Parameters.Add(new SqlParameter("@PrivacyContactInfo", "Public"));

            db.DoUpdateUsingCmdObj(sqlAddUser);
        }

        public DataSet getFriend(string loginID)
        {
            DataSet myDS = new DataSet();
            try
            {
                SqlCommand sqlGetFriend = new SqlCommand();
                sqlGetFriend.CommandType = CommandType.StoredProcedure;
                sqlGetFriend.CommandText = "TP_GetFriend";
                sqlGetFriend.Parameters.Add(new SqlParameter("@LoginID", loginID));
                myDS = db.GetDataSetUsingCmdObj(sqlGetFriend);
                return myDS;
            }
            catch
            {
                return myDS;
            }

        }

        public DataSet getPreference(string loginID)
        {
            DataSet myDS = new DataSet();
            try
            {
                SqlCommand sqlGetPreference = new SqlCommand();
                sqlGetPreference.CommandType = CommandType.StoredProcedure;
                sqlGetPreference.CommandText = "TP_GetUserPreference";
                sqlGetPreference.Parameters.Add(new SqlParameter("@LoginID", loginID));
                myDS = db.GetDataSetUsingCmdObj(sqlGetPreference);
                return myDS;
            }
            catch
            {
                return myDS;
            }

        }

        public void updateLoginPreference(string loginID, string loginPrefernce)
        {
            SqlCommand sqlUpdateLoginPref = new SqlCommand();
            sqlUpdateLoginPref.CommandType = CommandType.StoredProcedure;
            sqlUpdateLoginPref.CommandText = "TP_UpdateLoginPref";
            sqlUpdateLoginPref.Parameters.Add(new SqlParameter("@LoginID", loginID));
            sqlUpdateLoginPref.Parameters.Add(new SqlParameter("@LoginPreference", loginPrefernce));

            db.DoUpdateUsingCmdObj(sqlUpdateLoginPref);
        }

        public DataSet checkLoginInfo(string loginID, string password)
        {
            DataSet loginDS = new DataSet();
            try
            {
                SqlCommand sqlCheckLogin = new SqlCommand();
                sqlCheckLogin.CommandType = CommandType.StoredProcedure;
                sqlCheckLogin.CommandText = "TP_CheckLogin";
                sqlCheckLogin.Parameters.Add(new SqlParameter("@theLoginID", loginID));
                sqlCheckLogin.Parameters.Add(new SqlParameter("@thePassword", password));

                loginDS = db.GetDataSetUsingCmdObj(sqlCheckLogin);
                return loginDS;
            } 
            catch
            {
                return loginDS; 
            }
        }

        public DataSet getSecurity(string loginID)
        {
            DataSet securityDS = new DataSet();
            try
            {
                SqlCommand sqlCheckLogin = new SqlCommand();
                sqlCheckLogin.CommandType = CommandType.StoredProcedure;
                sqlCheckLogin.CommandText = "TP_GetSecurity";
                sqlCheckLogin.Parameters.Add(new SqlParameter("@theLoginID", loginID));

                securityDS = db.GetDataSetUsingCmdObj(sqlCheckLogin);
                return securityDS;
            }
            catch
            {
                return securityDS;
            }
        }
        public DataSet FindUsersByLocation(string City, string State)
        {
            DataSet myds = new DataSet();
            try
            {
                SqlCommand sqlByLocation = new SqlCommand();
                sqlByLocation.CommandType = CommandType.StoredProcedure;
                sqlByLocation.CommandText = "TP_FindUserByLocation";
                sqlByLocation.Parameters.Add(new SqlParameter("@City", City));
                sqlByLocation.Parameters.Add(new SqlParameter("@State", State));


                myds = db.GetDataSetUsingCmdObj(sqlByLocation);

                return myds;
            }
            catch
            {
                return myds;
            }
        }

        public DataSet FindUsersByOrg(string Organization)
        {
            DataSet myds = new DataSet();
            try
            {
                SqlCommand sqlByOrg = new SqlCommand();
                sqlByOrg.CommandType = CommandType.StoredProcedure;
                sqlByOrg.CommandText = "TP_FindUserByOrg";
                sqlByOrg.Parameters.Add(new SqlParameter("@Organization", Organization));


                myds = db.GetDataSetUsingCmdObj(sqlByOrg);

                return myds;
            }
            catch
            {
                return myds;
            }
        }

        public DataSet GetMyProfile(string loginID, string password)
        {
            SqlCommand sqlMyProfile = new SqlCommand();
            sqlMyProfile.CommandType = CommandType.StoredProcedure;
            sqlMyProfile.CommandText = "TP_GetMyProfile";
            sqlMyProfile.Parameters.Add(new SqlParameter("@LoginID", loginID));
            sqlMyProfile.Parameters.Add(new SqlParameter("@Password", password));

            DataSet mydata = db.GetDataSetUsingCmdObj(sqlMyProfile);

            return mydata;
        }

        public void UpdateMyProfile(string loginid, string password,string name, string phonenumber, string streetaddress, string city, string state, int zipcode, string org, string profilepicture)
        {
            SqlCommand sqlUpdateProfile = new SqlCommand();
            sqlUpdateProfile.CommandType = CommandType.StoredProcedure;
            sqlUpdateProfile.CommandText = "TP_UpdateProfile";
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@LoginID", loginid));
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@Password", password));
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@Name", name));
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@PhoneNumber", phonenumber));
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@StreetAddress", streetaddress));
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@City", city));
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@State", state));
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@ZipCode", zipcode));
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@Organization", org));
            sqlUpdateProfile.Parameters.Add(new SqlParameter("@ProfilePictureURL", profilepicture));

            db.DoUpdateUsingCmdObj(sqlUpdateProfile);
        }

        public DataSet FindUserByName(string name)
        {
            DataSet myds = new DataSet();
            try
            {
                SqlCommand sqlByName = new SqlCommand();
                sqlByName.CommandType = CommandType.StoredProcedure;
                sqlByName.CommandText = "TP_FindUserByName";
                sqlByName.Parameters.Add(new SqlParameter("@theName", name));

                myds = db.GetDataSetUsingCmdObj(sqlByName);

                return myds;
            }
            catch
            {
                return myds;
            }
        }
    }
}
