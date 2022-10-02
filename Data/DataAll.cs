using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hw5.Models;
using System.Data.SqlClient;
using System.Web;

namespace hw5.Data
{
    public class DataAll
    {
        //establish instance of class
        private static DataAll instance;
        public static DataAll getInstance()
        {
            if (instance == null)
            {
                instance = new DataAll();
            }
            return instance;
        }

        //establish connection string
        public String connectionString;
        public void setConnectionString(String someConnStr)
        {
            connectionString = someConnStr;
        }



    }
}
