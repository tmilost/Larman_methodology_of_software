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
    public class Prodata_vozilaController : Controller
    {
        private AutoPlac1Entities1 db = new AutoPlac1Entities1();

        // GET: Prodata_vozila
        [Authorize(Users = "tmilost")]
        [Authorize]
        public ActionResult Index(string searchMod, string searchMarka)
        {
            
            var prodata_vozila = db.Prodata_vozila;
            Prodata_vozila p = new Prodata_vozila();


            //vraca celu listu ako su polja prazna//
            if (string.IsNullOrWhiteSpace(searchMarka) && string.IsNullOrWhiteSpace(searchMod))

                return View(prodata_vozila.ToList());

            else if (searchMarka != null && string.IsNullOrWhiteSpace(searchMod))
            {
                return View(prodata_vozila.Where(x => x.Marka.Equals(searchMarka)).ToList());
            }
            else if (string.IsNullOrWhiteSpace(searchMarka) && searchMod != null)
                return View(prodata_vozila.Where(x => x.Model.Equals(searchMod)).ToList());
            else if (searchMarka != null && searchMod != null)
                return View(prodata_vozila.Where(x => x.Marka.Equals(searchMarka) && x.Model.Equals(searchMod)).ToList());

            else
                return View(prodata_vozila.ToList());

        }

        // GET: Prodata_vozila/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodata_vozila prodata_vozila = db.Prodata_vozila.Find(id);
            if (prodata_vozila == null)
            {
                return HttpNotFound();
            }
            return View(prodata_vozila);
        }

        // GET: Prodata_vozila/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prodata_vozila/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDVozila,Marka,Model,Godiste,Cena,Boja,BrojSedista,TipGoriva")] Prodata_vozila prodata_vozila)
        {
            if (ModelState.IsValid)
            {
                db.Prodata_vozila.Add(prodata_vozila);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prodata_vozila);
        }

        // GET: Prodata_vozila/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodata_vozila prodata_vozila = db.Prodata_vozila.Find(id);
            if (prodata_vozila == null)
            {
                return HttpNotFound();
            }
            return View(prodata_vozila);
        }

        // POST: Prodata_vozila/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDVozila,Marka,Model,Godiste,Cena,Boja,BrojSedista,TipGoriva")] Prodata_vozila prodata_vozila)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodata_vozila).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodata_vozila);
        }

        // GET: Prodata_vozila/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodata_vozila prodata_vozila = db.Prodata_vozila.Find(id);
            if (prodata_vozila == null)
            {
                return HttpNotFound();
            }
            return View(prodata_vozila);
        }

        // POST: Prodata_vozila/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Prodata_vozila prodata_vozila = db.Prodata_vozila.Find(id);
            db.Prodata_vozila.Remove(prodata_vozila);
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
