﻿using System;
using MySql.Data.MySqlClient;

namespace MyConnection
{
    public class ConnectData
    {
        public static MySqlConnection GetConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "coffee";
            string username = "root";
            string password = "20270907";


            String connString = "Server=" + host + ";Database=" + database
                    + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MySqlConnection conn = new MySqlConnection(connString);
            /*
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connString; 
            */

            return conn;
        }
    }
}
