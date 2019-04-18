using System;
using System.Collections.Generic;
using System.Text;
using AnswerQuestionWebApp.Models;
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
       
        public DbSet<Post> posts { get; set; }
        public DbSet<PostTag> postTags { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Langues> Langues { get; set; }
    }
}
