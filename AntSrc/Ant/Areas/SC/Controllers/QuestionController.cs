using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ant.Models.Questions;
using Ant.DB;
using Ant.Models;

namespace Ant.Areas.SC.Controllers
{
    public class QuestionController : Controller
    {
        //
        // GET: /SC/Question/

        public ActionResult Index()
        {
            using (var s = new MongoSession())
            {
                return View(s.Query<Question>());
            }
        }

        public ActionResult Index2(Paging m)
        {
            using (var s = new MongoSession())
            {
                var q = s.Query<Question>();
                if(m != null)
                {
                    q = m.Page(q);
                }
                return View(q);
            }
        }
        //
        // GET: /SC/Question/Details/5

        public ActionResult Details(int id)
        {
            using (var s = new MongoSession())
            {
                return View(s.Query<Question>().Single(q => q.Number == id));                
            }
        }

        //
        // GET: /SC/Question/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SC/Question/Create

        [HttpPost]
        public ActionResult Create(Question q)
        {
            try
            {
                // TODO: Add insert logic here
                using (var s = new MongoSession())
                {
                    q.Number = new IDProvider().GetNewID("Question");
                    q.Info = new EntityInfo()
                    {
                        CrTime = DateTime.Now,
                        CrUser = "admin",
                        LastModified = DateTime.Now
                    };
                    s.Add(q);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /SC/Question/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SC/Question/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SC/Question/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SC/Question/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
