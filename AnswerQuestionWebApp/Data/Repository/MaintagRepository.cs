using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Data.Repository
{
    public class MaintagRepository : MainRepository<MainTag>, ImainTagRepository
    {
        public MaintagRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
