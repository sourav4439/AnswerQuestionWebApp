using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Data.Repository
{
    public class Subtagrepo : MainRepository<Subtag>, ISubtagsrepo
    {
        public Subtagrepo(ApplicationDbContext context) : base(context)
        {
        }

       

       public IEnumerable<Subtag> GetsubtagwithMaintags()
        {
            return Db.Subtags.Include(m => m.MainTag).ToList();
        }
    }
}
