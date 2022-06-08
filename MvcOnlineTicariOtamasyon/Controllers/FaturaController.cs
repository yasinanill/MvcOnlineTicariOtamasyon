using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.siniflar;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    [Authorize]
    public class FaturaController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Faturalars.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();


        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {

            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult FaturaGetir(int id)
        {

            var fat = c.Faturalars.Find(id);

            return View("FaturaGetir",fat);


        }



        public ActionResult FaturaGuncelle(Faturalar f)
        {

            var ftr = c.Faturalars.Find(f.FaturaID);
            ftr.FaturaSeriNO = f.FaturaSeriNO;
            ftr.FaturaSiraNO = f.FaturaSiraNO;
            ftr.Saat = f.Saat;
            ftr.Tarih = f.Tarih;
            ftr.TeslimAlan = f.TeslimAlan;
            ftr.TeslimEden = f.TeslimEden;
            ftr.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();


            return RedirectToAction("Index");


        }
        public ActionResult FaturaDetay(int id)
        {

            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);


        } 
        [HttpGet]
        public ActionResult YeniKalem()
        {

         
            return View();


        }[HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {

            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}