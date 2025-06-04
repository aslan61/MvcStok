using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.URUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(URUNLER urn)
        {
            var ktg = db.KATEGORILER.Where(m => m.KATEGORIID == urn.KATEGORILER.KATEGORIID).FirstOrDefault();
            urn.KATEGORILER = ktg;
            db.URUNLER.Add(urn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.URUNLER.Find(id);
            db.URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.URUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(URUNLER urn)
        {
            var urun = db.URUNLER.Find(urn.URUNID);
            urun.URUNAD = urn.URUNAD;
            urun.MARKA = urn.MARKA;
            urun.STOK = urn.STOK;
            urun.FİYAT = urn.FİYAT;
            //urun.URUNKATEGORİ = urn.URUNKATEGORİ;
            var ktg = db.KATEGORILER.Where(m => m.KATEGORIID == urn.KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORİ = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}