using AnswerQuestionWebApp.Models.Post;
using AnswerQuestionWebApp.Models.UsersProfiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace AnswerQuestionWebApp.Models.Post
{
    public class Post
    {     
        
        public int Id { get; set; }
        [Required]
        [StringLength(200 ,ErrorMessage = "Please Write 200 Character Bellow")]
        public string Title { get; set; }
        
        public string Description { get; set; }
        [Required]
        public DateTime PostDt { get; set; }
        

        public MainTag Tag { get; set; }
        [Required]
        [Display(Name ="Tags")]
        public int TagId { get; set; }

        public Subtag Subtag { get; set; }
        [Required]
        [Display(Name = "Subtag")]
        public int SubtagId { get; set; }

        public virtual ApplicationUsers ApplicationUsers { get; set; }
        [Required]
        [Display(Name = "Post By")]
        public string ApplicationUsersId { get; set; }

        


    }
    
    

}

