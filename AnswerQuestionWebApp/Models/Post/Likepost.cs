using AnswerQuestionWebApp.Models.UsersProfiles;
using System.ComponentModel.DataAnnotations;

namespace AnswerQuestionWebApp.Models.Post
{
    public class Likepost
    {
        public int Id { get; set; }
        [Required]
        public byte LikeCount { get; set; }
        public Post Post { get; set; }
        [Required]
        public int PostId { get; set; }
        public ApplicationUsers ApplicationUsers { get; set; }
        [Required]
        public string ApplicationUsersId { get; set; }


    }
}
