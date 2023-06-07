using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Services.Description;

namespace TicariOtomasyon.Models.Class
{
    public class Context: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bills> Billss { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expenses> Expensess { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesAction> SalesActions { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ThingsToDo> ThingsToDos { get; set; }
        public DbSet<CargoDatail> cargoDatails { get; set; }
        public DbSet<CargoTracking> cargoTrackings { get; set; }
        public DbSet<massages> massagess { get; set; }
    }
}