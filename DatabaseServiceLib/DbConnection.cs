using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DatabaseServiceLib
{
    class DbConnection
    {
        private readonly string dbPath = Properties.Settings.Default.dbPath;
        private DbConnection()
        {

        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get
            {
                return databaseName;
            }
            set
            {
                databaseName = value;
            }
        }

        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get
            {
                return connection;
            }
        }

        private static DbConnection _instance = null;
        public static DbConnection Instance()
        {
            if (_instance == null)
            {
                _instance = new DbConnection();
            }
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                {
                    return false;
                }

                // Added semicolon to end last parameter of dbPath string and add an another one.
                string connString = $"{dbPath};Database={DatabaseName};";

                // Below comment exists only for test purposes
                //string connString = "Server=localhost;Database=taskapp;Uid=root";
                try
                {
                    connection = new MySqlConnection(connString);
                    connection.Open();
                }
                catch(MySqlException exc)
                {
                    Console.WriteLine(exc.Code + "\n" + exc.Message);
                }
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
