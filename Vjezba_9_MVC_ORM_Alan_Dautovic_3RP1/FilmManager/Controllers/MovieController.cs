using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using System.Web.WebPages.Html;
using FilmManager.Models;

namespace FilmManager.Controllers
{
    public class MovieController : Controller
    {
        private readonly ModelContainer db = new ModelContainer();

        ~MovieController() 
        {
            db.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            return View(db.Movies);
        }

        // GET: Movie/Details/5
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
            Movie movie = db.Movies
                .Include(a => a.MovieUploadedFiles)                
                .SingleOrDefault(m => m.IDMovie == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            ViewData["Directors"] = PrepareDirectors();
            List<Actor> notSelectedActors = new List<Actor>();
            foreach (Actor item in db.Actors)
            {
                if (!movie.Actors.ToList().Contains(item))
                {
                    notSelectedActors.Add(item);
                }
            }
            ViewData["Actors"] = notSelectedActors;

            return View(movie);
        }
      
        private List<System.Web.Mvc.SelectListItem> PrepareDirectors()
        {
            IEnumerable<Director> directors = db.Directors;
            List<System.Web.Mvc.SelectListItem> selectListItems = new List<System.Web.Mvc.SelectListItem>();

            directors.ForEach(d => selectListItems.Add(new System.Web.Mvc.SelectListItem { Text = d.FirstName + " " + d.LastName, Value = d.IDDirector.ToString() }));            

            return selectListItems;
        }

        // GET: Movie/Create
        public ActionResult Create()
        {            
            MovieActorViewModel movieActorViewModel= new MovieActorViewModel { AllActors = db.Actors };
            ViewData["Directors"] = PrepareDirectors();
            return View(movieActorViewModel);
        }     

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(MovieActorViewModel movieActorViewModel, IEnumerable<HttpPostedFileBase> files)            
        {            
            if (ModelState.IsValid)
            {
                movieActorViewModel.Movie.MovieUploadedFiles = new List<MovieUploadedFile>();
                IEnumerable<string> selectedActorsId = movieActorViewModel.Actors;
                HashSet<Actor> selectedActors = new HashSet<Actor>();

                foreach (var item in db.Actors)
                {
                    if (selectedActorsId.ToList().Exists(x => x.Equals(item.IDActor.ToString())))
                    {
                        selectedActors.Add(item);
                    }
                }

                movieActorViewModel.Movie.Actors = selectedActors;

                AddFiles(movieActorViewModel.Movie, files);

                movieActorViewModel.Movie.DirectorIDDirector = movieActorViewModel.DirectorIDDirector;

                db.Movies.Add(movieActorViewModel.Movie);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
           
        }

        private void AddFiles(Movie movie, IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var picture = new MovieUploadedFile
                    {
                        Name = file.FileName,
                        ContentType = file.ContentType,
                    };
                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        picture.Content = reader.ReadBytes(file.ContentLength);
                    }
                    movie.MovieUploadedFiles.Add(picture);
                }
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommonAction(id);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IEnumerable<HttpPostedFileBase> files)
        {
            Movie movie = db.Movies.Find(id);
            if(TryUpdateModel(movie, "", new string[]
            {
                nameof(Movie.Name),
                nameof(Movie.Duration),
                nameof(Movie.Description),
                nameof(Movie.Genre),
                nameof(Movie.ReleaseDate),
                nameof(Movie.DirectorIDDirector)
            }))
            {
                AddFiles(movie, files);

                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommonAction(id);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.MovieUploadedFiles.RemoveRange(db.MovieUploadedFiles.Where(f => f.MovieIDMovie == id));
            Movie deletingMovie = db.Movies.Find(id);
            deletingMovie.Actors.Clear();
            db.Movies.Remove(deletingMovie);
            db.SaveChanges();
            return RedirectToAction("Index");                  
        }
        
        public ActionResult RemoveActorFromMovie(int id, int movieId) 
        {
            Movie movie = db.Movies.Find(movieId);
            movie.Actors.Remove(db.Actors.Find(id));
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        public ActionResult AddActorToMovie(int id, int movieId)
        {
            Movie movie = db.Movies.Find(movieId);
            movie.Actors.Add(db.Actors.Find(id));
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
    }
}
