using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.siniflar;
namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler d)
        {
            c.Carilers.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");


        }  
        
        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);



        }
        public ActionResult CariGuncelle(Cariler k)
        {

            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var ktg = c.Carilers.Find(k.CariID);
            ktg.CariAd = k.CariAd;
            ktg.CariSoyad = k.CariSoyad;
            ktg.CariSehir = k.CariSehir;
            ktg.CariMail = k.CariMail;
            c.SaveChanges();
           
            return RedirectToAction("Index");

        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();

            var mus = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd+""+y.CariSoyad).FirstOrDefault();
            ViewBag.d = mus;
            return View(degerler);

        }

    }
}