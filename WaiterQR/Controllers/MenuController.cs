// Over this class the menus are handled and visualised. It gives out the menu for a specific restaurant based on the tableid.
// Authors: Dennis Keles, Dennis Ludwig, Sheng Jing Ly

using DocumentFormat.OpenXml.Office.CustomUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaiterQR.Database;
using WaiterQR.Models;

namespace WaiterQR.Controllers
{

    public class MenuController : Controller
    {
        // GET: Gives out the menu for a specific restaurant based on the given table id. In the backend the table is stil stored
        public ActionResult ShowMenu(int tableid)
        {
            try
            {
                RestaurantTable restaurantTable = new RestaurantTable();
                var tempList = new List<Product>();

                using (websitedbEntities db = new websitedbEntities())
                {
                    List<Product> productList = db.Product.ToList();
                    List<RestaurantTable> tableList = db.RestaurantTable.ToList();
                    RestaurantTable restTable = new RestaurantTable();

                    MenuViewModel mvw = new MenuViewModel();
                    foreach (RestaurantTable rt in tableList)
                    {
                        if (rt.ID == tableid)
                        {
                            foreach(Product p in productList)
                            {
                                if (rt.RestaurantID == p.RestaurantID)
                                {
                                    tempList.Add(p);
                                    restTable = rt;
                                }
                            }
                        }
                    }

                    mvw.productList = tempList;
                    mvw.restaurantTable = restTable;
                    return View(mvw);

                }



            }


            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return View();

            }
        }
    }
}