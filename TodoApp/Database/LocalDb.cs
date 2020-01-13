using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TodoApp.Models;

namespace TodoApp.Database
{
    public class LocalDB
    {
        readonly SQLiteAsyncConnection _database;

        public LocalDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath, storeDateTimeAsTicks: true);
            _database.CreateTableAsync<TodoItemModel>().Wait();
        }

        public Task<List<TodoItemModel>> GetTodoItemsAsync()
        {
            return _database.Table<TodoItemModel>().ToListAsync();
        }

        public Task<TodoItemModel> GetTodoItemAsync(int id)
        {
            return _database.Table<TodoItemModel>().Where(i => i.ItemId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTodoItemAsync(TodoItemModel task)
        {
            return task.ItemId != 0 ? _database.UpdateAsync(task) : _database.InsertAsync(task);
        }

        public Task<int> DeleteTodoItemAsync(TodoItemModel task)
        {
            return _database.DeleteAsync(task);
        }
    }
}
