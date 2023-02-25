using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmManager.Controllers
{
    public class FileController : Controller
    {

        private readonly ModelContainer db = new ModelContainer();

        ~FileController() 
        { 
            db.Dispose();
        }

        // GET: File
        public ActionResult Index(int id)
        {
            var uploadedFile = db.MovieUploadedFiles.Find(id);
            return File(uploadedFile.Content, uploadedFile.ContentType);
        }

        public ActionResult Delete(int id)
        {
            db.MovieUploadedFiles.Remove(db.MovieUploadedFiles.Find(id));
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
    }
}