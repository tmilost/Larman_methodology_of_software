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
    public class UgovorController : Controller
    {
        private AutoPlac1Entities1 db = new AutoPlac1Entities1();

        // GET: Ugovor
        [Authorize]
        public ActionResult Index(string searchBrojUgovora)
        {
            var ugovors = db.Ugovors.Include(u => u.Prodata_vozila).Include(u => u.Radnik);
            Ugovor p = new Ugovor();


            //vraca celu listu ako su polja prazna//
            if (string.IsNullOrWhiteSpace(searchBrojUgovora) )

                return View(ugovors.ToList());

            else if (searchBrojUgovora != null )
            {
                int id = Convert.ToInt32(searchBrojUgovora);
                return View(ugovors.Where(x => x.BrojUgovora==(id)).ToList());
            }
          

            else
                return View(ugovors.ToList());
        }

        // GET: Ugovor/Details/5
        [Authorize]

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

        // GET: Ugovor/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDProdatogVozila = new SelectList(db.Prodata_vozila, "IDVozila", "IDVozila");
            ViewBag.IDRadnika = new SelectList(db.Radniks, "IDRadnika", "IDRadnika");
            return View();
        }

        // POST: Ugovor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "BrojUgovora,Marka,Model,Godiste,Cena,Boja,ImeKupca,PrezimeKupca,ImeProdavca,PrezimeProdavca,JBMGKupca,IDRadnika,IDProdatogVozila")] Ugovor ugovor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Ugovors.Add(ugovor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    Response.Write(@"<script language= 'javascript'>alert('Vec postoji broj ugovora.');</script>");
                }
            }

            ViewBag.IDProdatogVozila = new SelectList(db.Prodata_vozila, "IDVozila", "IDVozila", ugovor.IDProdatogVozila);
            ViewBag.IDRadnika = new SelectList(db.Radniks, "IDRadnika", "IDRadnika", ugovor.IDRadnika);
            return View(ugovor);
        }

        // GET: Ugovor/Edit/5
        [Authorize]
        [Authorize(Users = "tmilost")]
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
            ViewBag.IDProdatogVozila = new SelectList(db.Prodata_vozila, "IDVozila", "IDVozila", ugovor.IDProdatogVozila);
            ViewBag.IDRadnika = new SelectList(db.Radniks, "IDRadnika", "IDRadnika", ugovor.IDRadnika);
            return View(ugovor);
        }

        // POST: Ugovor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "tmilost")]
        public ActionResult Edit([Bind(Include = "BrojUgovora,Marka,Model,Godiste,Cena,Boja,ImeKupca,PrezimeKupca,ImeProdavca,PrezimeProdavca,JBMGKupca,IDRadnika,IDProdatogVozila")] Ugovor ugovor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ugovor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProdatogVozila = new SelectList(db.Prodata_vozila, "IDVozila", "IDVozila", ugovor.IDProdatogVozila);
            ViewBag.IDRadnika = new SelectList(db.Radniks, "IDRadnika", "IDRadnika", ugovor.IDRadnika);
            return View(ugovor);
        }

        // GET: Ugovor/Delete/5
        [Authorize(Users = "tmilost")]
        [Authorize]
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

        // POST: Ugovor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "tmilost")]
        [Authorize]
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
