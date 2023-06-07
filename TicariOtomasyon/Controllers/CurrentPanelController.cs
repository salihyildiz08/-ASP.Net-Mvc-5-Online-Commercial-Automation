using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using TicariOtomasyon.Models.Class;

namespace TicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        Context c = new Context();
        // GET: CurrentPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var values = c.massagess.Where(x => x.buyer == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentId).FirstOrDefault();
            ViewBag.m1 = mailid;
            var amountsales = c.SalesActions.Where(x => x.Currentiid == mailid).Count();
            ViewBag.m2 = amountsales;
            var totalpirece = c.SalesActions.Where(x => x.Currentiid == mailid).Sum(y => y.TotalAmount);
            ViewBag.m3 = totalpirece;
            var totalproduct = c.SalesActions.Where(x => x.Currentiid == mailid).Sum(y => y.Piece);
            ViewBag.m4 = totalproduct;
            var namesurname = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.m5 = namesurname;
            return View(values);
        }
        [Authorize]
        public ActionResult Orders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = c.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var values = c.SalesActions.Where(x => x.Currentiid == id).ToList();

            return View(values);
        }
        [Authorize]
        public ActionResult InComingMsessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = c.massagess.Where(x => x.buyer == mail).OrderByDescending(x => x.MessageID).ToList();
            var numberofarrivals = c.massagess.Count(x => x.buyer == mail).ToString();
            var numberofoutgoing = c.massagess.Count(x => x.sender == mail).ToString();
            ViewBag.m2 = numberofoutgoing;
            ViewBag.m1 = numberofarrivals;
            return View(messages);
        }
        [Authorize]
        public ActionResult OutComingMsessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = c.massagess.Where(x => x.sender == mail).OrderByDescending(x => x.MessageID).ToList();
            var numberofoutgoing = c.massagess.Count(x => x.sender == mail).ToString();
            var numberofarrivals = c.massagess.Count(x => x.buyer == mail).ToString();
            ViewBag.m1 = numberofarrivals;
            ViewBag.m2 = numberofoutgoing;
            return View(messages);
        }
        [Authorize]
        public ActionResult MessageDetail(int id)
        {
            var _value = c.massagess.Where(x => x.MessageID == id).ToList();
            var mail = (string)Session["CurrentMail"];
            var numberofoutgoing = c.massagess.Count(x => x.sender == mail).ToString();
            var numberofarrivals = c.massagess.Count(x => x.buyer == mail).ToString();
            ViewBag.m1 = numberofarrivals;
            ViewBag.m2 = numberofoutgoing;
            return View(_value);
        }
        [Authorize]
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var numberofoutgoing = c.massagess.Count(x => x.sender == mail).ToString();
            var numberofarrivals = c.massagess.Count(x => x.buyer == mail).ToString();
            ViewBag.m1 = numberofarrivals;
            ViewBag.m2 = numberofoutgoing;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult NewMessage(massages m)
        {
            var mail = (string)Session["CurrentMail"];
            m._Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.sender = mail;
            c.massagess.Add(m);
            c.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult CartoTraking(string p)
        {
            var cargo = from x in c.cargoDatails select x;

            cargo = cargo.Where(y => y.trackingcode.Contains(p));

            return View(cargo.ToList());
        }
        [Authorize]
        public ActionResult CurrentCargoTracking(string id)
        {
            var _value = c.cargoTrackings.Where(x => x.CargoTrakingCode == id).ToList();
            return View(_value);
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult MyProfile(string message)
        {
            return View();
        }
        public PartialViewResult partial1()
        {
            var mail = (string)Session["CurrentMail"];
            var id = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentId).FirstOrDefault();
            var current = c.Currents.Find(id);
            return PartialView("partial1", current);
        }
        public PartialViewResult partial2()
        {
            var _value = c.massagess.Where(x => x.sender == "admin").ToList();
            return PartialView(_value);
        }
        public ActionResult CurrentUpdate(Current cr)
        {   var current=c.Currents.Find(cr.CurrentId);
            current.CurrentName= cr.CurrentName;
            current.CurrentSurname= cr.CurrentSurname;
            current.CurrentPassword= cr.CurrentPassword;
            c.SaveChanges();
            return View("Index");
        }
    }
}