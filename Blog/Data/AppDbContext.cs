using System;
using Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{

    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<PostModel> Posts { get; set; }
        public DbSet<SeedPostModel> SeedPosts { get; set; }


        ////////////// Seed data /////////////

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SeedPostModel>().HasData(
                new SeedPostModel
                {
                    Id = 1,
                    Title = "Innovative photography in 2021",
                    Body = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                    Image = "jean-gerber-4GpD1oP-C8U-unsplash.jpg",
                    Description = "Styles of photography",
                    Tags = "photography, camera",
                    Category = "Photography",
                    Created = DateTime.Now
                },
                new SeedPostModel
                {
                    Id = 2,
                    Title = "Working in the tech industry",
                    Body = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Image = "glenn-carstens-peters-npxXWgQ33ZQ-unsplash.jpg",
                    Description = "pic of me working",
                    Tags = "coding, laptop, work",
                    Category = "Programing",
                    Created = DateTime.Now
                }
            );
        }

    }

}
