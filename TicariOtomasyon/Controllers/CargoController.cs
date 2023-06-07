using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;

namespace TicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var cargo = from x in c.cargoDatails select x;
            if (!string.IsNullOrEmpty(p))
            {
                cargo = cargo.Where(y => y.trackingcode.Contains(p));
            }
            return View(cargo.ToList());
            
        }
        [HttpGet]
        public ActionResult NewCargo()
        {
            Random rnd = new Random();
            string[] charts = { "A", "B", "C", "D" };
            int c1, c2, c3;
            c1= rnd.Next(0,4);
            c2= rnd.Next(0,4);
            c3= rnd.Next(0,4);
            int n1,n2,n3;
            n1= rnd.Next(100,1000);
            n2= rnd.Next(10,99);
            n3= rnd.Next(10,99);
            string cod=n1.ToString() + charts[c1] + n2.ToString() + charts[c2]+ n3.ToString() + charts[c3];
            ViewBag.trakingcoade= cod;
            return View();
        }
        [HttpPost]
        public ActionResult NewCargo(CargoDatail k)
        {
            c.cargoDatails.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoTrakingl(string id)
        {
            var _value = c.cargoTrackings.Where(x => x.CargoTrakingCode == id).ToList();
          

            return View(_value);
        }
    }
}