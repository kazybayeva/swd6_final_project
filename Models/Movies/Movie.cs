using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Madina.Models.Actors;
using Madina.Models.Attributes;
using Madina.Models.Directors;
using Madina.Models.MoviesActors;
using Madina.Models.MoviesAwards;
using Microsoft.AspNetCore.Mvc;

namespace Madina.Models.Movies
{
    public class Movie
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(40, MinimumLength = 5)]
        public string Name { get; set; }

        [GenreValidation]
        [Display(Name = "Genre")]
        [StringLength(20, MinimumLength = 4)]
        public string Genre { get; set; }

        [Display(Name = "Year")]
        [Required]
        [Range(1910, 2022)]
        public int Year { get; set; }

        [Display(Name = "Director")]
        public Director Director { get; set; }

        [Display(Name = "Awards")]
        public List<MoviesAward> Awards { get; set; }

        [Display(Name = "Actors")]
        public List<MoviesActor> Actors { get; set; }
    }
}
