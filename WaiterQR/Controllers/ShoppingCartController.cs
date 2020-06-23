﻿using System;
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

            return View("Index");

        }
        private int isExistingCheck(int? id)
        {
            List<ShoppingCartViewModel> lscart = (List<ShoppingCartViewModel>)Session["ShoppingCartViewModel"];
            for(int i = 0;i< lscart.Count; i++)
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
            return View("Index");
        }
    }
}