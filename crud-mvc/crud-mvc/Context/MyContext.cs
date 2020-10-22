using crud_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace crud_mvc.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("crud-mvc") { }
        public DbSet<Department> Departments { get; set; }
    }
}