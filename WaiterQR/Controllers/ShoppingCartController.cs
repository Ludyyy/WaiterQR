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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            websitedbEntities db = new websitedbEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session["Cart"] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(db.Product.Find(id),1)
                };

                Session["Cart"] = lsCart;
            }
            else
            {
                List<Cart> lscart = (List<Cart>)Session["Cart"];
                int check = isExistingCheck(id);
                if (check == -1)
                    lscart.Add(new Cart(db.Product.Find(id), 1));
                else
                    lscart[check].Quantity++;

                //lscart.Add(new Cart(db.Product.Find(id), 1));
                Session["Cart"] = lscart;
            }

            return View("Index");

        }
        private int isExistingCheck(int? id)
        {
            List<Cart> lscart = (List<Cart>)Session["Cart"];
            for(int i = 0;i< lscart.Count; i++)
            {
                if (lscart[i].Product.ProductID == id) return i;
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
            List<Cart> lsCart = (List<Cart>)Session["Cart"];
            lsCart.RemoveAt(check);
            return View("Index");
        }
    }
}