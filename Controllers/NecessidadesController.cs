using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestaoArtigos.Models;
using PagedList;

namespace GestaoArtigos.Controllers
{
    public class NecessidadesController : Controller
    {
        // GET: Necessidades/Index
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            DbModels dbModel = new DbModels();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "ref_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var necessidades = from p in dbModel.tb_necessidades select p;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "ref_desc":
                    necessidades = necessidades.OrderByDescending(p => p.codigo_artigo);
                    break;
                case "Date":
                    necessidades = necessidades.OrderBy(p => p.data_criado);
                    break;
                case "date_desc":
                    necessidades = necessidades.OrderByDescending(p => p.data_criado);
                    break;
                default:
                    necessidades = necessidades.OrderBy(p => p.codigo_artigo);
                    break;
            
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);


            return View(dbModel.tb_necessidades.ToList().ToPagedList(pageNumber, pageSize));


        }

        // GET: Necessidades/Details/5System.InvalidOperationException: 'The entity type tb_necessidades is not part of the model for the current context.'
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.tb_necessidades.Where(x => x.codigo == id).FirstOrDefault());
            }
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
        public ActionResult Create(tb_necessidades necessidadeModel)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    if (dbModel.tb_necessidades.Any(p => p.codigo_artigo == necessidadeModel.codigo_artigo))
                    {
                        ViewBag.ErrorMessage = "A referência já existe!";
                        return View();
                    }
                    necessidadeModel.data_criado = DateTime.Now;
                    necessidadeModel.data_alterado = DateTime.Now;
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
                necessidadeModel = dbModel.tb_necessidades.Where(x => x.codigo == id).FirstOrDefault();
            }
            return View(necessidadeModel);
        }

        // POST: Necessidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(tb_necessidades necessidadeModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                necessidadeModel.data_alterado = DateTime.Now;
                dbModel.Entry(necessidadeModel).State = EntityState.Modified;
                dbModel.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Necessidades/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.tb_necessidades.Where(x => x.codigo == id).FirstOrDefault());
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
                    tb_necessidades necessidade = dbModel.tb_necessidades.Where(x => x.codigo == id).FirstOrDefault();
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
