using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = db.MUSTERILER.ToList();
            //var degerler=from d in db.MUSTERILER select d;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            //}
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(MUSTERILER mstr)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.MUSTERILER.Add(mstr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.MUSTERILER.Find(id);
            db.MUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.MUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(MUSTERILER id)
        {
            var mus = db.MUSTERILER.Find(id.MUSTERIID);
            mus.MUSTERIAD = id.MUSTERIAD;
            mus.MUSTERISOYAD = id.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}