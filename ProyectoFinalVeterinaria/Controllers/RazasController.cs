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
    public class RazasController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Razas
        public ActionResult Index()
        {
            return View(db.Razas.ToList());
        }

        // GET: Razas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Razas razas = db.Razas.Find(id);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // GET: Razas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Razas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRaza,descRaza")] Razas razas)
        {
            if (ModelState.IsValid)
            {
                db.Razas.Add(razas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(razas);
        }

        // GET: Razas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Razas razas = db.Razas.Find(id);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // POST: Razas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRaza,descRaza")] Razas razas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(razas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(razas);
        }

        // GET: Razas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Razas razas = db.Razas.Find(id);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // POST: Razas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Razas razas = db.Razas.Find(id);
            db.Razas.Remove(razas);
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
