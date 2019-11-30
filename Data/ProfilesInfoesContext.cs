  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Schedule.Models.ProfilesInfoes;
using Microsoft.EntityFrameworkCore;

namespace F1Schedule.Data
{
    public class ProfilesInfoesContext : IProfilesInfoesContext
    {
        private readonly BaseContext _context;

        public ProfilesInfoesContext(BaseContext context)
        {
            _context = context;
        }

        public Task<List<ProfilesInfo>> GetProfilesInfoesList()
        {
            return _context.ProfilesInfoes.ToListAsync();
        }

        public Task<ProfilesInfo> GetProfilesInfoesSingle(int? id)
        {
            return _context.ProfilesInfoes.FindAsync(id);
        }

        public Task AddAndSaveProfilesInfo(ProfilesInfo var)
        {
            _context.Add(var);
            return _context.SaveChangesAsync();
        }

        public Task SetProfilesInfo(ProfilesInfo var)
        {
            _context.Update(var);
            return _context.SaveChangesAsync();
        }

        public Task DeleteProfilesInfo(int id)
        {
            var var = _context.ProfilesInfoes.FindAsync(id);
            _context.ProfilesInfoes.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.ProfilesInfoes.Any(e => e.Id == id);
        }
    }
}