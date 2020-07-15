// In this class the QR code is generated. It takes the link which is needed by the customers to get to the menu and encodes it as a qr code.
// In the end it creates a bitmap image which is visualized and accessible for the restaurant owners
// Authors: Dennis Keles, Dennis Ludwig, Sheng Jing Ly

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
    [Authorize]

    public class QrCodeController : Controller
    {

        public ActionResult CreateQrCode(int tableid)
        {
            string qrText = "https://" + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port) + "/menu/showmenu?tableid=" +tableid;
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
