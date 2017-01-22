using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

using LeagueDataAnalyzer.DAL;
using LeagueDataAnalyzer.Models;

namespace LeagueDataAnalyzer.Controllers
{
    public class MatchesHistoryController : Controller
    {
        private MatchHistoryContext db = new MatchHistoryContext();

        public ActionResult Example()
        {
            return View();
        }

        public ActionResult GetKey()
        {
            ViewBag.RiotKey = ConfigurationManager.AppSettings["riot_key"];

            return View();
        }

        // GET: MatchHistories
        public ActionResult Index()
        {
            return View(db.MatchesResults.ToList());
        }

        // GET: MatchHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchResult matchResult = db.MatchesResults.Find(id);
            if (matchResult == null)
            {
                return HttpNotFound();
            }
            return View(matchResult);
        }

        // GET: MatchHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatchHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,matchId")] MatchResult matchResult)
        {
            if (ModelState.IsValid)
            {
                db.MatchesResults.Add(matchResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matchResult);
        }

        // GET: MatchHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchResult matchResult = db.MatchesResults.Find(id);
            if (matchResult == null)
            {
                return HttpNotFound();
            }
            return View(matchResult);
        }

        // POST: MatchHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,matchId")] MatchResult matchResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matchResult);
        }

        // GET: MatchHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchResult matchResult = db.MatchesResults.Find(id);
            if (matchResult == null)
            {
                return HttpNotFound();
            }
            return View(matchResult);
        }

        // POST: MatchHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchResult matchResult = db.MatchesResults.Find(id);
            db.MatchesResults.Remove(matchResult);
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
