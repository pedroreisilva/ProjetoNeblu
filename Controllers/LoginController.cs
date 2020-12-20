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
            if (Session["id_utilizador"] != null)
            {
                Response.Redirect("Necessidades");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Authorise(tb_utilizadores user)
        {
            using (DbModels db = new DbModels())
            {
                tb_utilizadores lastLogin = db.tb_utilizadores.FirstOrDefault(x => x.utilizador == user.utilizador && x.password == user.password);
                tb_utilizadores lastUser = db.tb_utilizadores.SingleOrDefault(x => x.utilizador == user.utilizador);
                tb_utilizadores wrongPassword = db.tb_utilizadores.SingleOrDefault(x => x.utilizador == user.utilizador && x.password != user.password);

                if (lastLogin == null)
                {
                    if (wrongPassword != null) {
                        lastUser.numero_tentativas++;
                        db.SaveChanges();
                        ViewBag.Error = "Password inválido!";

                        if (lastUser.numero_tentativas >= 3)
                        {
                            lastUser.bloqueado = "true";
                            db.SaveChanges();
                            ViewBag.Error = "Excedeu o limite de tentativas, contacte o departamento de software!";
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Utilizador ou password inválido!";
                    }

                    return View("Index", user);
                }
                else if (lastUser.bloqueado == "true")
                {
                    ViewBag.Error = "Excedeu o limite de tentativas, contacte o departamento de software!";
                    return View("Index", user);
                }
                else
                {
                    lastUser.data_ultimo_acesso = DateTime.Now;
                    lastUser.data_ultimo_acesso = DateTime.Now;
                    lastUser.numero_tentativas = 0;
                    db.Entry(lastUser).State = System.Data.Entity.EntityState.Modified;
                    Session["id_utilizador"] = lastUser.id_utilizador;
                    db.SaveChanges();

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