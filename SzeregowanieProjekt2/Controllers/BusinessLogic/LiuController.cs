using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SzeregowanieProjekt2.Models.BasicModels;

namespace SzeregowanieProjekt2.Controllers.BusinessLogic
{
    public class LiuController : Controller
    {
        private TaskDBContext db = new TaskDBContext();

        // GET: /Liu/
        public ActionResult Index()
        {
            return View(db.Tasks.ToList());
        }

        // GET: /Liu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: /Liu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Liu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,label,release,deadline,processingTime")] Task task)
        {
            if (ModelState.IsValid)
            {
                task.color = new Color();
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // GET: /Liu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: /Liu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,label,release,deadline,processingTime")] Task task)
        {
            if (ModelState.IsValid)
            {
                task.color = new Color();
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: /Liu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: /Liu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Sort()
        {
            List<Task> taskList = db.Tasks.ToList();
            LiuSort liuSort = new LiuSort();

            List<Task> sortedTasks = liuSort.SortedTasks(taskList);
            int Lmax = liuSort.returnLmax(db.Tasks.ToList());
            ViewBag.Lmax = Lmax;
            return View(sortedTasks);
        }
    }
}
