//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilmManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            this.MovieUploadedFiles = new HashSet<MovieUploadedFile>();
            this.Actors = new HashSet<Actor>();
        }
    
        public int IDMovie { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length 50")]
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length 50")]
        public string Description { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Max length 30")]
        public string Genre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ReleaseDate { get; set; }
        [Required]        
        public int DirectorIDDirector { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieUploadedFile> MovieUploadedFiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual Director Director { get; set; }
    }
}
