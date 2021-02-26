using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.FileManager;
using Blog.Data.Repository;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public PanelController(IRepository context, IFileManager fileManager)
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



        // Gets a single post to edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new PostViewModel());
            }
            else
            {
                var post = _repo.GetPost((int)id);

                return View(new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body,
                    CurrentImage = post.Image,
                    Description = post.Description,
                    Tags = post.Tags,
                    Category = post.Category,
                });
            }
        }



        // Updates the edited post or creates new post
        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new PostModel
            {
                Id = vm.Id,
                Title = vm.Title,
                Body = vm.Body,
                Description = vm.Description,
                Tags = vm.Tags,
                Category = vm.Category,
            };



            if (vm.Image == null)
            {
                post.Image = vm.CurrentImage;
            }
            else
            {
                if (!String.IsNullOrEmpty(vm.CurrentImage))
                {
                    _fileManager.RemoveImage(vm.CurrentImage);
                }

                post.Image = await _fileManager.SaveImage(vm.Image);
            }



            if (post.Id > 0)
            {
                _repo.UpdatePost(post);
            }
            else
            {
                _repo.AddPost(post);
            }


            if (await _repo.SaveChanges())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }



        // Removes a post
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
