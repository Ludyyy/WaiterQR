using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaiterQR.Database;

namespace WaiterQR.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult ShowMenu(int restaurantid, int restauranttable)
        {
            try
            {
                var tempList = new List<Product>();
                using (websitedbEntities db = new websitedbEntities())
                {
                    foreach (Product p in db.Product)
                    {
                        if (p.RestaurantID == restaurantid)
                        {
                            tempList.Add(p);
                        }
                    }
                }
                return View(tempList);
            }


            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return View();

            }
        }

        [HttpPost]
        public ActionResult ShowMenu(ShoppingCart shoppingCart)
        {
            try
            {
                var tempList = new List<Product>();
                using (websitedbEntities db = new websitedbEntities())
                {
                    foreach (Product p in db.Product)
                    {
                        if (p.RestaurantID == restaurantid)
                        {
                            tempList.Add(p);
                        }
                    }
                }
                return View(tempList);
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