using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;
using PagedList;
using PagedList.Mvc;
namespace TicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index(int page=1)
        {
            var _values = c.Categorys.ToList().ToPagedList(page,4);
            return View(_values);
        }
        [HttpGet]
        public ActionResult CategoryInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryInsert(Category ct)
        {
            c.Categorys.Add(ct);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var ctg = c.Categorys.Find(id);
            c.Categorys.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int id)
        {
            var category = c.Categorys.Find(id);
            return View("CategoryBring", category);
        }
        public ActionResult CategoryUpdate(Category ct)
        {
            var ctgr = c.Categorys.Find(ct.CategoryID);
            ctgr.CategoryNAme = ct.CategoryNAme;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Attempt()
        {
            Class4 cs = new Class4();
            cs.Categorys=new SelectList(c.Categorys,"CaegoryID","CategoryName");
            cs.Products = new SelectList(c.Products, "ProductId", "ProductNAme");
            return View(cs);
        }
        public JsonResult ProductBring(int p)
        {
            var productlist = (from x in c.Products
                               join y in c.Categorys
                               on x.Category.CategoryID equals y.CategoryID
                               where x.Category.CategoryID == p
                               select new
                               {
                                   Text = x.ProductImage,
                                   Value = x.ProductID.ToString(),
                               }).ToList();
            return Json(productlist,JsonRequestBehavior.AllowGet);
        }
    }
}