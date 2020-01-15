using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TodoApp.Database;
using TodoApp.ServiceReference1;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            #region Connections
            // SQLite DB Connection
            //try
            //{
            //    string dbPath = TodoApp.Properties.Settings.Default.dbPath;
            //    LocalDB _database = new LocalDB(dbPath);
            //    //_database.SaveTodoItemAsync(new Models.TodoItemModel() { Name = "Learn SOLID principles", Description = "Implement SOLID to your coding routine"});
            //    var sqliteDb = _database.GetTodoItemsAsync();

            //    // To fix
            //    /*
            //    foreach(TodoApp.Models.TodoItemModel model in db)
            //    {
            //        Console.WriteLine(db.);
            //    }
            //    */

            //    Console.WriteLine(sqliteDb.Result.Count + " items.");
            //    for(int i = 0; i < sqliteDb.Result.Count; i++)
            //    {
            //        var id = sqliteDb.Result[i].ItemId;
            //        var descr = sqliteDb.Result[i].Description;
            //        var name = sqliteDb.Result[i].Name;
            //        Console.WriteLine($"{id}. {name} - {descr}");
            //    }
            //}
            //catch(SQLite.SQLiteException dbExc)
            //{
            //    Console.WriteLine("Error code: {0};\n Error Message: {1};", dbExc.HResult, dbExc.Message);
            //}

            
            /// Service Client
            //ServiceReference1.DatabaseClient client = new DatabaseClient();
            //if(client.Hello() == "Hello, World!")
            //    Console.WriteLine("Service reference works as intended.");

            // Testing GetTodoItems(uint userId)
            //var todoItems = client.GetTodoItems(1);
            //for (short i = 0; i < todoItems.Length; i++)
            //{
            //    var id = todoItems[i].ItemId;
            //    var name = todoItems[i].Name;
            //    var description = todoItems[i].Description;

            //    Console.WriteLine($"Downloaded via service using GetTodoItems(userId:0):\n#{id}. {name} - {description}");
            //    Console.WriteLine("Kutas");
            //}


            //// Testing GetTodoItem(uint itemId)
            //Func<string> todoItem = () =>
            //{
            //    string name = client.GetTodoItem(0).Name;
            //    uint id = client.GetTodoItem(0).ItemId;
            //    string description = client.GetTodoItem(0).Description;
            //    return $"Downloaded via service using GetTodoItem(itemId:0):\n #{id}. {name} - {description}";
            //};

            //Console.WriteLine(todoItem());
            #endregion
        }
    }
}
