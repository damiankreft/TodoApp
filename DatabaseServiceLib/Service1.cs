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
        string dbPath = DatabaseServiceLib.Properties.Settings.Default.dbPath;
        public bool Save(TodoItemModel todoItem)
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint itemId)
        {
            throw new NotImplementedException();
        }

        public List<TodoItemModel> GetTodoItems(uint userId)
        {
            var dbCon = DbConnection.Instance();
            dbCon.DatabaseName = "taskapp";

            List<TodoItemModel> todoItems = new List<TodoItemModel>();
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM tasks";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TodoItemModel item = new TodoItemModel();
                    item.ItemId = reader.GetUInt32(0);
                    item.Name = reader.GetString(1);
                    item.Description = reader.GetString(2);

                    todoItems.Add(item);
                }
            }

            return todoItems;
        }

        public string Hello()
        {
            return "Hello, World!";
        }
    }
}
