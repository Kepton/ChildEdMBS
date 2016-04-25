using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChildEdcuation.Models;

namespace ChildEdcuation.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Student/
        public ActionResult Index()
        {
            return View(db.StudentModels.ToList());
        }

        // GET: /Student/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels studentmodels = db.StudentModels.Find(id);
            if (studentmodels == null)
            {
                return HttpNotFound();
            }
            return View(studentmodels);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Age,Address")] StudentModels studentmodels)
        {
            if (ModelState.IsValid)
            {
                db.StudentModels.Add(studentmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentmodels);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels studentmodels = db.StudentModels.Find(id);
            if (studentmodels == null)
            {
                return HttpNotFound();
            }
            return View(studentmodels);
        }

        // POST: /Student/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Age,Address")] StudentModels studentmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentmodels);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels studentmodels = db.StudentModels.Find(id);
            if (studentmodels == null)
            {
                return HttpNotFound();
            }
            return View(studentmodels);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentModels studentmodels = db.StudentModels.Find(id);
            db.StudentModels.Remove(studentmodels);
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
    }
}
