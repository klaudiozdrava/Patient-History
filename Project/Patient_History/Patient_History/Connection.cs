using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient_History
{
    public static class Connection
    {
        
        private static MySqlConnection  connection;
        public static MySqlConnection getConnection()
        {
            if (connection == null) {
                createConnection();
                return connection;
            }
            else return connection;  
        }
        private static void createConnection()
        {
            string connectionstring = "server=localhost;port=3306;userid=root;password=root;database=PatientHistoryDB";
            connection = new MySqlConnection(connectionstring);
        }
    }
}