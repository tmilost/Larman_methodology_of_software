using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoPlac0;

namespace AutoPlac0.Controllers
{
    public class UgovorsController : Controller
    {
        private AutoPlac1Entities1 db = new AutoPlac1Entities1();

        // GET: Ugovors
        public ActionResult Index()
        {
            var ugovors = db.Ugovors.Include(u => u.Prodata_vozila).Include(u => u.Radnik);
            return View(ugovors.ToList());
        }

        // GET: Ugovors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugovor ugovor = db.Ugovors.Find(id);
            if (ugovor == null)
            {
                return HttpNotFound();
            }
            return View(ugovor);
        }

        // GET: Ugovors/Create
        public ActionResult Create()
        {
            ViewBag.IDProdatogVozila = new SelectList(db.Prodata_vozila, "IDVozila", "Marka");
            ViewBag.IDRadnika = new SelectList(db.Radniks, "IDRadnika", "Ime");
            return View();
        }

        // POST: Ugovors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrojUgovora,Marka,Model,Godiste,Cena,Boja,ImeKupca,PrezimeKupca,ImeProdavca,PrezimeProdavca,JBMGKupca,IDRadnika,IDProdatogVozila")] Ugovor ugovor)
        {
            if (ModelState.IsValid)
            {
                db.Ugovors.Add(ugovor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProdatogVozila = new SelectList(db.Prodata_vozila, "IDVozila", "Marka", ugovor.IDProdatogVozila);
            ViewBag.IDRadnika = new SelectList(db.Radniks, "IDRadnika", "Ime", ugovor.IDRadnika);
            return View(ugovor);
        }

        // GET: Ugovors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugovor ugovor = db.Ugovors.Find(id);
            if (ugovor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProdatogVozila = new SelectList(db.Prodata_vozila, "IDVozila", "Marka", ugovor.IDProdatogVozila);
            ViewBag.IDRadnika = new SelectList(db.Radniks, "IDRadnika", "Ime", ugovor.IDRadnika);
            return View(ugovor);
        }

        // POST: Ugovors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrojUgovora,Marka,Model,Godiste,Cena,Boja,ImeKupca,PrezimeKupca,ImeProdavca,PrezimeProdavca,JBMGKupca,IDRadnika,IDProdatogVozila")] Ugovor ugovor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ugovor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProdatogVozila = new SelectList(db.Prodata_vozila, "IDVozila", "Marka", ugovor.IDProdatogVozila);
            ViewBag.IDRadnika = new SelectList(db.Radniks, "IDRadnika", "Ime", ugovor.IDRadnika);
            return View(ugovor);
        }

        // GET: Ugovors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ugovor ugovor = db.Ugovors.Find(id);
            if (ugovor == null)
            {
                return HttpNotFound();
            }
            return View(ugovor);
        }

        // POST: Ugovors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ugovor ugovor = db.Ugovors.Find(id);
            db.Ugovors.Remove(ugovor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
