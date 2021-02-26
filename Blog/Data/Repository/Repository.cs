using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }


        public void AddPost(PostModel post)
        {
            _context.Posts.Add(post);
        }


        public List<PostModel> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public List<PostModel> GetAllPosts(string category)
        {
            return _context.Posts
                .Where(p => p.Category.ToLower().Equals(category.ToLower())).ToList()
                .ToList();
        }


        public PostModel GetPost(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }


        public void RemovePost(int id)
        {
            _context.Posts.Remove(GetPost(id));
        }


        public void UpdatePost(PostModel post)
        {
            _context.Posts.Update(post);
        }


        public async Task<bool> SaveChanges()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }


        ///////////// Seed data ///////////////

        public SeedPostModel GetSeedPost(int id)
        {
            return _context.SeedPosts.FirstOrDefault(p => p.Id == id);
        }

        public List<SeedPostModel> GetSeedAllPosts()
        {
            return _context.SeedPosts.ToList();
        }
    }
}
