using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.siniflar;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    [Authorize]
    public class KargoController : Controller
    {
        Context c = new Context();
        public ActionResult Index(string p)
        {

            var k = from x in c.kargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }

            return View(k.ToList());

        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karekterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string kod = s1.ToString() + karekterler[k1] + s2 + karekterler[k2] + s3 + karekterler[k3];


            ViewBag.Takipkod = kod;


            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)

        {
            c.kargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoDetay(string id)
        {

            var degerler = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();
            //var dpt = c.Departmanlars.Where(x => x.karg == id).Select(y => y.DepartmanAd).FirstOrDefault();

            ViewBag.d = degerler;

            return View(degerler);


        }

    }
}