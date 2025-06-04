using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler=db.KATEGORILER.ToList();
            var degerler = db.KATEGORILER.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(KATEGORILER ktg)
        {
            if (!ModelState.IsValid)
            {
                return View("Yenikategori");
            }
            db.KATEGORILER.Add(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.KATEGORILER.Find(id);
            db.KATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.KATEGORILER.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult Guncelle(KATEGORILER id)
        {
            var ktg = db.KATEGORILER.Find(id.KATEGORIID);
            ktg.KATEGORIAD = id.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}