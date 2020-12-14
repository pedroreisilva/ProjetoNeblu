﻿using System;
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
                var userDetail = db.tb_utilizadores.Where(x => x.utilizador == user.utilizador && x.password == user.password).FirstOrDefault();
                if(userDetail == null)
                {
                    ViewBag.Error = "Utilizador ou password inválido!";
                    return View("Index", user);
                }
                else
                {
                    tb_utilizadores lastLogin = db.tb_utilizadores.SingleOrDefault(x => x.utilizador == user.utilizador);
                    lastLogin.data_ultimo_acesso = DateTime.Now;
                    user.data_ultimo_acesso = DateTime.Now; 
                    db.Entry(lastLogin).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    Session["id_utilizador"] = user.id_utilizador;
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