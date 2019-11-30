using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Madina.Models.Actors;
using Madina.Models.Movies;

namespace Madina.Models.MoviesActors
{
    public class MoviesActor
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
