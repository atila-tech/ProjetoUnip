﻿using ProjetoUnipWeb.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoUnipWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //return View();
            if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                //return RedirectToAction("Login");
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}