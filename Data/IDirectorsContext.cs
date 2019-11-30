  
using F1Schedule.Models.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Data
{
    public interface IDirectorsContext
    {
        Task<List<Director>> GetDirectorsList();
        Task<Director> GetDirectorsSingle(int? id);
        Task AddAndSaveDirectors(Director var);
        Task SetDirector(Director var);
        Task DeleteDirector(int id);
        bool IsEntityExist(int id);
    }
}