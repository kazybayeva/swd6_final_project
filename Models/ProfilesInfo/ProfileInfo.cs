using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Madina.Models.Movies;
using Madina.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Madina.Models.ProfilesInfo
{
    public class ProfileInfo
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Age")]
        [Required]
        public string Age { get; set; }

        [Display(Name = "Country")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Country { get; set; }

        [Display(Name = "Gender")]
        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Remote("VerifyGender", controller: "ProfileInfoes")]
        public string Gender { get; set; }

        [Display(Name = "Movie")]
        public List<Movie> Movie { get; set; }
    }
}
