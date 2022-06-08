using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcOnlineTicariOtamasyon.Models.siniflar;
using Context = MvcOnlineTicariOtamasyon.Models.siniflar.Context;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Katagori - urun sayisi").AddLegend("Stok").AddSeries("degerler", xValue: new[] { "Televizyon ", "telefon ", "masa", "ekipman" }, yValues: new[] { 50, 54, 85, 95 }).Write();


            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();


            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x =>xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 600, height: 600).AddTitle("Stoklar").AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();

        }
        public ActionResult VisualizeUrunResult()
        {


            return Json(UrunListesi(),JsonRequestBehavior.AllowGet);

        }
        public List<sinif1> UrunListesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
                urunad = " Bilgisayar",
                stok = 120

            });
            snf.Add(new sinif1()
            {
                urunad = " Mobilya",
                stok = 12

            });
            snf.Add(new sinif1()
            {
                urunad = " Masa",
                stok = 100

            });
            snf.Add(new sinif1()
            {
                urunad = " Telefon",
                stok = 120

            });
            snf.Add(new sinif1()
            {
                urunad = " Monitor",
                stok = 150

            });
            return snf;
        }
        public ActionResult Index5()
        {
            return View();

        }
            public ActionResult VisualizeUrunResult2()
        {

            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif2> UrunListesi2()
        {
            List<Sinif2> snf = new List<Sinif2>();
            
            using (var  c = new Context())
            {
                snf = c.Uruns.Select(x => new Sinif2
                {
                    urn = x.UrunAd,
                    stk = x.Stok
                }).ToList();


            }

            return snf;
           
        }
    }
}