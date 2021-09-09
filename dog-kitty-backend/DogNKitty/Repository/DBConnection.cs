using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using Npgsql;

namespace Repository
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = "denu3og6hclbt2";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private NpgsqlConnection connection = null;
        public NpgsqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring ="Server=ec2-52-2-118-38.compute-1.amazonaws.com;DataBase=denu3og6hclbt2;Uid=ajdrmyhilrvkcd;Pwd=a0112efb9736444dda1d72b71344bb830ef9c770b338df544bd32a9ff835366f;";
                connection = new NpgsqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
