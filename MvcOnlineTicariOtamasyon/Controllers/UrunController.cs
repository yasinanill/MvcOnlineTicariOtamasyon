using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.siniflar;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }

            return View(urunler.ToList().ToPagedList(sayfa, 5));
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {

            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAD,
                                               Value = x.KategoriID.ToString()


                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAD,
                                               Value = x.KategoriID.ToString()


                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var deger = c.Uruns.Find(id);

            return View("UrunGetir", deger);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.UrunID);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var deger = c.Uruns.ToList();
            return View(deger);


        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.PersonelAd,
                                               Value = x.PersonelID.ToString()



                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var deger2 = c.Uruns.Find(id);
            ViewBag.dgr2 = deger2.UrunID;
            ViewBag.dgr3 = deger2.SatisFiyat;

            return View();

        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {

            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");


        }
    }
}