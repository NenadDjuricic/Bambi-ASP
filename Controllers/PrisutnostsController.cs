using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestDataBase;

namespace TestDataBase.Controllers
{
    public class PrisutnostsController : Controller
    {
        private Vrtic db = new Vrtic();

        // GET: Prisutnosts
        public ActionResult Index()
        {
            var prisutnosts = db.Prisutnosts.Include(p => p.Dete).Include(p => p.DnevnikRada);
            return View(prisutnosts.ToList());
        }

        // GET: Prisutnosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisutnost prisutnost = db.Prisutnosts.Find(id);
            if (prisutnost == null)
            {
                return HttpNotFound();
            }
            return View(prisutnost);
        }

        // GET: Prisutnosts/Create
        public ActionResult Create()
        {
            ViewBag.DeteID = new SelectList(db.Detes, "DeteID", "Ime");
            ViewBag.DnevnikRadaID = new SelectList(db.DnevnikRadas, "DnevnikRadaID", "OpisRada");
            return View();
        }

        // POST: Prisutnosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrisutnostID,DnevnikRadaID,Evidencija,DeteID")] Prisutnost prisutnost)
        {
            if (ModelState.IsValid)
            {
                db.Prisutnosts.Add(prisutnost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeteID = new SelectList(db.Detes, "DeteID", "Ime", prisutnost.DeteID);
            ViewBag.DnevnikRadaID = new SelectList(db.DnevnikRadas, "DnevnikRadaID", "OpisRada", prisutnost.DnevnikRadaID);
            return View(prisutnost);
        }

        // GET: Prisutnosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisutnost prisutnost = db.Prisutnosts.Find(id);
            if (prisutnost == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeteID = new SelectList(db.Detes, "DeteID", "Ime", prisutnost.DeteID);
            ViewBag.DnevnikRadaID = new SelectList(db.DnevnikRadas, "DnevnikRadaID", "OpisRada", prisutnost.DnevnikRadaID);
            return View(prisutnost);
        }

        // POST: Prisutnosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrisutnostID,DnevnikRadaID,Evidencija,DeteID")] Prisutnost prisutnost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prisutnost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeteID = new SelectList(db.Detes, "DeteID", "Ime", prisutnost.DeteID);
            ViewBag.DnevnikRadaID = new SelectList(db.DnevnikRadas, "DnevnikRadaID", "OpisRada", prisutnost.DnevnikRadaID);
            return View(prisutnost);
        }

        // GET: Prisutnosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisutnost prisutnost = db.Prisutnosts.Find(id);
            if (prisutnost == null)
            {
                return HttpNotFound();
            }
            return View(prisutnost);
        }

        // POST: Prisutnosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prisutnost prisutnost = db.Prisutnosts.Find(id);
            db.Prisutnosts.Remove(prisutnost);
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
