using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WaiterQR.Database;

namespace WaiterQR.Models
{
    public class ShoppingCartViewModel
    {
        public Product product { get; set; }

        public int quantity { get; set; }

        public int tableid { get; set; }


        public ShoppingCartViewModel(Product product, int quantity, int tableid)
        {
            this.product = product;
            this.quantity = quantity;   
            this.tableid = tableid;
        }
    }
}