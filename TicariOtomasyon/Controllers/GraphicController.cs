using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;
namespace TicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var graphicdaw = new Chart(600, 600);
            graphicdaw.AddTitle("Category - Product Stock Piece").AddLegend("Stock").AddSeries("Value", xValue: new[]
            { "forniture", "office forniture", "compter" }, yValues: new[] { 86, 66, 98 }
                ).Write();
            return File(graphicdaw.ToWebImage().GetBytes(), "image/jpeg");
        }
        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var results = c.Products.ToList();
            results.ToList().ForEach(x => xvalue.Add(x.ProductNAme));
            results.ToList().ForEach(y => yvalue.Add(y.Stock));
            var graphic = new Chart(500, 500).AddTitle("Stocks").AddSeries(chartType: "Pie",
                name: "Stock", xValue: xvalue, yValues: yvalue);

            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductReslt()
        {

            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<Class2> ProductList()
        {
            List<Class2> list = new List<Class2>();
            list.Add(new Class2()
            {
                ProductName = "computer",
                Stock = 120
            });
            list.Add(new Class2()
            {
                ProductName = "household appliances",
                Stock = 70
            });
            list.Add(new Class2()
            {
                ProductName = "furniture",
                Stock = 150
            });
            list.Add(new Class2()
            {
                ProductName = "small appliances",
                Stock = 180
            });
            list.Add(new Class2()
            {
                ProductName = "mobile device",
                Stock = 200
            });
            return list;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductReslt2() {
            return Json(ProductList2(), JsonRequestBehavior.AllowGet);
        }
        public List<Class3> ProductList2()
        {
            List<Class3> list = new List<Class3>();
            using (var c = new Context())
            {
                list = c.Products.Select(x => new Class3
                {
                    prn = x.ProductNAme,
                    stk = x.Stock
                }).ToList();
            }
            return list;
        }
       public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }

    }
}