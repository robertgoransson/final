﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalEvent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
           

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            

            return View();
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}