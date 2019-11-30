using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Madina.Models.Awards;
using Madina.Models.Movies;

namespace Madina.Models.MoviesAwards
{
    public class MoviesAward
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int AwardId { get; set; }
        public Award Award { get; set; }
    }
}
