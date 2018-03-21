using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TestDataBase.ViewModel;




namespace TestDataBase.Controllers
{
    public class DetesController : Controller
    {
        private Vrtic db = new Vrtic();

        // GET: Detes
        public ActionResult Index(string search , string vaspitnaGrupa, string sortBy, int? page)
        {
            //instantiate a new view model
            DeteIndexViewModel viewModel = new DeteIndexViewModel();

            //select the products
            var detes = db.Detes.Include(d => d.Domacinstvo).Include(d => d.VaspitnaGrupa);
            //perform the search and save the search string to the viewModel
            if (!String.IsNullOrEmpty(search))
            {
                detes = detes.Where(p => p.Ime.Contains(search) ||
                p.Prezime.Contains(search));
                viewModel.Search = search;
            }
            var VaspitnaGrupa = detes.OrderBy(p => p.VaspitnaGrupa.Naziv).Select(p =>
            p.VaspitnaGrupa.Naziv).Distinct();

            //group search results into categories and count how many items in each category
            viewModel.VaspitnaWithCount = from matchingDetes in detes
                                          where

                                          matchingDetes.VaspitnaGrupaID != null
                                          group matchingDetes by
                                          matchingDetes.VaspitnaGrupa.Naziv into
                                          vasGroup
                                          select new VaspitnaWithCount()
                                          {

                                              VaspitnaIme = vasGroup.Key,
                                              DecaCount = vasGroup.Count()

                                          };

            if (!String.IsNullOrEmpty(vaspitnaGrupa))
            {
                detes = detes.Where(p => p.VaspitnaGrupa.Naziv == vaspitnaGrupa);
                viewModel.VaspitnaGrupa = vaspitnaGrupa;
            }

            

            //sort the results
            switch (sortBy)
            {
                case "name_desc":
                    detes = detes.OrderBy(p => p.Ime);
                    break;
                case "datum_opadajuce":
                    detes = detes.OrderByDescending(p => p.DatumRodjenja);
                    break;
                default:
                    detes = detes.OrderBy(p => p.Ime);
                    break;
            }

            int currentPage = (page ?? 1);
           
            viewModel.Detes = detes.ToPagedList(currentPage, Constants.PageItems);
            viewModel.SortBy = sortBy;
            viewModel.Sorts = new Dictionary<string, string>
            {
            {"Po imenu", "name_desc" },
            {"Datum opadajuce", "datum_opadajuce" }
            };

            return View(viewModel);
          
           
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
