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
        //private readonly string dbPath = Properties.Settings.Default.dbPath;
        public bool Save(TodoItemModel todoItem)
        {
            throw new NotImplementedException();
        }

        // To implement
        public bool Add(TodoItemModel todoItem)
        {
            var dbConn = DbConnection.Instance();
            dbConn.DatabaseName = "taskapp";
            string title = todoItem.Name;
            string description = todoItem.Description;

            if (dbConn.IsConnect())
            {
                string query = String.Format("INSERT INTO tasks(Title, Description, UserId) VALUES('{0}', '{1}', 0);", title, description);
                var cmd = new MySqlCommand(query, dbConn.Connection);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                dbConn.Close();
            }
            return false;
        }

        public bool Update(TodoItemModel todoItem)
        {
            var dbConn = DbConnection.Instance();
            dbConn.DatabaseName = "taskapp";
            string title = todoItem.Name;
            string description = todoItem.Description;

            if (dbConn.IsConnect())
            {
                string query = String.Format("INSERT INTO tasks(Title, Description, UserId) VALUES('{0}', '{1}', 0);", title, description);
                var cmd = new MySqlCommand(query, dbConn.Connection);
                if (cmd.ExecuteNonQuery() > 0)
                {

                    return true;
                }
                dbConn.Close();
            }
            return false;
        }

        public bool Delete(uint itemId)
        {
            var dbConn = DbConnection.Instance();
            dbConn.DatabaseName = "taskapp";

            if (dbConn.IsConnect())
            {
                string query = String.Format("DELETE FROM tasks WHERE TaskId={0}", itemId);
                var cmd = new MySqlCommand(query, dbConn.Connection);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    dbConn.Close();
                    return true;
                }
            }
            return false;
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
                string query = $"SELECT * FROM tasks WHERE TaskId={itemId};";
                var cmd = new MySqlCommand(query, dbConn.Connection);
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    returnedItem.ItemId = reader.GetUInt32(0);
                    returnedItem.Name = reader.GetString(1);
                    returnedItem.Description = reader.GetString(2);
                }
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
