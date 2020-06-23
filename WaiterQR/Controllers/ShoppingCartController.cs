using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaiterQR.Database;

namespace WaiterQR.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult ShowBasket()
        {
            return View();
        }

        public void UpdateShoppingCart()
        {

        }
    }
}