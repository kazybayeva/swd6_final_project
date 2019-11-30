  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Schedule.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace F1Schedule.Data
{
    public class UsersContext : IUsersContext
    {
        private readonly BaseContext _context;

        public UsersContext(BaseContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetUsersList()
        {
            return _context.Users.ToListAsync();
        }

        public Task<User> GetUsersSingle(int? id)
        {
            return _context.Users.FindAsync(id);
        }

        public Task AddAndSaveUser(User var)
        {
            _context.Add(var);
            return _context.SaveChangesAsync();
        }

        public Task SetUser(User var)
        {
            _context.Update(var);
            return _context.SaveChangesAsync();
        }

        public Task DeleteUser(int id)
        {
            var var = _context.Users.FindAsync(id);
            _context.Users.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}