using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmManager.Models
{
    public class MovieActorViewModel
    {
        [Required]
        public Movie Movie { get; set; }
        public IEnumerable<Actor> AllActors { get; set; }
        public IEnumerable<string> Actors { get; set; }
        [Required]
        public int DirectorIDDirector { get; set; }
    }
}