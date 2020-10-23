using crud_mvc.Context;
using crud_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace crud_mvc.Controllers
{
    
    public class DivisionsController : Controller
    {
        public MyContext myContext = new MyContext();
        // GET: Divisions
        public ActionResult Index()
        {
            var divisions = myContext.Divisions.Include(p => p.DepartmentIDNavigation);
            
            return View(divisions.ToList());
        }
        

        public ActionResult Delete(int? id)
        {
            var division = myContext.Divisions.Include(p => p.DepartmentIDNavigation).FirstOrDefault(m => m.Id == id);
            return View(division);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconf(int id)
        {

            try
            {
                var division = myContext.Divisions.Include(p => p.DepartmentIDNavigation).FirstOrDefault(m => m.Id == id);
                myContext.Divisions.Remove(division);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Delete");
            }

        }
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(myContext.Departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Division division)
        {
            if (ModelState.IsValid)
            {
                myContext.Divisions.Add(division);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(myContext.Departments, "Id", "Name", division.DepartmentID);
            return View(division);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = myContext.Divisions.Find(id);
            ViewBag.DepartmentID = new SelectList(myContext.Departments, "id", "Name", division.DepartmentID);
            return View(division);
        }
        [HttpPost]
        public ActionResult Edit(int id, Division division)
        {
            if (ModelState.IsValid)
            {
                myContext.Entry(division).State = EntityState.Modified;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(division);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var division = myContext.Divisions.Include(p => p.DepartmentIDNavigation).FirstOrDefault(m => m.Id == id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }
    }
}