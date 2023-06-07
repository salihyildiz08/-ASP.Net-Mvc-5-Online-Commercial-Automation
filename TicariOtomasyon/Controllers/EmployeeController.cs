using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Class;

namespace TicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context c = new Context();
        public ActionResult Index()
        {
            var _value = c.Employees.ToList();
            return View(_value);
        }
        [HttpGet]
        public ActionResult EmployeeInsert()
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vlu1 = value1;
           
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeInsert(Employee e)
        {   if(Request.Files.Count>0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string _extension = Path.GetExtension(Request.Files[0].FileName);
                string _path="~/Image/"+filename+_extension;
                Request.Files[0].SaveAs(Server.MapPath(_path));
                e.EmployeeImage = "/Image/" + filename + _extension;
            }
            c.Employees.Add(e);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeBring(int id)
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vlu1 = value1;

            var em = c.Employees.Find(id);
            return View("EmployeeBring", em);
        }
        public ActionResult EmployeeUpdate(Employee e)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string _extension = Path.GetExtension(Request.Files[0].FileName);
                string _path = "~/Image/" + filename + _extension;
                Request.Files[0].SaveAs(Server.MapPath(_path));
                e.EmployeeImage = "/Image/" + filename + _extension;
            }
            var em = c.Employees.Find(e.EmployeeId);
            em.EmployeeName = e.EmployeeName;
            em.EmployeeSurname = e.EmployeeSurname;
            em.EmployeeImage = e.EmployeeImage;
            em.Departmentiid = e.Departmentiid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeList()
        {
            var query_ = c.Employees.ToList();
            return View(query_);
        }
    }
}