using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Schedule.Models.Directors;
using Microsoft.EntityFrameworkCore;

namespace F1Schedule.Data
{
    public class DirectorContext : IDirectorsContext
    {
        private readonly BaseContext _context;

        public DirectorContext(BaseContext context)
        {
            _context = context;
        }

        public Task<List<Director>> GetDirectorsList()
        {
            return _context.Directors.ToListAsync();
        }

        public Task<Director> GetDirectorsSingle(int? id)
        {
            return _context.Directors.FindAsync(id);
        }

        public Task AddAndSaveDirectors(Director var)
        {
            _context.Add(var);
            return _context.SaveChangesAsync();
        }

        public Task SetDirector(Director var)
        {
            _context.Update(var);
            return _context.SaveChangesAsync();
        }

        public Task DeleteDirector(int id)
        {
            var var = _context.Directors.FindAsync(id);
            _context.Directors.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Directors.Any(e => e.Id == id);
        }
    }
}