using F1Schedule.Models.ProfilesInfoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Data
{
    public interface IProfilesInfoesContext
    {
        Task<List<ProfilesInfo>> GetProfilesInfoesList();
        Task<ProfilesInfo> GetProfilesInfoesSingle(int? id);
        Task AddAndSaveProfilesInfo(ProfilesInfo var);
        Task SetProfilesInfo(ProfilesInfo var);
        Task DeleteProfilesInfo(int id);
        bool IsEntityExist(int id);
    }
}