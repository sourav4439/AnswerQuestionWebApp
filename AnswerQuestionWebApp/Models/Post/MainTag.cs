using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Models.Post
{
    public class MainTag
    {

        public int Id { get; set; }
        [Required]
        [Display(Name="Main Tag")]
        public string Name { get; set; }
        

    }
}
