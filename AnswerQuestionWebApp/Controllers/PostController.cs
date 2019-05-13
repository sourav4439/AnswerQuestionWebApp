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
using Microsoft.AspNetCore.Mvc.Rendering;




namespace AnswerQuestionWebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostrepo _iPostrepo;
        private readonly IMainTagRepository _iMainTagRepositoryrepo;
        private readonly ISubtagsrepo _iSubtagrepo;
        private readonly ILikeRepo _likerepo;
        private readonly IPostCommentrepo _comment;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signinManager;
      


        public PostController(IPostrepo iPostrepo,
            IMainTagRepository imaiMainTag,
            ISubtagsrepo iSubtagsrepo,
            ILikeRepo likeRepo, 
            UserManager<ApplicationUsers> userManager,
            SignInManager<ApplicationUsers> signInManager,IPostCommentrepo comment)
        {
            _iPostrepo = iPostrepo;
            _iMainTagRepositoryrepo = imaiMainTag;
            _iSubtagrepo = iSubtagsrepo;
            _likerepo = likeRepo;
            _userManager = userManager;
            _signinManager = signInManager;
            _comment = comment;
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




        public IActionResult SinglePost(int id)
        {
            var post = _iPostrepo.GetPostbyId(id);

            var postviewmodel = new SinglepostViewmodel(){Post =post};
            return View(postviewmodel);
        }
        [HttpPost]
        public IActionResult CommentPost(SinglepostViewmodel pcomment)
        {
            if (pcomment.CommentPost.CommentDescription !=null)
            {
                var comment = new CommentPost()
                {
                    CommentDescription = pcomment.CommentPost.CommentDescription,
                    PostId = pcomment.Post.Id,
                    ApplicationUsersId = _userManager.GetUserId(User)
                };
                _comment.Create(comment);
                return RedirectToAction("SinglePost", new { id = pcomment.Post.Id });
            }

            return RedirectToAction("SinglePost",new {id=pcomment.Post.Id});
        }

        [HttpGet]
        public IActionResult Postreport()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Postreport(Postreport postreport)
        {
            return View();
        }




        public JsonResult Like(int id)
        {
            if (_signinManager.IsSignedIn(User))
            {
                Likepost likepost = new Likepost();
                likepost.PostId = id;
                likepost.ApplicationUsersId = _userManager.GetUserId(User);
                likepost.LikeCount = 1;
                _likerepo.Create(likepost);
                var like = _likerepo.GetAll().AsQueryable();

                var tlike=  like.Count(p => p.PostId == id);
                return Json(tlike);

            }

            return Json(0);

        }



        public JsonResult GetsubtagByMainTagId(int maintagid)
        {
           var subtag=  _iSubtagrepo.Find(s=>s.MainTagId== maintagid).ToList();
            return Json(subtag);
        }
       

    }
}