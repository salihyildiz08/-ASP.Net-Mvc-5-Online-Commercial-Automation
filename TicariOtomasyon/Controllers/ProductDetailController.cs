using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;
namespace TicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cd = new Class1();
            //var _value = c.Products.ToList();
            cd._value1 = c.Products.Where(x => x.ProductID == 1).ToList();
            cd._value2 = c.Details.Where(y => y.DetailId == 1).ToList();
            return View(cd);
        }
    }
}