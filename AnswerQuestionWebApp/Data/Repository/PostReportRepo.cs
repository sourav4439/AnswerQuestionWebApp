using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using Microsoft.EntityFrameworkCore;

namespace AnswerQuestionWebApp.Data.Repository
{
    public class PostReportRepo:MainRepository<Postreport>,IPostReportRepo
    {
        public PostReportRepo(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Postreport> GetPostreportsReview()
        {
            return Db.Postreports.Include(p => p.Post).Include(u => u.ApplicationUsers).ToList();
        }
    }
}
