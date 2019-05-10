using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Models.Post;

namespace AnswerQuestionWebApp.Data.Interfaces
{
   public interface IPostrepo:IRepository<Post>
   {
       IEnumerable<Post> GetPostsbySubtagId(int id);
       IEnumerable<Post> GetPostsbyMainTagId(int id);
       IEnumerable<Post> GetPostsbyUserId(string id);
       IEnumerable<Post> Getallpost();
       



   }
}
