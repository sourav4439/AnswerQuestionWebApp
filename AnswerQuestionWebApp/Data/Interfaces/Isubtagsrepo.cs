using AnswerQuestionWebApp.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Data.Interfaces
{
    public interface ISubtagsrepo:IRepository<Subtag>
    {
        IEnumerable<Subtag> GetsubtagwithMaintags();
        
    }
}
