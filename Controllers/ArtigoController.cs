using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GestaoArtigos.Models;


namespace GestaoArtigos.Controllers
{
    public class ArtigoController : Controller
    {
        // GET: Artigo/Index
        public ActionResult Index()
        {
            DbModels dbModel = new DbModels();

            return View(dbModel.tb_artigos.ToList());
        }

        // GET: Artigo/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.tb_artigos.Where(x => x.id_artigo == id).FirstOrDefault());
            }
        }

        // GET: Artigo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artigo/Create
        [HttpPost]
        public ActionResult Create(tb_artigos artigoModel, tb_utilizadores user)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    if (dbModel.tb_artigos.Any(p => p.referencia == artigoModel.referencia))
                    {
                        ViewBag.ErrorMessage = "A referência já existe!";
                        return View();
                    }
                    artigoModel.data_criado = DateTime.Now;
                    artigoModel.data_alterado = DateTime.Now;
                    artigoModel.id_utilizador = (int)Session["id_utilizador"];
                    dbModel.tb_artigos.Add(artigoModel);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artigo/Edit/5
        public ActionResult Edit(int id)
        {
            tb_artigos artigoModel = new tb_artigos();  
            using (DbModels dbModel = new DbModels())
            {
                artigoModel = dbModel.tb_artigos.Where(x => x.id_artigo == id).FirstOrDefault();
            }
            return View(artigoModel);
        }

        // POST: Artigo/Edit/5
        [HttpPost]
        public ActionResult Edit(tb_artigos artigoModel)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {

                    artigoModel.data_alterado = DateTime.Now;
                    dbModel.Entry(artigoModel).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(artigoModel);
            }
        }

        // GET: Artigo/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.tb_artigos.Where(x => x.id_artigo == id).FirstOrDefault());
            }
        }

        // POST: Artigo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels dbModel = new DbModels())
                {
                    tb_artigos artigo = dbModel.tb_artigos.Where(x => x.id_artigo == id).FirstOrDefault();
                    dbModel.tb_artigos.Remove(artigo);
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
