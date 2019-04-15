using System;
using System.Collections.Generic;
using System.Text;
using AnswerQuestionWebApp.Models;
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
    }
}
