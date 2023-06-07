using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;
namespace TicariOtomasyon.Controllers
{
    public class ThingsToDoController : Controller
    {
        // GET: ThingsToDo
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Currents.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = c.Products.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = c.Categorys.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = (from x in c.Currents select x.City).Distinct().Count().ToString();
            ViewBag.v4 = value4;
            var todo = c.ThingsToDos.ToList();
            return View(todo);
        }
    }
}