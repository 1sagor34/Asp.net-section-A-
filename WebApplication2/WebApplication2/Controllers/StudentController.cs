using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<tushar> tusharlist = new List<tushar>();
           // List<studentEntities> studentlist = new List<studentEntities>();
            using(studentEntities studentEntitie = new studentEntities())
            {
                tusharlist = studentEntitie.tushars.ToList<tushar>();
            }
            return View(tusharlist);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            tushar tusharModel = new tushar();
            using(studentEntities studentEntitie = new studentEntities())
            {
                tusharModel = studentEntitie.tushars.Where(x => x.id == id).FirstOrDefault();
            }
            return View(tusharModel);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new tushar());
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(tushar tusharModel)
        {

            using(studentEntities  studentEntitie = new studentEntities())
            {
                studentEntitie.tushars.Add(tusharModel);
                studentEntitie.SaveChanges();

            }
            return RedirectToAction("Index");
            /*
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            */
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            tushar tusharModel = new tushar();
            using (studentEntities studentEntitie = new studentEntities())
            {
                tusharModel = studentEntitie.tushars.Where(x => x.id == id).FirstOrDefault();
            }
            return View(tusharModel);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(tushar tusharModel)
        {
            using (studentEntities studentEntitie = new studentEntities())
            {
                studentEntitie.Entry(tusharModel).State = System.Data.EntityState.Modified;
                studentEntitie.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            tushar tusharModel = new tushar();
            using (studentEntities studentEntitie = new studentEntities())
            {
                tusharModel = studentEntitie.tushars.Where(x => x.id == id).FirstOrDefault();
            }
            return View(tusharModel);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (studentEntities studentEntitie = new studentEntities())
            {
                tushar tusharModel = studentEntitie.tushars.Where(x => x.id == id).FirstOrDefault();
                studentEntitie.tushars.Remove(tusharModel);
                studentEntitie.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
