using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;
namespace TicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var _value = c.SalesActions.ToList();
            return View(_value);
        }
        [HttpGet]
        public ActionResult NewSell()
        {
            List<SelectListItem> _value = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductNAme,
                                               Value = x.ProductID.ToString()
                                           }
                                         ).ToList();
            List<SelectListItem> _value2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName+" "+x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }
                                         ).ToList();
            List<SelectListItem> _value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName+" "+x.EmployeeSurname,
                                               Value = x.EmployeeId.ToString()
                                           }
                                         ).ToList();
            ViewBag.vlu1 = _value;
            ViewBag.vlu2 = _value2;
            ViewBag.vlu3 = _value3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSell(SalesAction a)
        {
            a.Date_ = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesActions.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index"); 

        }
        public ActionResult NewBring(int id)
        {
            List<SelectListItem> _value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductNAme,
                                               Value = x.ProductID.ToString()
                                           }
                                         ).ToList();
            List<SelectListItem> _value2 = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurname,
                                                Value = x.CurrentId.ToString()
                                            }
                                         ).ToList();
            List<SelectListItem> _value3 = (from x in c.Employees.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                Value = x.EmployeeId.ToString()
                                            }
                                         ).ToList();
            ViewBag.vlu1 = _value1;
            ViewBag.vlu2 = _value2;
            ViewBag.vlu3 = _value3;
            var _value = c.SalesActions.Find(id);
            return View("NewBring", _value);
        }
        public ActionResult SalesUpdate(SalesAction p)
        {
            var prd = c.SalesActions.Find(p.SalesActionId);
            prd.Currentiid = p.Currentiid;
            prd.Piece = p.Piece;
            prd.Price = p.Price;
            prd.Employeeiid = p.Employeeiid;
            prd.Date_ = p.Date_;
            prd.TotalAmount = p.TotalAmount;
            prd.Productiid = p.Productiid;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int id)
        {
            var _value = c.SalesActions.Where(x => x.SalesActionId == id).ToList();
            return View(_value);
        }
    }
}