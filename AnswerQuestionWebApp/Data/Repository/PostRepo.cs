using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using Microsoft.EntityFrameworkCore;
// ReSharper disable All

namespace AnswerQuestionWebApp.Data.Repository
{
    public class PostRepo:MainRepository<Post>,IPostrepo
    {
        public PostRepo(ApplicationDbContext context) : base(context)
        {
        }


        public IEnumerable<Post> GetPostsbySubtagId(int id)
        {
           return Db.Posts.Where(s => s.SubtagId == id)
                .Include(c => c.Subtag)
                .Include(m => m.Tag)
                .Include(u=>u.ApplicationUsers).ToList();
        }

        public IEnumerable<Post> GetPostsbyMainTagId(int id)
        {
            return Db.Posts.Where(m => m.TagId == id)
                .Include(c => c.Subtag)
                .Include(m => m.Tag)
                .Include(u => u.ApplicationUsers)
                .ToList();
        }

       

        public IEnumerable<Post> GetPostsbyUserId(string id)
        {
            return Db.Posts.Where(u => u.ApplicationUsersId == id)
                .Include(c => c.Subtag)
                .Include(m => m.Tag)
                .Include(u => u.ApplicationUsers)
                .ToList();
        }
    }
}
