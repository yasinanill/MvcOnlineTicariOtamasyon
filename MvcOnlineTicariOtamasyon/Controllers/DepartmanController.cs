using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.siniflar;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    [Authorize]

    public class DepartmanController : Controller
    {
        Context c = new Context();// GET: Departman
        public ActionResult Index()
        {
            var degerler = c.Departmanlars.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        } 
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departmanlar d)

        {
            c.Departmanlars.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)

        {
            var deger = c.Departmanlars.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)

        {
            var deger = c.Departmanlars.Find(id);

            return View("DepartmanGetir",deger);

        }
        public ActionResult DepartmanGuncelle(Departmanlar k)
        {
            var dpt = c.Departmanlars.Find(k.DepartmanID);
            dpt.DepartmanAd = k.DepartmanAd;
            c.SaveChanges();
 
            return RedirectToAction("Index");


        }
        public ActionResult DepartmanDetay(int id)
        {

            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmanlars.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            
            ViewBag.d = dpt;

            return View(degerler);


        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();

            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd+" "+y.PersonelSoyad).FirstOrDefault();
            ViewBag.d = per;
            return View(degerler);

        }
    }
}