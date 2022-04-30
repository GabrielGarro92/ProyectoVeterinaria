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
    public class TipoCitasController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: TipoCitas
        public ActionResult Index()
        {
            return View(db.TipoCitas.ToList());
        }

        // GET: TipoCitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCitas tipoCitas = db.TipoCitas.Find(id);
            if (tipoCitas == null)
            {
                return HttpNotFound();
            }
            return View(tipoCitas);
        }

        // GET: TipoCitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipo,descTipo")] TipoCitas tipoCitas)
        {
            if (ModelState.IsValid)
            {
                db.TipoCitas.Add(tipoCitas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCitas);
        }

        // GET: TipoCitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCitas tipoCitas = db.TipoCitas.Find(id);
            if (tipoCitas == null)
            {
                return HttpNotFound();
            }
            return View(tipoCitas);
        }

        // POST: TipoCitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipo,descTipo")] TipoCitas tipoCitas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCitas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCitas);
        }

        // GET: TipoCitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCitas tipoCitas = db.TipoCitas.Find(id);
            if (tipoCitas == null)
            {
                return HttpNotFound();
            }
            return View(tipoCitas);
        }

        // POST: TipoCitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCitas tipoCitas = db.TipoCitas.Find(id);
            db.TipoCitas.Remove(tipoCitas);
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
