using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoUnipWeb.Areas.Medico.Controllers
{
    public class IndexController : Controller
    {
        // GET: Medico/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Medico/Index/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medico/Index/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medico/Index/Create
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

        // GET: Medico/Index/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medico/Index/Edit/5
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

        // GET: Medico/Index/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medico/Index/Delete/5
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
