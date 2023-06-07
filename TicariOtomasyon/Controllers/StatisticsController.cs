using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;

namespace TicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var _value = c.Currents.Count().ToString();
            ViewBag.v1 = _value;
            var _value2 = c.Products.Count().ToString();
            ViewBag.v2 = _value2;
            var _value3 = c.Employees.Count().ToString();
            ViewBag.v3 = _value3;
            var _value4 = c.Categorys.Count().ToString();
            ViewBag.v4 = _value4;
            var _value5 = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.v5 = _value5;
            var _value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.v6 = _value6;
            var _value7 = c.Products.Count(x=>x.Stock <=20).ToString();
            ViewBag.v7 = _value7;
            var _value8 = (from x in c.Products orderby x.Saleprice descending select x.ProductNAme).FirstOrDefault(); 
            ViewBag.v8 = _value8;
            var _value9 = (from x in c.Products orderby x.Saleprice ascending select x.ProductNAme).FirstOrDefault();
            ViewBag.v9 = _value9;
            var _value10 = c.Products.Count(x => x.ProductNAme == "Refrigerator").ToString();
            ViewBag.v10 = _value10;
            var _value11 = c.Products.Count(x=>x.ProductNAme== "Bakery").ToString();
            ViewBag.v11= _value11;
            var _value12 = c.Products.GroupBy(x => x.Brand)
                .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.v12 = _value12;
            var _value13 = c.Products.Where(p=>p.ProductID==(c.SalesActions.GroupBy(x => x.Productiid).
            OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.ProductNAme).
            FirstOrDefault();
            ViewBag.v13 = _value13;
            var _value14 = c.SalesActions.Sum(x => x.TotalAmount).ToString();
            ViewBag.v14 = _value14;
            DateTime t = DateTime.Today;
            var _value15 = c.SalesActions.Count(x => x.Date_==t).ToString();
            ViewBag.v15 = _value15;
            var _value16 = c.SalesActions.Where(x => x.Date_ == t).Sum(y=>(decimal?)y.TotalAmount).ToString();
            ViewBag.v16 = _value16;
            return View(); 
        }
        public ActionResult SimpleTable()
        {
            var query_ = from x in c.Currents
                         group x by x.City into g
                         select new ClassGroup
                         {
                             City = g.Key,
                             Count_ = g.Count()
                         };
                        
            return View(query_.ToList());
        }
        public PartialViewResult Partial1()
        {
            var query_ = from x in c.Employees
                         group x by x.Departmentiid into g
                         select new Class2Group
                         {
                             Departmen = g.Key,
                             Qunlity = g.Count()
                         };
            return PartialView(query_.ToList());
        }
        public PartialViewResult Partial2()
        {
            var query_ = c.Currents.ToList();

            return PartialView(query_);
        }
        public PartialViewResult Partial3()
        {
            var query_ = c.Products.ToList();

            return PartialView(query_);
        }
        public PartialViewResult Partial4()
        {
            var query_ = from x in c.Products
                         group x by x.Brand into g
                         select new Class3Group
                         {
                              Brand= g.Key,
                              Count_ = g.Count()
                         };

              return PartialView(query_.ToList());
        }
    }
}