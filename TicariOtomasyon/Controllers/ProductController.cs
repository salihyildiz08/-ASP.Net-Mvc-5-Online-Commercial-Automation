using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PagedList;
using PagedList.Mvc;
using TicariOtomasyon.Models.Class;
namespace TicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index( string pa)
        {
          
            var values = from x in c.Products select x;
            if(!string.IsNullOrEmpty(pa))
            {
                values = values.Where(y => y.ProductNAme.Contains(pa));
            }
            return View(values.ToList()) ;
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> value1 = (from x in c.Categorys.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryNAme,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vlu1 = value1;                          
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product pr)
        {
            c.Products.Add(pr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var deger = c.Products.Find(id);
            deger.Situation = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductBring(int id)
        {
            List<SelectListItem> value1 = (from x in c.Categorys.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryNAme,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vlu1 = value1;
            var productvalue = c.Products.Find(id);
            return View("ProductBring", productvalue);
        }
        public ActionResult ProductUpdate(Product p)
        {
            var prd = c.Products.Find(p.ProductID);
            prd.Purchaseprice = p.Purchaseprice;
            prd.Situation = p.Situation;
            prd.Categoryiid = p.Categoryiid;
            prd.Brand= p.Brand;
            prd.Saleprice = p.Saleprice;
            prd.Stock = p.Stock;
            prd.ProductNAme = p.ProductNAme;
            prd.ProductImage = p.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var _value = c.Products.ToList();
           
          
            return View(_value);
        }
        [HttpGet]
        public ActionResult Makeasale(int idd)
        {
            List<SelectListItem> _value = (from x in c.Employees.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                Value = x.EmployeeId.ToString()
                                            }
                                         ).ToList();
            ViewBag.vlu1 = _value;
            var productvalue = c.Products.Find(idd); 
            ViewBag.vlu2 = productvalue; 
            ViewBag.vlu3 = productvalue.Saleprice;
            return View();
        }
        [HttpPost]
        public ActionResult Makeasale(SalesAction a) 
        {
            a.Date_ = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesActions.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index", "Sales");
        }
    }
}