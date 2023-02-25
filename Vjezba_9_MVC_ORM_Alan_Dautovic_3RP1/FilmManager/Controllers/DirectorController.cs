using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmManager.Controllers
{
    public class DirectorController : Controller
    {
        private readonly ModelContainer db = new ModelContainer();

        ~DirectorController() { db.Dispose(); }

        // GET: Director
        public ActionResult Index()
        {
            return View(db.Directors);
        }

        // GET: Director/Details/5
        public ActionResult Details(int? id)
        {
            return CommonAction(id);
        }

        private ActionResult CommonAction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.SingleOrDefault(m => m.IDDirector == id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // GET: Director/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Director/Create
        [HttpPost]
        public ActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Director/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommonAction(id);
        }

        // POST: Director/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Director director = db.Directors.Find(id);
            if (TryUpdateModel(director, "", new string[] {
                nameof(Director.FirstName),
                nameof(Director.LastName),
                nameof(Director.Age)
            }))
            {
                db.Entry(director).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(director);
        }

        // GET: Director/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommonAction(id);
        }

        // POST: Director/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.Directors.Remove(db.Directors.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
