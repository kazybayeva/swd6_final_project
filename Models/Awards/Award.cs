using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Madina.Models.Movies;
using Madina.Models.MoviesAwards;

namespace Madina.Models.Awards
{
    public class Award
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(40, MinimumLength = 5)]
        public string Name { get; set; }

        [Display(Name = "Year")]
        [Required]
        [Range(1910, 2019)]
        public int Year { get; set; }

        [Display(Name = "Movies")]
        public List<MoviesAward> Movies { get; set; }
    }
}
