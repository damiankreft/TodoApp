using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DatabaseServiceLib.Models
{
    [Table("TodoItems")]
    public class TodoItemModel
    {
        [PrimaryKey, AutoIncrement, MaxLength(11)]
        public uint ItemId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
