using System;
using System.Collections.Generic;
using Blog.Models;
using Microsoft.AspNetCore.Http;

namespace Blog.ViewModels
{
    public class SeedPostViewModel
    {
        public IEnumerable<PostModel> Posts { get; set; }
        public IEnumerable<SeedPostModel> SeedPosts { get; set; }
    }
}
