using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Models
{
    public class Langues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ApplicationUsers> applicationUsers { get; set; }
    }
}
