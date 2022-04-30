using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalVeterinaria.Models;

namespace ProyectoFinalVeterinaria.Controllers
{
    public class ClinicasController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Clinicas
        public ActionResult Index()
        {
            var clinicas = db.Clinicas.Include(c => c.Provincias);
            return View(clinicas.ToList());
        }

        // GET: Clinicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinicas clinicas = db.Clinicas.Find(id);
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // GET: Clinicas/Create
        public ActionResult Create()
        {
            ViewBag.idProvincia = new SelectList(db.Provincias, "idProvincia", "descProvincia");
            return View();
        }

        // POST: Clinicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClinica,telefono,direccion,idProvincia")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                db.Clinicas.Add(clinicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProvincia = new SelectList(db.Provincias, "idProvincia", "descProvincia", clinicas.idProvincia);
            return View(clinicas);
        }

        // GET: Clinicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinicas clinicas = db.Clinicas.Find(id);
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProvincia = new SelectList(db.Provincias, "idProvincia", "descProvincia", clinicas.idProvincia);
            return View(clinicas);
        }

        // POST: Clinicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClinica,telefono,direccion,idProvincia")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProvincia = new SelectList(db.Provincias, "idProvincia", "descProvincia", clinicas.idProvincia);
            return View(clinicas);
        }

        // GET: Clinicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinicas clinicas = db.Clinicas.Find(id);
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clinicas clinicas = db.Clinicas.Find(id);
            db.Clinicas.Remove(clinicas);
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
