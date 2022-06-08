using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtamasyon.Models.siniflar;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    [Authorize]
    public class CariPanelController : Controller
    {
        Context c = new Context();
       
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
           
            var degerler = c.Mesajlars.Where(x => x.Alici == mail).ToList();

            ViewBag.m = mail;

            var mailid = c.Carilers.Where(x => x.CariMail == mail).Select(x => x.CariID).FirstOrDefault();
            ViewBag.mid = mailid;

            var toplamsatis = c.SatisHarekets.Where(x => x.Cariid == mailid).Count();
            ViewBag.tps = toplamsatis;
            if (toplamsatis != 0)

            {

                var toplamOdeme = c.SatisHarekets.Where(x => x.Cariid == mailid).Select(y => y.ToplamTutar).Sum();

                ViewBag.tTutar = toplamOdeme;



                var toplamUrun = c.SatisHarekets.Where(x => x.Cariid == mailid).Select(y => y.Adet).Sum();

                ViewBag.tUrun = toplamUrun;

            }

            else

            {

                ViewBag.tTutar = 0;

                ViewBag.tUrun = 0;

            }
            

            var adsoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + "" + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoy = adsoyad;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {

            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);

        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x=>x.Alici==mail).OrderByDescending(x => x.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(x=>x.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var mjd = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
           
            return View(mjd);
        }


        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();

        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip(string p)
        {

            var k = from x in c.kargoDetays select x;

            return View(k.ToList());
           

        }
        public ActionResult KargoDetay(string id)
        {

            var degerler = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();
            //var dpt = c.Departmanlars.Where(x => x.karg == id).Select(y => y.DepartmanAd).FirstOrDefault();

            ViewBag.d = degerler;

            return View(degerler);


            
        }
        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

        public PartialViewResult Partail1()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("Partail1", caribul);
        }
        public PartialViewResult Partail2()
        {
            var mail = (string)Session["CariMail"];
            var veriler = c.Mesajlars.Where(x => x.Gonderici == "admin").ToList();
            
            return PartialView("Partail2",veriler);

        }

        public ActionResult CariBilgiGuncelle(Cariler cr)
        {
            var cari = c.Carilers.Find(cr.CariID);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.CariMail = cr.CariMail;
            cari.CariSifre = cr.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}