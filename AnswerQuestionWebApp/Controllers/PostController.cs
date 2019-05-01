using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;




namespace AnswerQuestionWebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostrepo _iPostrepo;
        private readonly IMainTagRepository _iMainTagRepositoryrepo;
        private readonly ISubtagsrepo _iSubtagrepo;

        public PostController(IPostrepo iPostrepo,IMainTagRepository imaiMainTag,ISubtagsrepo iSubtagsrepo)
        {
            _iPostrepo = iPostrepo;
            _iMainTagRepositoryrepo = imaiMainTag;
            _iSubtagrepo = iSubtagsrepo;
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
            ViewBag.SubtagId = _iSubtagrepo.GetAll().Select(a => new SelectListItem
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

    }
}