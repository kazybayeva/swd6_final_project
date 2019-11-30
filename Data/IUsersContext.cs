using F1Schedule.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Data
{
    public interface IUsersContext
    {
        Task<List<User>> GetUsersList();
        Task<User> GetUsersSingle(int? id);
        Task AddAndSaveUser(User var);
        Task SetUser(User var);
        Task DeleteUser(int id);
        bool IsEntityExist(int id);
    }
}