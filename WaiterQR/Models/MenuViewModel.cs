using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WaiterQR.Database;

namespace WaiterQR.Models
{
    public class MenuViewModel
    {
        public List<Product> productList { get; set; }

        //public ShoppingCart shoppingCart { get; set; }

        public RestaurantTable restaurantTable { get; set; }

    }
}