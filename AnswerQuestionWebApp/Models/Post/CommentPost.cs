using AnswerQuestionWebApp.Models.UsersProfiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Models.Post
{
    public class CommentPost
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Comment Should Be In 100 Character",MinimumLength =1)]
        public string CommentDescription { get; set; }
        public Post Post { get; set; }
        [Required]
        public int PostId { get; set; }
        public ApplicationUsers ApplicationUsers { get; set; }
        [Required]
        public string ApplicationUsersId { get; set; }
    }
}
