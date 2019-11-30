using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Madina.Models.Movies;

namespace Madina.Models.Directors
{
    public class Director
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(40, MinimumLength = 5)]
        public string Name { get; set; }

        [Display(Name = "Country")]
        [Required]
        [StringLength(40, MinimumLength = 5)]
        public string Country { get; set; }

        [Display(Name = "Movie")]
        public List<Movie> Movie { get; set; }
    }
}
