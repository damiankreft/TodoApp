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


        /// <summary>
        /// Inserts or updates table depending on existence of the item with TaskId passsed as parameter. Returns result of Update(TodoItemModel) if item doesn't exist, otherwise returns result of Add(TodoItemModel).
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        public bool Save(TodoItemModel todoItem)
        {
            var dbCon = DbConnection.Instance();

            var item = GetTodoItems(0).Where(i => i.ItemId == todoItem.ItemId).ToList<TodoItemModel>();

            if (item.Count > 0)
            {
                return Update(todoItem);
            }
            else
            {
                return Add(todoItem);
            }
        }

        private bool Add(TodoItemModel todoItem)
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

        /// <summary>
        /// Overwrites row with parameters set in the paremeter passed to method.
        /// Returns true if Update affected any rows.
        /// </summary>
        /// <param name="todoItem"></param>
        private bool Update(TodoItemModel todoItem)
        {
            var dbConn = DbConnection.Instance();
            dbConn.DatabaseName = "taskapp";
            string title = todoItem.Name;
            string description = todoItem.Description;

            if (dbConn.IsConnect())
            {
                //string query = String.Format("INSERT INTO tasks(Title, Description, UserId) VALUES('{0}', '{1}', 0);", title, description);
                string query = String.Format("UPDATE `tasks` SET `Title`='{0}' , `Description`='{1}' WHERE `TaskId`={2}", todoItem.Name, todoItem.Description, todoItem.ItemId);
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
