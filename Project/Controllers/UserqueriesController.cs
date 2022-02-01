using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class UserqueriesController : Controller
    {
        private RegisterUserEntities1 db = new RegisterUserEntities1();

        // GET: Userqueries
        public ActionResult Index()
        {
            return View(db.Userqueries.ToList());
        }

        // GET: Userqueries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userquery userquery = db.Userqueries.Find(id);
            if (userquery == null)
            {
                return HttpNotFound();
            }
            return View(userquery);
        }

        // GET: Userqueries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Userqueries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SNo,UserReq")] Userquery userquery)
        {
            if (ModelState.IsValid)
            {
                db.Userqueries.Add(userquery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userquery);
        }

        // GET: Userqueries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userquery userquery = db.Userqueries.Find(id);
            if (userquery == null)
            {
                return HttpNotFound();
            }
            return View(userquery);
        }

        // POST: Userqueries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SNo,UserReq")] Userquery userquery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userquery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userquery);
        }

        // GET: Userqueries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userquery userquery = db.Userqueries.Find(id);
            if (userquery == null)
            {
                return HttpNotFound();
            }
            return View(userquery);
        }

        // POST: Userqueries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Userquery userquery = db.Userqueries.Find(id);
            db.Userqueries.Remove(userquery);
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
