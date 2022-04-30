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
    public class DuenosController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Duenos
        public ActionResult Index()
        {
            return View(db.Duenos.ToList());
        }

        // GET: Duenos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duenos duenos = db.Duenos.Find(id);
            if (duenos == null)
            {
                return HttpNotFound();
            }
            return View(duenos);
        }

        // GET: Duenos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Duenos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDueno,nombreDueno,primerApellido,segundoApellido,cedula,correo,telefono")] Duenos duenos)
        {
            if (ModelState.IsValid)
            {
                db.Duenos.Add(duenos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duenos);
        }

        // GET: Duenos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duenos duenos = db.Duenos.Find(id);
            if (duenos == null)
            {
                return HttpNotFound();
            }
            return View(duenos);
        }

        // POST: Duenos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDueno,nombreDueno,primerApellido,segundoApellido,cedula,correo,telefono")] Duenos duenos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duenos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duenos);
        }

        // GET: Duenos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duenos duenos = db.Duenos.Find(id);
            if (duenos == null)
            {
                return HttpNotFound();
            }
            return View(duenos);
        }

        // POST: Duenos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Duenos duenos = db.Duenos.Find(id);
            db.Duenos.Remove(duenos);
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
