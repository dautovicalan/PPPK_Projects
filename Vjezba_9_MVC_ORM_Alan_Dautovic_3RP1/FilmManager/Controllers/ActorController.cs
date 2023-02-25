using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmManager.Controllers
{
    public class ActorController : Controller
    {
        private readonly ModelContainer db = new ModelContainer();

        ~ActorController() { db.Dispose(); }

        // GET: Actor
        public ActionResult Index()
        {
            return View(db.Actors);
        }

        // GET: Actor/Details/5
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
            Actor actor = db.Actors.SingleOrDefault(m => m.IDActor == id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        [HttpPost]
        public ActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
            
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommonAction(id);
        }

        // POST: Actor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id)
        {
            Actor actor = db.Actors.Find(id);
            if (TryUpdateModel(actor, "", new string[] {
                nameof(Actor.FirstName),
                nameof(Actor.LastName),
                nameof(Actor.Age)
            }))
            {
                db.Entry(actor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actor/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommonAction(id);
        }

        // POST: Actor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.Actors.Remove(db.Actors.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}
