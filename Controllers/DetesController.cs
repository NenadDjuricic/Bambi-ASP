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
    public class DetesController : Controller
    {
        private Vrtic db = new Vrtic();

        // GET: Detes
        public ActionResult Index(string search , string vaspitnaGrupa)
        {
            var detes = db.Detes.Include(d => d.Domacinstvo).Include(d => d.VaspitnaGrupa);
            if (!String.IsNullOrEmpty(search))
            {
                detes = detes.Where(p => p.Ime.Contains(search) ||
                p.Prezime.Contains(search));
                ViewBag.Search = search;
            }
            var VaspitnaGrupa = detes.OrderBy(p => p.VaspitnaGrupa.Naziv).Select(p =>
            p.VaspitnaGrupa.Naziv).Distinct();
            if (!String.IsNullOrEmpty(vaspitnaGrupa))
            {
                detes = detes.Where(p => p.VaspitnaGrupa.Naziv == vaspitnaGrupa);
            }
            ViewBag.VaspitnaGrupa = new SelectList(VaspitnaGrupa);
            return View(detes.ToList());
        }

        // GET: Detes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dete dete = db.Detes.Find(id);
            if (dete == null)
            {
                return HttpNotFound();
            }
            return View(dete);
        }

        // GET: Detes/Create
        public ActionResult Create()
        {
            ViewBag.DomacinstvoID = new SelectList(db.Domacinstvoes, "DomacinstvoID", "Adresa");
            ViewBag.VaspitnaGrupaID = new SelectList(db.VaspitnaGrupas, "VaspitnaGrupaID", "Naziv");
            return View();
        }

        // POST: Detes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeteID,Ime,Prezime,DatumRodjenja,JMBG,ImeRoditelja,DomacinstvoID,VaspitnaGrupaID")] Dete dete)
        {
            if (ModelState.IsValid)
            {
                db.Detes.Add(dete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DomacinstvoID = new SelectList(db.Domacinstvoes, "DomacinstvoID", "Adresa", dete.DomacinstvoID);
            ViewBag.VaspitnaGrupaID = new SelectList(db.VaspitnaGrupas, "VaspitnaGrupaID", "Naziv", dete.VaspitnaGrupaID);
            return View(dete);
        }

        // GET: Detes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dete dete = db.Detes.Find(id);
            if (dete == null)
            {
                return HttpNotFound();
            }
            ViewBag.DomacinstvoID = new SelectList(db.Domacinstvoes, "DomacinstvoID", "Adresa", dete.DomacinstvoID);
            ViewBag.VaspitnaGrupaID = new SelectList(db.VaspitnaGrupas, "VaspitnaGrupaID", "Naziv", dete.VaspitnaGrupaID);
            return View(dete);
        }

        // POST: Detes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeteID,Ime,Prezime,DatumRodjenja,JMBG,ImeRoditelja,DomacinstvoID,VaspitnaGrupaID")] Dete dete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DomacinstvoID = new SelectList(db.Domacinstvoes, "DomacinstvoID", "Adresa", dete.DomacinstvoID);
            ViewBag.VaspitnaGrupaID = new SelectList(db.VaspitnaGrupas, "VaspitnaGrupaID", "Naziv", dete.VaspitnaGrupaID);
            return View(dete);
        }

        // GET: Detes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dete dete = db.Detes.Find(id);
            if (dete == null)
            {
                return HttpNotFound();
            }
            return View(dete);
        }

        // POST: Detes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dete dete = db.Detes.Find(id);
            db.Detes.Remove(dete);
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
