using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WaiterQR.Models
{
    public class ActiveOrderViewModel
    {
        public int tableid { get; set; }

        public string productname { get; set; }

        public int amount { get; set; }

    }
}