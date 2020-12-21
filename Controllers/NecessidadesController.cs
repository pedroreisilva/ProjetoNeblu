using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GestaoArtigos.Models;

namespace GestaoArtigos.Controllers
{
    public class NecessidadesController : Controller
    {
        // GET: Necessidades/Index
        public ActionResult Index()
        {
            DbModels dbModel = new DbModels();

            return View(dbModel.tb_necessidades.ToList());

        }

        // GET: Necessidades/Details/5System.InvalidOperationException: 'The entity type tb_necessidades is not part of the model for the current context.'
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.tb_necessidades.Where(x => x.id_necessidade == id).FirstOrDefault());
            }
        }

        // GET: Necessidades/Create
        public ActionResult Create()
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(new NebluViewModel()
                {
                    ArtigosModel = dbModel.tb_artigos.ToList()
                });
            }
        }

        // POST: Necessidades/Create
        [HttpPost]
        public ActionResult Create(tb_necessidades necessidadeModel, tb_artigos artigoModel)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    if (dbModel.tb_necessidades.Any(p => p.id_artigo == artigoModel.id_artigo))
                    {
                        ViewBag.ErrorMessage = "O artigo já está listado!";
                        return View();
                    }
                    necessidadeModel.data_criado = DateTime.Now;
                    necessidadeModel.data_alterado = DateTime.Now;
                    necessidadeModel.id_utilizador = (int)Session["id_utilizador"];
                    dbModel.tb_necessidades.Add(necessidadeModel);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Necessidades/Edit/5
        public ActionResult Edit(int id)
        {
            tb_necessidades necessidadeModel = new tb_necessidades();
            using (DbModels dbModel = new DbModels())
            {
                necessidadeModel = dbModel.tb_necessidades.Where(x => x.id_necessidade == id).FirstOrDefault();
            }
            return View(necessidadeModel);
        }

        // POST: Necessidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(tb_necessidades necessidadeModel)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {

                    necessidadeModel.data_alterado = DateTime.Now;
                    dbModel.Entry(necessidadeModel).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(necessidadeModel);
            }
        }


        // GET: Necessidades/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.tb_necessidades.Where(x => x.id_necessidade == id).FirstOrDefault());
            }
        }

        // POST: Necessidades/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels dbModel = new DbModels())
                {
                    tb_necessidades necessidade = dbModel.tb_necessidades.Where(x => x.id_necessidade == id).FirstOrDefault();
                    dbModel.tb_necessidades.Remove(necessidade);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
