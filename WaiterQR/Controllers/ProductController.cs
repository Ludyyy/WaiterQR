using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using WaiterQR.Database;
using WaiterQR.Models;

namespace WaiterQR.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ShowProduct()
        {
            try
            {
                var tempList = new List<Product>();
                using (websitedbEntities db = new websitedbEntities())
                {
                    foreach (Product p in db.Product)
                    {
                        tempList.Add(p);
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



        // GET: Product/Create
        public ActionResult AddProduct()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            try
            {
                using (websitedbEntities db = new websitedbEntities())
                {

                    Product prod = new Product();
                    prod.RestaurantID = product.RestaurantID;
                    prod.ProductDescription = product.ProductDescription;
                    prod.ProductImage = product.ProductImage;
                    prod.ProductName = product.ProductName;
                    prod.ProductPrice = product.ProductPrice;



                    db.Product.Add(prod);
                    db.SaveChanges();
                }


            }
            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());


            }
            return View();
        }

    
    public ActionResult EditProduct(int productID)
    {
        if (!productID.Equals(null))
        {
            try
            {
                websitedbEntities db = new websitedbEntities();


                var prod = db.Product.SingleOrDefault(x => x.ProductID == productID);

                return View(prod);

            }

            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return View();
            }

        }
        return View();
    }

    [HttpPost]
    public ActionResult EditProduct(Product product)
    {
        try
        {
            websitedbEntities db = new websitedbEntities();



            Product prod = db.Product.SingleOrDefault(x => x.ProductID == product.ProductID);

            prod.RestaurantID = product.RestaurantID;
            prod.ProductDescription = product.ProductDescription;
            prod.ProductImage = product.ProductImage;
            prod.ProductName = product.ProductName;
            prod.ProductPrice = product.ProductPrice;


            db.SaveChanges();

            ViewBag.message = "Restaurant information updated successfully.";
            return View(prod);

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
