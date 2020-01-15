using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DatabaseServiceLib;
using DatabaseServiceLib.Models;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace DatabaseServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DatabaseService : IDatabase
    {
        private readonly string dbPath = Properties.Settings.Default.dbPath;
        public bool Save(TodoItemModel todoItem)
        {
            var dbConn = DbConnection.Instance();
            dbConn.DatabaseName = "taskapp";

            if (dbConn.IsConnect())
            {
                
            }

            return false;
        }

        public bool Delete(uint itemId)
        {
            throw new NotImplementedException();
        }

        public List<TodoItemModel> GetTodoItems(uint userId)
        {
            var dbConn = DbConnection.Instance();
            dbConn.DatabaseName = "taskapp";

            List<TodoItemModel> todoItems = new List<TodoItemModel>();
            if (dbConn.IsConnect())
            {
                string query = "SELECT * FROM tasks";
                var cmd = new MySqlCommand(query, dbConn.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TodoItemModel item = new TodoItemModel();
                    item.ItemId = reader.GetUInt32(0);
                    item.Name = reader.GetString(1);
                    item.Description = reader.GetString(2);

                    todoItems.Add(item);
                }
                reader.Close();
            }

            return todoItems;
        }

        public TodoItemModel GetTodoItem(uint itemId)
        {
            var dbConn = DbConnection.Instance();
            dbConn.DatabaseName = "taskapp";
            TodoItemModel returnedItem = new TodoItemModel();

            if (dbConn.IsConnect())
            {
                
                string query = $"SELECT * FROM tasks WHERE TaskId={itemId}";
                var cmd = new MySqlCommand(query, dbConn.Connection);
                var reader = cmd.ExecuteReader();
                reader.Read();
                returnedItem.ItemId = UInt32.Parse(reader[0].ToString());
                returnedItem.Name = reader[1].ToString();
                returnedItem.Description = reader[2].ToString();

                Console.WriteLine($"We did it! Cast works properly.\n #{returnedItem.ItemId} {returnedItem.Name} - {returnedItem.Description}");
                reader.Close();
            }

            return returnedItem;
        }

        public string Hello()
        {
            return "Hello, World!";
        }
    }
}
