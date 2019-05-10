using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using AnswerQuestionWebApp.Models.UsersProfiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;




namespace AnswerQuestionWebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostrepo _iPostrepo;
        private readonly IMainTagRepository _iMainTagRepositoryrepo;
        private readonly ISubtagsrepo _iSubtagrepo;
        private readonly ILikeRepo _likerepo;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signinManager;


        public PostController(IPostrepo iPostrepo,
            IMainTagRepository imaiMainTag,
            ISubtagsrepo iSubtagsrepo,
            ILikeRepo likeRepo, 
            UserManager<ApplicationUsers> userManager,
            SignInManager<ApplicationUsers> signInManager)
        {
            _iPostrepo = iPostrepo;
            _iMainTagRepositoryrepo = imaiMainTag;
            _iSubtagrepo = iSubtagsrepo;
            _likerepo = likeRepo;
            _userManager = userManager;
            _signinManager = signInManager;
        }
        public IActionResult Index()
        {
           var post= _iPostrepo.Getallpost();
           
            return View(post);
        }

        public  IActionResult Createpost()
        {
            ViewBag.TagId = _iMainTagRepositoryrepo.GetAll().Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Createpost(Post post)
        {
            if (ModelState.IsValid)
            {
                _iPostrepo.Create(post);
                return RedirectToAction("Index");
            }
            
            return View(post);
        }




        public IActionResult Comment(int id)
        {
            var post = _iPostrepo.GetById(id);
            return View(post);
        }
        public IActionResult Comment(CommentPost commentPost)
        {
            return View();
        }




        public IActionResult Like(int id)
        {
            if (_signinManager.IsSignedIn(User))
            {
                Likepost likepost = new Likepost();
                likepost.PostId = id;
                likepost.ApplicationUsersId = _userManager.GetUserId(User);
                likepost.LikeCount = 1;
                _likerepo.Create(likepost);

                return ViewComponent("Like");

            }
            else
            {
                return RedirectToPage("Login");
            }

        }



        public JsonResult GetsubtagByMainTagId(int maintagid)
        {
           var subtag=  _iSubtagrepo.Find(s=>s.MainTagId== maintagid).ToList();
            return Json(subtag);
        }
       

    }
}