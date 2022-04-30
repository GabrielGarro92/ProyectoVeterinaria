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
    public class HistorialesController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Historiales
        public ActionResult Index()
        {
            var historiales = db.Historiales.Include(h => h.Enfermedades).Include(h => h.Veterinarios);
            return View(historiales.ToList());
        }

        // GET: Historiales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historiales historiales = db.Historiales.Find(id);
            if (historiales == null)
            {
                return HttpNotFound();
            }
            return View(historiales);
        }

        // GET: Historiales/Create
        public ActionResult Create()
        {
            ViewBag.idEnfermedad = new SelectList(db.Enfermedades, "idEnfermedad", "nombreEnfermedad");
            ViewBag.idVeterinario = new SelectList(db.Veterinarios, "idVeterinario", "nombre");
            return View();
        }

        // POST: Historiales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHistorial,fecha,motivoConsulta,dignostico,idEnfermedad,idVeterinario")] Historiales historiales)
        {
            if (ModelState.IsValid)
            {
                db.Historiales.Add(historiales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEnfermedad = new SelectList(db.Enfermedades, "idEnfermedad", "nombreEnfermedad", historiales.idEnfermedad);
            ViewBag.idVeterinario = new SelectList(db.Veterinarios, "idVeterinario", "nombre", historiales.idVeterinario);
            return View(historiales);
        }

        // GET: Historiales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historiales historiales = db.Historiales.Find(id);
            if (historiales == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEnfermedad = new SelectList(db.Enfermedades, "idEnfermedad", "nombreEnfermedad", historiales.idEnfermedad);
            ViewBag.idVeterinario = new SelectList(db.Veterinarios, "idVeterinario", "nombre", historiales.idVeterinario);
            return View(historiales);
        }

        // POST: Historiales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHistorial,fecha,motivoConsulta,dignostico,idEnfermedad,idVeterinario")] Historiales historiales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historiales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEnfermedad = new SelectList(db.Enfermedades, "idEnfermedad", "nombreEnfermedad", historiales.idEnfermedad);
            ViewBag.idVeterinario = new SelectList(db.Veterinarios, "idVeterinario", "nombre", historiales.idVeterinario);
            return View(historiales);
        }

        // GET: Historiales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historiales historiales = db.Historiales.Find(id);
            if (historiales == null)
            {
                return HttpNotFound();
            }
            return View(historiales);
        }

        // POST: Historiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historiales historiales = db.Historiales.Find(id);
            db.Historiales.Remove(historiales);
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
