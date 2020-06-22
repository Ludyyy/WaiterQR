using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using QRCoder;

namespace WaiterQR.Controllers
{
    public class QrCodeController : Controller
    {
        //// GET: QrCode
        //public ActionResult ScanQrCode()
        //{
        //    return View();
        //}
        
        public ActionResult CreateQrCode(int restaurantid, int restauranttable)
        {
            string qrText = "https://" + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/product/showproduct?restaurantid=" + restaurantid + "&restauranttable=" + restauranttable;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText,QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            ViewBag.message = qrText;
            return View(BitmapToBytes(qrCodeImage));
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
           
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
