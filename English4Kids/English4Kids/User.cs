using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
namespace English4Kids
{
    [Table("USER")]
    public class User
    {
        [AutoIncrement, PrimaryKey]
        public string USERNAME { get; set; } 
        public string HOTEN { get; set; }
        public string PASSWORD { get; set; } 
        public string EMAIL { get; set; } 
    }
}
