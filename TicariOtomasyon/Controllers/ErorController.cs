﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.Controllers
{
    public class ErorController : Controller
    {
        // GET: Eror
        public ActionResult PageEror()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Page400()
        {
            Response.StatusCode = 400;
            Response.TrySkipIisCustomErrors = true;
            return View("PageEror");
        }
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("PageEror");
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("PageEror");
        }
    }
}