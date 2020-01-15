using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DatabaseServiceLib.Models;

namespace DatabaseServiceLib
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IDatabase
    {
        //[OperationContract]
        //string Hello();
        [OperationContract]
        bool Save(TodoItemModel todoItem);
        [OperationContract]
        bool Delete(uint itemId);
        [OperationContract]
        List<TodoItemModel> GetTodoItems(uint userId);
        [OperationContract]
        TodoItemModel GetTodoItem(uint itemId);
        [OperationContract]
        string Hello();
    }
}
