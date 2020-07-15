using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using WaiterQR.Database;
using WaiterQR.Models;

namespace WaiterQR.Controllers
{
 

    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        public ActionResult ShowShoppingCart()
        {
            return View();
        }

        public ActionResult AddShoppingCart(int? productid, int? tableid)
        {
            websitedbEntities db = new websitedbEntities();
            if (productid == null || tableid == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session["ShoppingCartViewModel"] == null)
            {
                List<ShoppingCartViewModel> lsCart = new List<ShoppingCartViewModel>
                {
                    new ShoppingCartViewModel(db.Product.Find(productid),1,db.RestaurantTable.Find(tableid).ID)
                };

                Session["ShoppingCartViewModel"] = lsCart;
                Session["tableid"] = tableid;

            }
            else
            {
                List<ShoppingCartViewModel> lscart = (List<ShoppingCartViewModel>)Session["ShoppingCartViewModel"];
                int check = isExistingCheck(productid);
                if (check == -1)
                    lscart.Add(new ShoppingCartViewModel(db.Product.Find(productid), 1, db.RestaurantTable.Find(tableid).ID));
                else
                    lscart[check].quantity++;

                //lscart.Add(new Cart(db.Product.Find(id), 1));
                Session["ShoppingCartViewModel"] = lscart;
                Session["tableid"] = tableid;

            }
            return RedirectToAction("ShowShoppingCart");


        }
        private int isExistingCheck(int? id)
        {
            List<ShoppingCartViewModel> lscart = (List<ShoppingCartViewModel>)Session["ShoppingCartViewModel"];
            for (int i = 0; i < lscart.Count; i++)
            {
                if (lscart[i].product.ProductID == id) return i;
            }
            return -1;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = isExistingCheck(id);
            List<ShoppingCartViewModel> lsCart = (List<ShoppingCartViewModel>)Session["ShoppingCartViewModel"];
            lsCart.RemoveAt(check);

            ViewBag.message = "This is a shopping cart.";
            return RedirectToAction("ShowShoppingCart");
        }


        public ActionResult OrderFinished()
        {
            //List<ShoppingCartViewModel> lsCart = (List<ShoppingCartViewModel>)Session["ShoppingCartViewModel"];
            //int count = lsCart.
            List<ShoppingCartViewModel> lscart = new List<ShoppingCartViewModel>();
            lscart = (List<ShoppingCartViewModel>)Session["ShoppingCartViewModel"];
            int tableidgive=0;

            using (websitedbEntities db = new websitedbEntities())
            {

                ShoppingCart shoppingCart = new ShoppingCart();

                foreach (ShoppingCartViewModel cart in lscart)
                {
                    shoppingCart.ProductIDs = cart.product.ProductID;
                    shoppingCart.UserID = 1;
                    shoppingCart.OrderStatus = 1;
                    shoppingCart.ProductCount = cart.quantity;
                    shoppingCart.RestaurantID = cart.product.RestaurantID;
                    shoppingCart.RestaurantIDTable = cart.tableid;
                    tableidgive = cart.tableid;

                    db.ShoppingCart.Add(shoppingCart);
                    db.SaveChanges();

                }

            }
            return RedirectToAction("ShowMenu", "Menu", new { tableid = tableidgive });
        }

        public ActionResult UpdateCart(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            List<ShoppingCartViewModel> lstCart = (List<ShoppingCartViewModel>)Session["ShoppingCartViewModel"];
            for (int i = 0; i < lstCart.Count; i++)
            {
                lstCart[i].quantity = Convert.ToInt32(quantities[i]);
            }
            Session["ShoppingCartViewModel"] = lstCart;
            return RedirectToAction("ShowShoppingCart");
        }
    }
}