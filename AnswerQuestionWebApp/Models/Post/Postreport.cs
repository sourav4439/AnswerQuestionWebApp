using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Models.UsersProfiles;

namespace AnswerQuestionWebApp.Models.Post
{
    public class Postreport
    {
        public int? Id { get; set; }
        [Required]
        public string Report { get; set; }

        public Post Post { get; set; }

        [Required]
        public int PostId { get; set; }


        public ApplicationUsers ApplicationUsers { get; set; }

        [Required]
        public string ApplicationUsersId { get; set; }
    }
}
