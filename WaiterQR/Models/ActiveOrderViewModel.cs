using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaiterQR.Models
{
    public class ActiveOrderViewModel
    {
        public int Tableid { get; set; }

        public string Productname { get; set; }

        public int Amount { get; set; }

    }
}