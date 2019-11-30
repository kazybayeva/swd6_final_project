using F1Schedule.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Data
{
    public interface IPostsContext
    {
        Task<List<Post>> GetPostsList();
        Task<Post> GetPostsSingle(int? id);
        Task AddAndSavePost(Post var);
        Task SetPost(Post var);
        Task DeletePost(int id);
        bool IsEntityExist(int id);
    }
}