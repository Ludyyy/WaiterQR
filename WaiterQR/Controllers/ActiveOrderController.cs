using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaiterQR.Database;
using WaiterQR.Models;

namespace WaiterQR.Controllers
{
    public class ActiveOrderController : Controller
    {
        // GET: ActiveOrder
        public ActionResult ShowActiveOrder(int restaurantid)
        {
            List<ActiveOrderViewModel> tempList = new List<ActiveOrderViewModel> ();
            try
            {  
                using (websitedbEntities db = new websitedbEntities())
                {
                    List<Product> productList = db.Product.ToList();
                    List<ShoppingCart> shoppingCarts = db.ShoppingCart.ToList();
                    List<RestaurantTable> restaurantTables = db.RestaurantTable.ToList();
                    
                    foreach (ShoppingCart sc in shoppingCarts)
                    {
                        if (sc.OrderStatus==1)
                        {
                            if (sc.RestaurantID == restaurantid)
                            {
                                foreach (Product p in productList)
                                {
                                    if (p.ProductID == sc.ProductIDs)
                                    {
                                        ActiveOrderViewModel aovw = new ActiveOrderViewModel();
                                        aovw.Tableid = db.RestaurantTable.Find(sc.RestaurantIDTable).RestaurantSeat;
                                        aovw.Productname = p.ProductName;
                                        aovw.Amount = sc.ProductCount;
                                        aovw.Status = sc.OrderStatus;
                                        aovw.OrderID = sc.ShoppingCartID;
                                        tempList.Add(aovw);
                                    }
                                }
                            }
                        }
                    }

                    return View(tempList);
                }

            }

            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return View();

            }
        }

        public ActionResult FinishOrder(int orderid)
        {
            ShoppingCart sc = new ShoppingCart();
            try
            {

                using (websitedbEntities db = new websitedbEntities())
                {
                    sc = db.ShoppingCart.Find(orderid);
                    sc.OrderStatus = 0;
                    db.SaveChanges();
                }
                return RedirectToAction("ShowActiveOrder", new { restaurantid = sc.RestaurantID });
            }
            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return RedirectToAction("ShowActiveOrder", new { restaurantid = sc.RestaurantID });
            }


        }
    }
}