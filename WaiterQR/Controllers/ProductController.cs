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
                //string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                //string extension = Path.GetExtension(product.ImageFile.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //product.ImagePath = "~/Image/" + fileName;
                //fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                //product.ImageFile.SaveAs(fileName);


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
                    prod.ProductPrice = product.ProductPrice;
                    prod.ImagePath = Convert.ToBase64String(imgData);

                  

                    db.Product.Add(prod);
                    db.SaveChanges();
                   
                }


            }
            catch (Exception e)
            {
                string s = string.Format("Fehler: {0}", e.Message);
                s = string.Format("Typ: {0}", e.GetType());


            }
            return RedirectToAction("ShowProduct", "Product");
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
            prod.ImagePath = product.ImagePath;
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
