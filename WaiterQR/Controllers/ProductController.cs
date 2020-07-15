// This class defines the product handling such as Editing, Adding, Deleting and Showing of different products.
// Authors: Dennis Keles, Dennis Ludwig, Sheng Jing Ly

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using WaiterQR.Database;
using WaiterQR.Models;
using System.IO;


namespace WaiterQR.Controllers
{
    [Authorize]

    public class ProductController : Controller
    {
        
        // GET: Product
        public ActionResult ShowProduct(int? restaurantid)
        {
            if (restaurantid == null)
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
            else
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

                    using (websitedbEntities db = new websitedbEntities())
                    {
                        ViewBag.RestaurantName = db.Restaurant.Find(restaurantid).Name;
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

                byte[] imgData;
                using (BinaryReader reader = new BinaryReader(product.ImageFile.InputStream))
                {
                    imgData = reader.ReadBytes((int)product.ImageFile.InputStream.Length);
                }

                using (websitedbEntities db = new websitedbEntities())
                {

                    Product prod = new Product();
                    prod.RestaurantID = product.RestaurantID;
                    prod.ProductDescription = product.ProductDescription;
                    prod.ProductName = product.ProductName;
                    prod.ImagePath = Convert.ToBase64String(imgData);

                    if ((decimal.Parse(product.ProductPrice) > 0 && !product.ProductPrice.Contains('.'))){
                        prod.ProductPrice = product.ProductPrice;
                        db.Product.Add(prod);
                        db.SaveChanges();
                        return RedirectToAction("ShowProduct", new { restaurantid = prod.RestaurantID });

                    }
                    else
                    {
                        ViewBag.PriceError = "Please enter a price in the format xxx,yy";
                        return View();
                    }


                }
              
            }
            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());

                return View();
            }
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
                byte[] imgData;
                using (BinaryReader reader = new BinaryReader(product.ImageFile.InputStream))
                {
                    imgData = reader.ReadBytes((int)product.ImageFile.InputStream.Length);
                }
                using (websitedbEntities db = new websitedbEntities())
                {
                    Product prod = db.Product.SingleOrDefault(x => x.ProductID == product.ProductID);

                    prod.RestaurantID = product.RestaurantID;
                    prod.ProductDescription = product.ProductDescription;
                    prod.ProductName = product.ProductName;
                    prod.ProductPrice = product.ProductPrice;
                    prod.ImagePath = Convert.ToBase64String(imgData);
                   
                    if ((decimal.Parse(product.ProductPrice) > 0 && !product.ProductPrice.Contains('.')))
                    {
                        prod.ProductPrice = product.ProductPrice;
                        db.SaveChanges();

                        ViewBag.message = "Restaurant information updated successfully.";
                        return RedirectToAction("ShowProduct", new { restaurantid = prod.RestaurantID });

                    }
                    else
                    {
                        ViewBag.PriceError = "Please enter a price in the format xxx,yy";
                        return View();
                    }

                }
            }
            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return View();
            }
        }
        public ActionResult DeleteProduct(int productID)
        {
            try
            {
                using (websitedbEntities db = new websitedbEntities())
                {
                    Product p = db.Product.Find(productID);
                    db.Product.Remove(p);
                    db.SaveChanges();
                }
                return RedirectToAction("ShowProduct");

            }
            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());
                return RedirectToAction("ShowProduct");

            }

        }
    }
}

    

