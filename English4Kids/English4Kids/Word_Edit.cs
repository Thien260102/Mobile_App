using System;
using System.Collections.Generic;
using System.Text;

namespace English4Kids
{
    public class Word_Edit
    {
        public string TU { get; set; }
        public string LOAITU { get; set; }
        public string NGHIA { get; set; }
        public string ChuDauTien { get; set; }
        public string ConLai { get; set; }
        public Word_Edit(string Tu, string LoaiTu, string Nghia)
        {
            TU = Tu;
            LOAITU = LoaiTu;
            NGHIA = Nghia;
            ChuDauTien = Tu[0].ToString();
            ConLai = Tu.Substring(1);
        }
    }
}
