using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Madina.Models.MoviesActors;

namespace Madina.Models.Actors
{
    public class Actor : IValidatableObject
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name  { get; set; }

        [Display(Name = "Gender")]
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string Gender { get; set; }

        [Display(Name = "Movies")]
        public List<MoviesActor> Movies { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int wordCount = 1;

            for (int i = 0; i < Name.Length; i++)
            {
                if (Name[i] == ' ')
                    wordCount++;
            }
            if (wordCount != 2)
                yield return new ValidationResult("Name must have at least two words: last and first names");
        }
    }
}
