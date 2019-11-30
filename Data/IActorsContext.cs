using F1Schedule.Models.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Data
{
    public interface IActorsContext
    {
        Task<List<Actor>> GetActorsList();
        Task<Actor> GetActorsSingle(int? id);
        Task AddAndSaveActor(Actor var);
        Task SetActor(Actor var);
        Task DeleteActor(int id);
        bool IsEntityExist(int id);
    }
}