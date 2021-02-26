using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Blog.Data;
using Blog.Data.Repository;
using Blog.Data.FileManager;
using Blog.ViewModels;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public HomeController(IRepository context, IFileManager fileManager)
        {
            _repo = context;
            _fileManager = fileManager;

        }

        // Gets all seed posts and created posts
        public IActionResult Index()
        {
            SeedPostViewModel mymodel = new SeedPostViewModel();
            mymodel.Posts = _repo.GetAllPosts();
            mymodel.SeedPosts = _repo.GetSeedAllPosts();
            return View(mymodel);
        }


        // Gets a single created post
        public IActionResult Post(int id) => View(_repo.GetPost(id));

        // Gets a single seed post
        public IActionResult SeedPost(int id) => View(_repo.GetSeedPost(id));

        // Gets an image
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image) => new FileStreamResult(_fileManager.ImageStream(image), $"image/{image.Substring(image.LastIndexOf('.') + 1)}");

    }
}
