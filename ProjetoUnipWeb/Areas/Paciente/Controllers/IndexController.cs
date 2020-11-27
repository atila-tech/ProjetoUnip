using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoUnipWeb.Areas.Paciente.Controllers
{
    public class IndexController : Controller
    {
        // GET: Paciente/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Paciente/Index/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Paciente/Index/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Index/Create
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

        // GET: Paciente/Index/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Paciente/Index/Edit/5
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

        // GET: Paciente/Index/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Paciente/Index/Delete/5
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
