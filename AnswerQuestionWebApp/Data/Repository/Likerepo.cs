using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;

namespace AnswerQuestionWebApp.Data.Repository
{
    public class Likerepo:MainRepository<Likepost>,ILikeRepo
    {
        public Likerepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
