
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;

namespace TicariOtomasyon.Controllers
{
    public class BillsController : Controller
    {
        // GET: Bills
        Context c = new Context();
        public ActionResult Index()
        {
            var _value = c.Billss.ToList();
            return View(_value);
        }
        [HttpGet]
        public ActionResult BillsInsert()
        {

            return View();
        }
        [HttpPost]
        public ActionResult BillsInsert(Bills b)
        {
            c.Billss.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BillsBring(int id)
        {
            var bill = c.Billss.Find(id);
            return View("BillsBring", bill);
        }
        public ActionResult BillsUpdate(Bills b)
        {
            var bill = c.Billss.Find(b.BillsId);
            bill.BillsIdSerialNumber = b.BillsIdSerialNumber;
            bill.BillsIdDeskNumber = b.BillsIdDeskNumber;
            bill.Hour = b.Hour;
            bill.Date_ = b.Date_;
            bill.DeliveryArea = b.DeliveryArea;
            bill.Submitter = b.Submitter;
            bill.TaxAdministration = b.TaxAdministration;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult BillsDetail(int id)
        {
            var _value = c.InvoiceItems.Where(x => x.Billid == id).ToList();

            return View(_value);
        }
        [HttpGet]
        public ActionResult NewItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewItem(InvoiceItem i)
        {
            c.InvoiceItems.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dynamic()
        {
            Class5 cs = new Class5();
            cs._value = c.Billss.ToList();
            cs._value2 = c.InvoiceItems.ToList();
            return View(cs);
        }
        public ActionResult BillsSave(string BillsIdSerialNumber, string BillsIdDeskNumber,DateTime Date_,string TaxAdministration,string Hour,string DeliveryArea,string Submitter,string TotalAmount, InvoiceItem[] items) 
        {
            Bills b=new Bills();   
            b.BillsIdSerialNumber= BillsIdSerialNumber;
            b.BillsIdDeskNumber= BillsIdDeskNumber;
            b.Date_ = Date_;    
            b.TaxAdministration=TaxAdministration;
            b.Hour= Hour;   
            b.DeliveryArea= DeliveryArea;
            b.Submitter= Submitter;
            b.TotalAmount = decimal.Parse(TotalAmount);
            c.Billss.Add(b);
            foreach (var item in items)
            {
                InvoiceItem ii=new InvoiceItem();
                ii.Explanation= item.Explanation;
                ii.UnitPrice= item.UnitPrice;
                ii.Billid= item.InvoiceItemId;
                ii.Quantity= item.Quantity;
                ii.Amount= item.Amount;
                c.InvoiceItems.Add(ii);
            }
            c.SaveChanges();
            
            return Json("Processing Succes",JsonRequestBehavior.AllowGet);

        }
    }
}