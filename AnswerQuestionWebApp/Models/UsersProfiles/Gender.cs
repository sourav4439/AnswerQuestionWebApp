using AnswerQuestionWebApp.Models.UsersProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public IEnumerable<ApplicationUsers> applicationUsers { get; set; }
    }
}
