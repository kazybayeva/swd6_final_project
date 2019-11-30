using Madina.Models.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Madina.Models.Attributes
{
    public class GenreValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var genre = (string)value;

            if (movie.Year < 1950)
            {
                if (genre != null)
                    return new ValidationResult("There are no such genres");
                else
                    return ValidationResult.Success;

            }
            if (movie.Year > 1960)
            {
                if (genre != "crime" || genre != "novel" || genre != "railroad")
                    return ValidationResult.Success;
                else
                    return new ValidationResult("There wass no such genre in those years");

            }

            return new ValidationResult("Genre can not be empty");
        }
       }
   }
