using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using AnswerQuestionWebApp.Models.UsersProfiles;
using AnswerQuestionWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnswerQuestionWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUsers> _usermaneger;
        private readonly IPostrepo _postrepo;
        private readonly IPostReportRepo _postreport;

        public AdminController(UserManager<ApplicationUsers> userManager,IPostrepo postrepo,IPostReportRepo postReport)
        {
            _usermaneger = userManager;
            _postrepo = postrepo;
            _postreport = postReport;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AllUsers()
        {
            var alluser = _usermaneger.Users
                .Include(c => c.Country)
                .Include(g => g.Gender)
                .Include(l => l.Langues).ToList();
           List<AllUserViewModel> usersList = new List<AllUserViewModel> { };

           foreach (var user in alluser)
           {
               AllUserViewModel us = new AllUserViewModel
               {
                   Id = user.Id,
                   PhoneNumber = user.PhoneNumber,
                   Photo = user.Photo,
                   Name = user.Name,
                   Email = user.Email,
                   UserName = user.UserName,
                   Country = user.Country,
                   CountryId = user.CountryId,
                   Gender = user.Gender,
                   GenderId = user.CountryId,
                   Langues = user.Langues,
                   LanguesId = user.LanguesId,
                   

               };
               usersList.Add(us);
           }

            return View(usersList);
        }

        public IActionResult AllpostReview()
        {
           var posts= _postrepo.Getallpost();
            return View(posts);
        }
        public IActionResult AllpostReportReview()
        {
            var postsReport = _postreport.GetPostreportsReview();
            return View(postsReport);
        }


    }
}