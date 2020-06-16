using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaiterQR.Database;

namespace WaiterQR.Controllers
{
    public class RestaurantTableController : Controller
    {
        // GET: RestaurantTable
        public ActionResult EditRestarauntTable(int restaurant_id)
        {

            return View(restaurant_id);
        }

        //    [HttpPost]
        //    public ActionResult AddRestarauntTable(RestaurantTableController restaurantTables)
        //    {
        //        try
        //        {
        //            using (websitedbEntities db = new websitedbEntities())
        //            {
                                          
        //                RestaurantTable table = new RestaurantTable();

        //                table.Restaurant_ID = restaurantTables.ResID;
        //                int i = 0;
        //                while (i >= 0)
        //                {
        //                    table.RestaurantTable_ID = i;
        //                    table.RestaurantTable_Occupied = false;
        //                }

        //                table.RestaurantTable_Seats = 4;

        //                db.Restaurant.Add(restaurant);
        //                db.SaveChanges();
        //            }


        //        }

        //        catch (Exception e)
        //        {
        //            string s = string.Format("Fehler: {0}", e.Message);
        //            s = string.Format("Typ: {0}", e.GetType());

        //        }
        //        return View();

        //    }
        }
}

//public static void TableCreator(Restaurant restaurant, websitedbEntities db)
//{
//    RestaurantTable rt = new RestaurantTable();

//    int i = 1;
//    int k = restaurant.Restaurant_TableAmount;
//    while (i <= k)
//    {
//        rt.Restaurant_ID = 1;
//        rt.RestaurantTable_ID = i;
//        rt.RestaurantTable_Occupied = false;

//        db.RestaurantTable.Add(rt);
//        db.SaveChanges();

//        i++;
//    }


//}