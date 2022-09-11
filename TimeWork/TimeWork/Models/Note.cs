using SQLite;
using System;
namespace TimeWork.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}
