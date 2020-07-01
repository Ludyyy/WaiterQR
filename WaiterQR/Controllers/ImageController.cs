//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.IO;
//using WaiterQR.Database;
//using Image = WaiterQR.Database.Image;
//using System.Data.Entity.Infrastructure;

//namespace WaiterQR.Controllers
//{
//    public class ImageController : Controller
//    {
//        // GET: Image
//        [HttpGet]
//        public ActionResult Add()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Add(Image image)
//        {
//            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
//            string extension = Path.GetExtension(image.ImageFile.FileName);
//            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
//            image.ImagePath = "~/Image/"+ fileName;
//            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
//            image.ImageFile.SaveAs(fileName);
//            using (websitedbEntities db = new websitedbEntities())
//            {
//                db.Image.Add(image);
//                db.SaveChanges();
//            }
//            ModelState.Clear();
//            return View();
//        }
//        [HttpGet]
//        public ActionResult View(int id)
//        {
//            Image image = new Image();
//            using (websitedbEntities db = new websitedbEntities())
//            {
//                image = db.Image.Where(x => x.ImageID == id).FirstOrDefault();

//            }
//                return View(image);
//        }
//    }
//}