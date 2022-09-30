using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace English4Kids
{
    [Table("TUVUNG")]
    public class Word
    {
        [AutoIncrement, PrimaryKey]
        public int MATU { get; set; }
        public string TU { get; set; }
        public string LOAITU { get; set; }
        public string NGHIA { get; set; }
        public Word_Edit ConvertToWordEdit()
        {
            return new Word_Edit(this.TU, this.LOAITU, this.NGHIA);
        }
    }
}
