using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace AnswerQuestionWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}