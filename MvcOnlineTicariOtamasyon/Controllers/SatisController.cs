using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.siniflar;

namespace MvcOnlineTicariOtamasyon.Controllers
{

    public class SatisController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()



                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.CariAd,
                                               Value = x.CariID.ToString()



                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.PersonelAd + "" + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()

                                           }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3= deger3;

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)

        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()



                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.CariAd,
                                               Value = x.CariID.ToString()



                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.PersonelAd + "" + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()

                                           }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;


            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);


        }
        public ActionResult SatisGuncelle(SatisHareket p)
        {
           
            
            var sat = c.SatisHarekets.Find(p.SatisID);
            sat.Adet = p.Adet;
            sat.ToplamTutar = p.ToplamTutar;
            sat.Fiyat = p.Fiyat;
            sat.Cariid = p.Cariid;
            sat.Personelid = p.Personelid;
            sat.Tarih = p.Tarih;
            sat.Urunid = p.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
         
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(degerler);


        }
    }

}