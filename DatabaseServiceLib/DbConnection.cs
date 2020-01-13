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
                string dbPath = DatabaseServiceLib.Properties.Settings.Default.dbPath;
                // Added semicolon to end last parameter of dbPath string and add an another one.
                /*string connString = string.Format(dbPath + ";database={0}", databaseName);*/
                // database path requires fix. Original code used to cause a crash of the service
                string connString = "Server=localhost;Database=taskapp;Uid=root";
                connection = new MySqlConnection(connString);
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
