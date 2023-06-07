using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;

namespace TicariOtomasyon.Controllers
{
    [Authorize]

    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
       
            
        public ActionResult Index()
        {
            var _values = c.Departments.Where(x=>x.Situation).ToList();
            return View(_values);
        }
        [Authorize(Roles="A")]
        [HttpGet]
        
        public ActionResult DepartmentInsert()
        {
            return View();
        }
        [HttpPost]
        

        public ActionResult DepartmentInsert(Department d)
        {
            var da=c.Departments.Add(d);
            da.Situation = true;
           
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmentDelete(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Situation = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentBring(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("DepartmentBring", dpt);
        }
        public ActionResult DepartmentUpdate(Department d)
        {
            var dpt = c.Departments.Find(d.DepartmentId);
            dpt.DepartmentName = d.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DepartmentDetail(int id)
        {
            var _value = c.Employees.Where(x => x.Departmentiid == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentId == id)
                .Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;

            return View(_value);
        }
        public ActionResult DepartmentEmployeeSales(int id)
        {
            var _value = c.SalesActions.Where(x => x.Employeeiid == id).ToList();
            var emp = c.Employees.Where(x => x.Departmentiid == id).
                Select(y => y.EmployeeName +" " +y.EmployeeSurname).FirstOrDefault();
            ViewBag.dp = emp;
            return View(_value);
        }
    }
}