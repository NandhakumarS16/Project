using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using Syn.Bot.Channels.Widget;
using Syn.Bot.Oscova.Messages;
using System.Web.UI;
using System.Web.UI.WebControls;
using Syn.Bot.Channels.Testing;





namespace Project.Controllers
{
   

    public class QueriesController : Controller
    {
        private RegisterUserEntities db = new RegisterUserEntities();

       // private static WidgetChannel WidgetChannel { get; }

      //  private static OscovaBot Bot { get; }

        // GET: Queries
        public ActionResult Index()
        {
            return View(db.Queries.ToList());
        }

        // GET: Queries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = db.Queries.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // GET: Queries/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Queries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SNo,Request,Keyword1,Keyword2,Keyword3,Response")] Query query)
        {
            if (ModelState.IsValid)
            {
                db.Queries.Add(query);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(query);
        }

        // GET: Queries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = db.Queries.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // POST: Queries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SNo,Request,Keyword1,Keyword2,Keyword3,Response")] Query query)
        {
            if (ModelState.IsValid)
            {
                db.Entry(query).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(query);
        }

        // GET: Queries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = db.Queries.Find(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // POST: Queries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Query query = db.Queries.Find(id);
            db.Queries.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult BotInfo([Bind(Include = "SNo,Request,Keyword1,Keyword2,Keyword3,Response")] Query query)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var check = db.Queries.FirstOrDefault(s => s.Request == query.Request);
        //        if (check == null)
        //        {
        //            ViewBag.error = "Incorrect Query";
        //        }
        //        else
        //        {
        //            var bot = new OscovaBot();
        //            bot.Dialogs.Add(new ChannelTestDialog(bot));
        //            bot.Trainer.StartTraining();
        //            bot.MainUser.ResponseReceived += (sender, resArg) =>
        //            {
        //                _=resArg.Response.Text;

        //            };

        //        }


        //    }

        //    return RedirectToAction("Index");
        //   // return View();

        //}

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
