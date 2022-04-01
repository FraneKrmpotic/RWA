﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Main.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string err)
        {
            ViewBag.err = err;
            return View();
        }
    }
}