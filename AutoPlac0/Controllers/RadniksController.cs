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
    public class RadniksController : Controller
    {
        private AutoPlac1Entities1 db = new AutoPlac1Entities1();

        // GET: Radniks
        [Authorize(Users = "tmilost")]
        [Authorize]
        public ActionResult Index(string searchIme, string searchPrezime)
        {

            var Radniks = db.Radniks;
            Radnik p = new Radnik();


            //vraca celu listu ako su polja prazna//
            if (string.IsNullOrWhiteSpace(searchIme) && string.IsNullOrWhiteSpace(searchPrezime))

                return View(Radniks.ToList());

            else if (searchIme != null && string.IsNullOrWhiteSpace(searchPrezime))
            {
                return View(Radniks.Where(x => x.Ime.Equals(searchIme)).ToList());
            }
            else if (string.IsNullOrWhiteSpace(searchIme) && searchPrezime != null)
                return View(Radniks.Where(x => x.Prezime.Equals(searchPrezime)).ToList());
            else if (searchIme != null && searchPrezime != null)
                return View(Radniks.Where(x => x.Ime.Equals(searchIme) && x.Prezime.Equals(searchPrezime)).ToList());

            else
                return View(db.Radniks.ToList());
        }

        // GET: Radniks/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radnik radnik = db.Radniks.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        // GET: Radniks/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Radniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDRadnika,Ime,Prezime,JMBG")] Radnik radnik)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Radniks.Add(radnik);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    Response.Write(@"<script language= 'javascript'>alert('Vec postoji ID radnika.');</script>");
                }
            }
            return View(radnik);
        }

        // GET: Radniks/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radnik radnik = db.Radniks.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        // POST: Radniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDRadnika,Ime,Prezime,JMBG")] Radnik radnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(radnik);
        }

        // GET: Radniks/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radnik radnik = db.Radniks.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        // POST: Radniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Radnik radnik = db.Radniks.Find(id);
                db.Radniks.Remove(radnik);
                db.SaveChanges();
            }catch (Exception)
            {
                Response.Write(@"<script language= 'javascript'>alert('Ne moze se izbrisati radnik koji se nalazi u ugovoru');</script>");
            }
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
