using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Schedule.Models.Movies;
using Microsoft.EntityFrameworkCore;

namespace F1Schedule.Data
{
    public class MovieContext : IMoviesContext
    {
        private readonly BaseContext _context;

        public MovieContext(BaseContext context)
        {
            _context = context;
        }

        public Task<List<Movie>> GetMoviesList()
        {
            return _context.Movies.ToListAsync();
        }

        public Task<Movie> GetMoviesSingle(int? id)
        {
            return _context.Movies.FindAsync(id);
        }

        public Task AddAndSaveMovies(Movie var)
        {
            _context.Add(var);
            return _context.SaveChangesAsync();
        }

        public Task SetMovie(Movie var)
        {
            _context.Update(var);
            return _context.SaveChangesAsync();
        }

        public Task DeleteMovie(int id)
        {
            var var = _context.Movies.FindAsync(id);
            _context.Movies.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}