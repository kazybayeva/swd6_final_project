  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Schedule.Models.Awards;
using Microsoft.EntityFrameworkCore;

namespace F1Schedule.Data
{
    public class AwardsContext : IAwardsContext
    {
        private readonly BaseContext _context;

        public AwardsContext(BaseContext context)
        {
            _context = context;
        }

        public Task<List<Award>> GetAwardsList()
        {
            return _context.Awards.ToListAsync();
        }

        public Task<Award> GetAwardsSingle(int? id)
        {
            return _context.Awards.FindAsync(id);
        }

        public Task AddAndSaveAward(Award var)
        {
            _context.Add(var);
            return _context.SaveChangesAsync();
        }

        public Task SetAward(Award var)
        {
            _context.Update(var);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAward(int id)
        {
            var var = _context.Awards.FindAsync(id);
            _context.Awards.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Awards.Any(e => e.Id == id);
        }
    }
}