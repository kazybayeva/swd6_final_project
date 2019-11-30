  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Schedule.Models.Posts;
using Microsoft.EntityFrameworkCore;

namespace F1Schedule.Data
{
    public class PostsContext : IPostsContext
    {
        private readonly BaseContext _context;

        public PostsContext(BaseContext context)
        {
            _context = context;
        }

        public Task<List<Post>> GetPostsList()
        {
            return _context.Posts.ToListAsync();
        }

        public Task<Post> GetPostsSingle(int? id)
        {
            return _context.Posts.FindAsync(id);
        }

        public Task AddAndSavePost(Post var)
        {
            _context.Add(var);
            return _context.SaveChangesAsync();
        }

        public Task SetPost(Post var)
        {
            _context.Update(var);
            return _context.SaveChangesAsync();
        }

        public Task DeletePost(int id)
        {
            var var = _context.Posts.FindAsync(id);
            _context.Posts.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}