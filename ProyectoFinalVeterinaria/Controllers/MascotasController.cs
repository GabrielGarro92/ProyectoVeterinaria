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
    public class MascotasController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Mascotas
        public ActionResult Index()
        {
            var mascotas = db.Mascotas.Include(m => m.Duenos).Include(m => m.Historiales).Include(m => m.Razas);
            return View(mascotas.ToList());
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascotas mascotas = db.Mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // GET: Mascotas/Create
        public ActionResult Create()
        {
            ViewBag.idDueno = new SelectList(db.Duenos, "idDueno", "nombreDueno");
            ViewBag.idHistorial = new SelectList(db.Historiales, "idHistorial", "motivoConsulta");
            ViewBag.idRaza = new SelectList(db.Razas, "idRaza", "descRaza");
            return View();
        }

        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMascotas,nombreMascota,idRaza,edad,idHistorial,idDueno")] Mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascotas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDueno = new SelectList(db.Duenos, "idDueno", "nombreDueno", mascotas.idDueno);
            ViewBag.idHistorial = new SelectList(db.Historiales, "idHistorial", "motivoConsulta", mascotas.idHistorial);
            ViewBag.idRaza = new SelectList(db.Razas, "idRaza", "descRaza", mascotas.idRaza);
            return View(mascotas);
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascotas mascotas = db.Mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDueno = new SelectList(db.Duenos, "idDueno", "nombreDueno", mascotas.idDueno);
            ViewBag.idHistorial = new SelectList(db.Historiales, "idHistorial", "motivoConsulta", mascotas.idHistorial);
            ViewBag.idRaza = new SelectList(db.Razas, "idRaza", "descRaza", mascotas.idRaza);
            return View(mascotas);
        }

        // POST: Mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMascotas,nombreMascota,idRaza,edad,idHistorial,idDueno")] Mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDueno = new SelectList(db.Duenos, "idDueno", "nombreDueno", mascotas.idDueno);
            ViewBag.idHistorial = new SelectList(db.Historiales, "idHistorial", "motivoConsulta", mascotas.idHistorial);
            ViewBag.idRaza = new SelectList(db.Razas, "idRaza", "descRaza", mascotas.idRaza);
            return View(mascotas);
        }

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascotas mascotas = db.Mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascotas mascotas = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascotas);
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
