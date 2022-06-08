using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class QRController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(kod,QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(10))
                {
                    //get graphic (10) goruntu kalitesini belli ediyor 10 ortalama
                    resim.Save(ms,ImageFormat.Png);
                    ViewBag.karekodimage = "data:image/png;base64"+ Convert.ToBase64String(ms.ToArray());

                }

            }
                return View();
        }
    }
}