using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data;
using AnswerQuestionWebApp.Models.UsersProfiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnswerQuestionWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUsers> _usermanerger;
        private readonly ApplicationDbContext _db;

        public UserController(UserManager<ApplicationUsers> userManager,ApplicationDbContext db)
        {
            _usermanerger = userManager;
            _db = db;
        }
        public IActionResult Profile()
        {
            var userId = _usermanerger.GetUserId(User);
            if (userId==null)
            {
                return Redirect("~/Identity/Account/Login");
            }
            else
            {
                var userinfo = _db.Users
                    .Include(g => g.Gender)
                    .Include(c => c.Country)
                    .Include(l => l.Langues)
                    .SingleOrDefault(u => u.Id == userId);
                return View(userinfo);
            }
           
        }
    }
}