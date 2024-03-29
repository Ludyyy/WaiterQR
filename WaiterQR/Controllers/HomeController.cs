﻿// This class is the controller for the Startpage. It handles different outgoing pages from the startpage.Such as the impressum and the about page.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WaiterQR.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
       
        public ActionResult ItemPresentation()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}