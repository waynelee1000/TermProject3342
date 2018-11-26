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
    public class ForgotLogin
    {
        StoredProcedure storedProcedure = new StoredProcedure();

        public string[] getQuestions(string loginID)
        {
            //string[] array = new string[4];
            DataSet ds = new DataSet();
            ds = storedProcedure.getSecurity(loginID);

            try
            {
                string q1 = ds.Tables[0].Rows[0].ToString();
                string q2 = ds.Tables[0].Rows[1].ToString();
                string a1 = ds.Tables[0].Rows[2].ToString();
                string a2 = ds.Tables[0].Rows[3].ToString();
                string p = ds.Tables[0].Rows[4].ToString();

                string[] array = { q1, q2, a1, a2, p };
                return array;
            }
            catch
            {
                string[] array = new string[5];
                return array;
            }
        }
    }
}
