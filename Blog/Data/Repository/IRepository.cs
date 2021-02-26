using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Data.Repository
{
    public interface IRepository
    {
        PostModel GetPost(int id);
        List<PostModel> GetAllPosts();
        List<PostModel> GetAllPosts(string Category);
        void AddPost(PostModel post);
        void UpdatePost(PostModel post);
        void RemovePost(int id);

        Task<bool> SaveChanges();

        SeedPostModel GetSeedPost(int id);
        List<SeedPostModel> GetSeedAllPosts();
    }
}
