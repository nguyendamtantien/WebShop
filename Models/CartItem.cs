using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang1.Models
{
    public class CartItem
    {
        public string masp { set; get; }
        public string ten { set; get; }
        public int sl { set; get; }
        public string anh { set; get; }
        public int gia { set; get; }
        public double total
        {
            get { return sl * gia; }
        }

    }
}