using Current_new_info.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Current_new_info.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            using (NewsEntities nw = new NewsEntities())
            {
                return View(nw.News_class.ToList());
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(News_class nc)
        {
            try
            {
                using (NewsEntities nw = new NewsEntities())
                {
                    nw.News_class.Add(nc);
                    nw.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using (NewsEntities nw = new NewsEntities())
            {
                return View(nw.News_class.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (NewsEntities nw = new NewsEntities())
            {
                return View(nw.News_class.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, News_class nwc)
        {
            try
            {
                using (NewsEntities nw = new NewsEntities())
                {
                    nw.Entry(nwc).State = EntityState.Modified;
                    nw.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult delete(int id)
        {
            using (NewsEntities nw = new NewsEntities())
            {
                return View(nw.News_class.Where(x => x.ID == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult delete(int id, FormCollection collection)
        {
            try
            {
                using (NewsEntities nw = new NewsEntities())
                {
                   News_class nvc =nw.News_class.Where(x => x.ID == id).FirstOrDefault();
                    nw.News_class.Remove(nvc);
                    nw.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}