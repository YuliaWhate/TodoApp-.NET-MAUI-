using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TodoApp.Models
{
    //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
    public class TodoItem
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleated { get; set;}
    }
}
