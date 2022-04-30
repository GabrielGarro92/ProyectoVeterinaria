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
    public class VeterinariosController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Veterinarios
        public ActionResult Index()
        {
            return View(db.Veterinarios.ToList());
        }

        // GET: Veterinarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinarios veterinarios = db.Veterinarios.Find(id);
            if (veterinarios == null)
            {
                return HttpNotFound();
            }
            return View(veterinarios);
        }

        // GET: Veterinarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVeterinario,nombre,apellido,cedula,correo")] Veterinarios veterinarios)
        {
            if (ModelState.IsValid)
            {
                db.Veterinarios.Add(veterinarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veterinarios);
        }

        // GET: Veterinarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinarios veterinarios = db.Veterinarios.Find(id);
            if (veterinarios == null)
            {
                return HttpNotFound();
            }
            return View(veterinarios);
        }

        // POST: Veterinarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVeterinario,nombre,apellido,cedula,correo")] Veterinarios veterinarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinarios);
        }

        // GET: Veterinarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinarios veterinarios = db.Veterinarios.Find(id);
            if (veterinarios == null)
            {
                return HttpNotFound();
            }
            return View(veterinarios);
        }

        // POST: Veterinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veterinarios veterinarios = db.Veterinarios.Find(id);
            db.Veterinarios.Remove(veterinarios);
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
