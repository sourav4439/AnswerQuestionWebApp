using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Models.Post
{
    public class Subtag
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Sub Tag")]
        public string Name { get; set; }
        public MainTag MainTag { get; set; }
        [Required]
        [Display(Name = "Main Tag")]
        public int MainTagId { get; set; }


    }
}
