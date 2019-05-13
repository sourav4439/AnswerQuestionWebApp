using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Models.Post;

namespace AnswerQuestionWebApp.Models.ViewModels
{
    public class SinglepostViewmodel
    {
        public Post.Post Post { get; set; }
        public CommentPost CommentPost { get; set; }
    }
}
