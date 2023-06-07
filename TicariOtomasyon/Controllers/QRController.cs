using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string code) 
        {   
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator codeproduce=new QRCodeGenerator();
                QRCodeGenerator.QRCode _qrcode = codeproduce.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap _image = _qrcode.GetGraphic(10))
                {
                    _image.Save(ms, ImageFormat.Png);
                    ViewBag.qrcodeimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}