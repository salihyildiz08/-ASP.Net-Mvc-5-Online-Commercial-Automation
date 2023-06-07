using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;
namespace TicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var _value = c.Currents.ToList();
            return View(_value);
        }
        [HttpGet]
        public ActionResult CurrentInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentInsert(Current p)
        {
            c.Currents.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentDelete(int id)
        {
            var ctg = c.Currents.Find(id);
            c.Currents.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CurrentUpdate(int id)
        {
            var current = c.Currents.Find(id);
            return View("CurrentUpdate", current);
        }
        public ActionResult CurrentUpdatee(Current d)
        {
            var cur = c.Currents.Find(d.CurrentId);
            cur.CurrentName = d.CurrentName;
            cur.CurrentSurname = d.CurrentSurname;
            cur.City = d.City;
            cur.CurrentMail = d.CurrentMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentDetail(int id)
        {
            var _value = c.SalesActions.Where(x =>x.Currentiid == id).ToList();
            var cur = c.Currents.Where(x => x.CurrentId == id).
                Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.curr = cur;
            return View(_value);
        }
        
    }
}