  using F1Schedule.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Data
{
    public interface IMoviesContext
    {
        Task<List<Movie>> GetMoviesList();
        Task<Movie> GetMoviesSingle(int? id);
        Task AddAndSaveMovies(Movie var);
        Task SetMovie(Movie var);
        Task DeleteMovie(int id);
        bool IsEntityExist(int id);
    }
}