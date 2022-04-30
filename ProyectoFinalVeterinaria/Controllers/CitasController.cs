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
    public class CitasController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Citas
        public ActionResult Index()
        {
            var citas = db.Citas.Include(c => c.Clinicas).Include(c => c.Duenos).Include(c => c.TipoCitas).Include(c => c.Veterinarios);
            return View(citas.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.idClinica = new SelectList(db.Clinicas, "idClinica", "direccion");
            ViewBag.idDueno = new SelectList(db.Duenos, "idDueno", "nombreDueno");
            ViewBag.idTipo = new SelectList(db.TipoCitas, "idTipo", "descTipo");
            ViewBag.idTipo = new SelectList(db.Veterinarios, "idVeterinario", "nombre");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCita,fecha,idClinica,idDueno,idTipo,idVeterinario")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(citas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClinica = new SelectList(db.Clinicas, "idClinica", "direccion", citas.idClinica);
            ViewBag.idDueno = new SelectList(db.Duenos, "idDueno", "nombreDueno", citas.idDueno);
            ViewBag.idTipo = new SelectList(db.TipoCitas, "idTipo", "descTipo", citas.idTipo);
            ViewBag.idTipo = new SelectList(db.Veterinarios, "idVeterinario", "nombre", citas.idTipo);
            return View(citas);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClinica = new SelectList(db.Clinicas, "idClinica", "direccion", citas.idClinica);
            ViewBag.idDueno = new SelectList(db.Duenos, "idDueno", "nombreDueno", citas.idDueno);
            ViewBag.idTipo = new SelectList(db.TipoCitas, "idTipo", "descTipo", citas.idTipo);
            ViewBag.idTipo = new SelectList(db.Veterinarios, "idVeterinario", "nombre", citas.idTipo);
            return View(citas);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCita,fecha,idClinica,idDueno,idTipo,idVeterinario")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClinica = new SelectList(db.Clinicas, "idClinica", "direccion", citas.idClinica);
            ViewBag.idDueno = new SelectList(db.Duenos, "idDueno", "nombreDueno", citas.idDueno);
            ViewBag.idTipo = new SelectList(db.TipoCitas, "idTipo", "descTipo", citas.idTipo);
            ViewBag.idTipo = new SelectList(db.Veterinarios, "idVeterinario", "nombre", citas.idTipo);
            return View(citas);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Citas citas = db.Citas.Find(id);
            db.Citas.Remove(citas);
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
