using F1Schedule.Models.Awards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Data
{
    public interface IAwardsContext
    {
        Task<List<Award>> GetAwardsList();
        Task<Award> GetAwardsSingle(int? id);
        Task AddAndSaveAward(Award var);
        Task SetAward(Award var);
        Task DeleteAward(int id);
        bool IsEntityExist(int id);
    }
}