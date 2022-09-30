using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace English4Kids
{
    [Table("DAHOC")]
    public class Studied
    {
        [AutoIncrement, PrimaryKey]
        public string USERNAME { get; set; }
        public int MATU { get; set; }
    }
}
