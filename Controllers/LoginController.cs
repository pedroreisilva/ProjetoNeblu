using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestaoArtigos.Models;

namespace GestaoArtigos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(tb_utilizadores user)
        {
            using (DbModels db = new DbModels())
            {
                var userDetail = db.tb_utilizadores.Where(x => x.utilizador == user.utilizador && x.password == user.password).FirstOrDefault();
                if(userDetail == null)
                {
                    ViewBag.Error = "Utilizador ou password inválido!";
                    return View("Index", user);
                }
                else
                {
                    tb_utilizadores userProfile = db.tb_utilizadores.SingleOrDefault(x => x.utilizador == user.utilizador);
                    userProfile.data_ultimo_acesso = DateTime.Now;
                    db.Entry(userProfile).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    user.data_ultimo_acesso = DateTime.Now; 
                    Session["codigo"] = user.codigo;
                    Session["utilizador"] = user.utilizador;
                    return RedirectToAction("Index", "Necessidades");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}