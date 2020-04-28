using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoPlac0;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AutoPlac0.Controllers
{
    public class VoziloController : Controller
    {
        private AutoPlac1Entities1 db = new AutoPlac1Entities1();

        // GET: Vozilo
        [Authorize]
        public ActionResult Index(string searchMod, string searchMarka)
        {
            var Voziloes = db.Voziloes;
            Vozilo v = new Vozilo();


            //vraca celu listu ako su polja prazna//
            if (string.IsNullOrWhiteSpace(searchMarka) && string.IsNullOrWhiteSpace(searchMod))

                return View(Voziloes.ToList());

            else if (searchMarka != null && string.IsNullOrWhiteSpace(searchMod))
            {
                return View(Voziloes.Where(x => x.Marka.Equals(searchMarka)).ToList());
            }
            else if (string.IsNullOrWhiteSpace(searchMarka) && searchMod != null)
                return View(Voziloes.Where(x => x.Model.Equals(searchMod)).ToList());
            else if (searchMarka != null && searchMod != null)
                return View(Voziloes.Where(x => x.Marka.Equals(searchMarka) && x.Model.Equals(searchMod)).ToList());

            else
                return View(db.Voziloes.ToList());
        }

        // GET: Vozilo/Details/5
        [Authorize]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vozilo vozilo = db.Voziloes.Find(id);
            if (vozilo == null)
            {
                return HttpNotFound();
            }
            return View(vozilo);
        }

        // GET: Vozilo/Create
        [Authorize]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Vozilo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDVozila,Marka,Model,Godiste,Cena,Boja,BrojSedista,TipGoriva")] Vozilo vozilo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Voziloes.Add(vozilo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    Response.Write(@"<script language= 'javascript'>alert('Vec postoji ID vozila.');</script>");
                }
            }

            return View(vozilo);
        }

        // GET: Vozilo/Edit/5
        [Authorize]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vozilo vozilo = db.Voziloes.Find(id);
            if (vozilo == null)
            {
                return HttpNotFound();
            }
            return View(vozilo);
        }

        // POST: Vozilo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDVozila,Marka,Model,Godiste,Cena,Boja,BrojSedista,TipGoriva")] Vozilo vozilo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vozilo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vozilo);
        }

        // GET: Vozilo/Delete/5
        [Authorize]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vozilo vozilo = db.Voziloes.Find(id);
            if (vozilo == null)
            {
                return HttpNotFound();
            }
            return View(vozilo);
        }

        // POST: Vozilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vozilo vozilo = db.Voziloes.Find(id);
            using (SqlConnection connection = new SqlConnection("Initial Catalog = AutoPlac1; Data Source=DESKTOP-L35EC78; integrated security=True;"))
            {
                String query = "INSERT INTO dbo.Prodata_vozila (IDVozila, Marka, Model, Godiste, Cena, Boja, BrojSedista, TipGoriva) VALUES (@id, @marka, @model, @godiste, @cena, @boja, @brSedista, @tip)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@id", vozilo.IDVozila);
                    command.Parameters.AddWithValue("@marka", vozilo.Marka);
                    command.Parameters.AddWithValue("@model", vozilo.Model);
                    command.Parameters.AddWithValue("@godiste", vozilo.Godiste);
                    command.Parameters.AddWithValue("@cena", vozilo.Cena);
                    command.Parameters.AddWithValue("@boja", vozilo.Boja);
                    command.Parameters.AddWithValue("@brSedista", vozilo.BrojSedista);
                    command.Parameters.AddWithValue("@tip", vozilo.TipGoriva);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            db.Voziloes.Remove(vozilo);
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
