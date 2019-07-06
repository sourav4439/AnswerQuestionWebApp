using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Models.UsersProfiles;

namespace AnswerQuestionWebApp.Models.ViewModels
{
    public class AllUserViewModel
    {
        public string Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        public Country Country { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Langues Langues { get; set; }
        [Display(Name = "Langues")]
        public int LanguesId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
