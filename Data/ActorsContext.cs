  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Schedule.Models.Actors;
using Microsoft.EntityFrameworkCore;

namespace F1Schedule.Data
{
    public class ActorsContext : IActorsContext
    {
        private readonly BaseContext _context;

        public ActorsContext(BaseContext context)
        {
            _context = context;
        }

        public Task<List<Actor>> GetActorsList()
        {
            return _context.Actors.ToListAsync();
        }

        public Task<Actor> GetActorsSingle(int? id)
        {
            return _context.Actors.FindAsync(id);
        }

        public Task AddAndSaveActor(Actor var)
        {
            _context.Add(var);
            return _context.SaveChangesAsync();
        }

        public Task SetActor(Actor var)
        {
            _context.Update(var);
            return _context.SaveChangesAsync();
        }

        public Task DeleteActor(int id)
        {
            var var = _context.Actors.FindAsync(id);
            _context.Actors.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}