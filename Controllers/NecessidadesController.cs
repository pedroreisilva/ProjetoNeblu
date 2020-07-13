using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestaoArtigos.Models;

namespace GestaoArtigos.Controllers
{
    public class NecessidadesController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Necessidades/Index
        public ActionResult Index()
        {
            return View(db.tb_necessidades.ToList());
        }

        // GET: Necessidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_necessidades tb_necessidades = db.tb_necessidades.Find(id);
            if (tb_necessidades == null)
            {
                return HttpNotFound();
            }
            return View(tb_necessidades);
        }

        // GET: Necessidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Necessidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,codigo_artigo,quantidade_atual,estado,data_criado,data_alterado,codigo_utilizador")] tb_necessidades tb_necessidades)
        {
            if (ModelState.IsValid)
            {
                db.tb_necessidades.Add(tb_necessidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_necessidades);
        }

        // GET: Necessidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_necessidades tb_necessidades = db.tb_necessidades.Find(id);
            if (tb_necessidades == null)
            {
                return HttpNotFound();
            }
            return View(tb_necessidades);
        }

        // POST: Necessidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,codigo_artigo,quantidade_atual,estado,data_criado,data_alterado,codigo_utilizador")] tb_necessidades tb_necessidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_necessidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_necessidades);
        }

        // GET: Necessidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_necessidades tb_necessidades = db.tb_necessidades.Find(id);
            if (tb_necessidades == null)
            {
                return HttpNotFound();
            }
            return View(tb_necessidades);
        }

        // POST: Necessidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_necessidades tb_necessidades = db.tb_necessidades.Find(id);
            db.tb_necessidades.Remove(tb_necessidades);
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
