using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SportsBetting.Data;
using SportsBetting.Data.Repositories;
using SportsBetting.Models;

namespace SportsBetting.App.Controllers
{
    public class SportController : Controller
    {

        private GenericRepository<Match> macthRepo = new GenericRepository<Match>(new SportsBettingContext());

        // GET: Sport
        public ActionResult Index()
        {

            var result = macthRepo.GetAll().Where(m => m.Bets.Count != 0 && m.StartDate >= DateTime.Now && m.StartDate <= DateTime.Now.AddDays(1));

            return View(result);
        }



        // GET: Sport/Details/5
        //  public ActionResult Details(int? id)
        //  {
        //      if (id == null)
        //      {
        //          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //      }
        //      Sport sport = db.Sports.Find(id);
        //      if (sport == null)
        //      {
        //          return HttpNotFound();
        //      }
        //      return View(sport);
        //  }

        // GET: Sport/Create
        // public ActionResult Create()
        //   {
        //       return View();
        //   }

        // POST: Sport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //   [HttpPost]
        //   [ValidateAntiForgeryToken]
        //   public ActionResult Create([Bind(Include = "Id,SportName,SportOriginId")] Sport sport)
        //   {
        //       if (ModelState.IsValid)
        //       {
        //           db.Sports.Add(sport);
        //           db.SaveChanges();
        //           return RedirectToAction("Index");
        //       }
        //
        //       return View(sport);
        //   }

        //    // GET: Sport/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Sport sport = db.Sports.Find(id);
        //        if (sport == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(sport);
        //    }

        // POST: Sport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //   [HttpPost]
        //   [ValidateAntiForgeryToken]
        //   public ActionResult Edit([Bind(Include = "Id,SportName,SportOriginId")] Sport sport)
        //   {
        //       if (ModelState.IsValid)
        //       {
        //           db.Entry(sport).State = EntityState.Modified;
        //           db.SaveChanges();
        //           return RedirectToAction("Index");
        //       }
        //       return View(sport);
        //   }
        //
        //   // GET: Sport/Delete/5
        //   public ActionResult Delete(int? id)
        //   {
        //       if (id == null)
        //       {
        //           return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //       }
        //       Sport sport = db.Sports.Find(id);
        //       if (sport == null)
        //       {
        //           return HttpNotFound();
        //       }
        //       return View(sport);
        //   }
        //
        //   // POST: Sport/Delete/5
        //   [HttpPost, ActionName("Delete")]
        //   [ValidateAntiForgeryToken]
        //   public ActionResult DeleteConfirmed(int id)
        //   {
        //       Sport sport = db.Sports.Find(id);
        //       db.Sports.Remove(sport);
        //       db.SaveChanges();
        //       return RedirectToAction("Index");
        //   }

        //   protected override void Dispose(bool disposing)
        //   {
        //       if (disposing)
        //       {
        //           db.Dispose();
        //       }
        //       base.Dispose(disposing);
        //   }
    }
}
