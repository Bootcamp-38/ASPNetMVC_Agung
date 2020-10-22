using crud_mvc.Context;
using crud_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace crud_mvc.Controllers
{
   
    public class DepartmentsController : Controller
    {
        public MyContext myContext = new MyContext();
        // GET: Departments
        public ActionResult Index()
        {
            return View(myContext.Departments.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(myContext.Departments.Find(id));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            myContext.Departments.Add(department);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            
            return View(myContext.Departments.Find(id));
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            
            try
            {
                Department department = myContext.Departments.Find(id);
                myContext.Departments.Remove(department);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Delete");
            }

        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = myContext.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                myContext.Entry(department).State = EntityState.Modified;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

    }
}