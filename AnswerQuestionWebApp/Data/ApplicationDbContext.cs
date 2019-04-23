using System;
using System.Collections.Generic;
using System.Text;
using AnswerQuestionWebApp.Models;
using AnswerQuestionWebApp.Models.Post;
using AnswerQuestionWebApp.Models.UsersProfiles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnswerQuestionWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        //This property for Post
        public DbSet<Post> Posts { get; set; }
        public DbSet<MainTag> PostTags { get; set; }
        public DbSet<Subtag> Subtags { get; set; }
        public DbSet<Likepost> Likeposts { get; set; }
        public DbSet<CommentPost> CommentPosts { get; set; }


        //this Property for Users
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Langues> Langues { get; set; }
    }
}
