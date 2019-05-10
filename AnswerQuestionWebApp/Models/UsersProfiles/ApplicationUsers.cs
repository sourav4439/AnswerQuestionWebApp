
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Models.UsersProfiles
{
    public class ApplicationUsers:IdentityUser
    {
        public ApplicationUsers():base(){  }
        [Required]
        public string Photo { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }    

        public Gender Gender { get; set; }
        [Required]
        [Display(Name ="Gender")]
        public int GenderId { get; set; }

        public Country Country { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public Langues Langues { get; set; }
        [Required]
        [Display(Name = "Langues")]
        public int LanguesId { get; set; }





    }
}
