using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace ProjetoUnipWeb.Areas.Funcionario.Controllers
{
    public class IndexController : Controller
    {
        // GET: Funcionario/Index
        public ActionResult Index()
        {
            //return View();]
            Cache cache = new Cache();
            if (cache["DadosUsuario"] != null)
            //if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                //return RedirectToAction("Login");
                return RedirectToAction("Index", "Login", new { Area = "" });
                //return RedirectToAction("Index", "Login");
            }
        }

        // GET: Funcionario/Index/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Funcionario/Index/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Index/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Index/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Funcionario/Index/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionario/Index/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Funcionario/Index/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
