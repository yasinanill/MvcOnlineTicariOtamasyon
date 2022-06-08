using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtamasyon.Models.siniflar;

namespace MvcOnlineTicariOtamasyon.Controllers
{
    [Authorize]
    public class GaleriController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}