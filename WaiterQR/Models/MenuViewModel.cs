// The menuviewmodel contains the productlist and the given table to be editable within the view
// Authors: Dennis Keles, Dennis Ludwig, Sheng Jing Ly

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

        public RestaurantTable restaurantTable { get; set; }

    }
}