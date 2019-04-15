using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Models
{
    public class ApplicationUsers:IdentityUser
    {
        public ApplicationUsers():base(){  }

        public string FirstName { get; set; }



    }
}
