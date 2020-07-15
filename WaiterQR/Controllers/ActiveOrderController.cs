// This class is used for handling the activeorders by the restaurant owners. This includes showing the open orders for a restaurant and setting the order
// as done by the restaurant owner. 
// Authors: Dennis Keles, Dennis Ludwig, Sheng Jing Ly

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
    [Authorize] //only accessible with login

    public class ActiveOrderController : Controller
    {

        // GET: Gives out the products ordered by the users. Additionally it gives information on the amount and the table ordered from
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
        // Sets order elements as finished and therefore it is removed from the activeorder list
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