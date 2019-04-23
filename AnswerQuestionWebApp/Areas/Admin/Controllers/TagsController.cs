using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnswerQuestionWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        private readonly IMainTagRepository _imainrepo;
        private readonly ISubtagsrepo _isubtagsrepo;

        public TagsController(IMainTagRepository imainrepo,ISubtagsrepo isubtagsrepo)
        {
            this._imainrepo = imainrepo;
            this._isubtagsrepo = isubtagsrepo;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MainTagList()
        {
            var list = _imainrepo.GetAll();
            return View(list);
        }

        public IActionResult Createmaintag()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Createmaintag(MainTag mainTag)
        {

            if (ModelState.IsValid)
            {

                _imainrepo.Create(mainTag);

                return RedirectToAction("MainTagList");
            }
            else
                return View(mainTag);
        }
        public IActionResult Editmaintag(int id)
        {
            var maintag = _imainrepo.GetById(id);
            return View(maintag);
        }
        [HttpPost]
        public IActionResult Editmaintag(MainTag mainTag)
        {
            if (ModelState.IsValid)
            {
                _imainrepo.Update(mainTag);
                return RedirectToAction("MainTagList");
            }

            return View(mainTag);
        }
        public IActionResult Deletemaintag(int id)
        {
            var maintag = _imainrepo.GetById(id);
            return View(maintag);

        }
        [HttpPost]
        public IActionResult Deletemaintag(MainTag main)
        {
            _imainrepo.Delete(main);
            return RedirectToAction("MainTagList");

        }



        //Down Action for sub Tags



        [HttpGet]
        public IActionResult SubTagList()
        {
            var list = _isubtagsrepo.GetsubtagwithMaintags();
            return View(list);
        }

        public IActionResult CreateSubTag()
        {
            ViewBag.MainTagId = _imainrepo.GetAll().Select(a => new SelectListItem {
                                                    Value = a.Id.ToString(),
                                                    Text = a.Name }).ToList();
         

            return View();
        }
        [HttpPost]
        public IActionResult CreateSubTag(Subtag subtag)
        {

            if (ModelState.IsValid)
            {

                _isubtagsrepo.Create(subtag);

                return RedirectToAction("SubTagList");
            }
            else
                return View(subtag);
        }
        public IActionResult EditSubTag(int id)
        {
            var subtag = _isubtagsrepo.GetById(id);
            ViewBag.MainTagId = _imainrepo.GetAll().Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            return View(subtag);
        }
        [HttpPost]
        public IActionResult EditSubTag(Subtag subtag)
        {
            if (ModelState.IsValid)
            {
                _isubtagsrepo.Update(subtag);
                return RedirectToAction("SubTagList");
            }

            return View(subtag);
        }
        public IActionResult DeleteSubTag(int id)
        {
            var subtag = _isubtagsrepo.GetById(id);
            return View(subtag);

        }
        [HttpPost]
        public IActionResult DeleteSubTag(Subtag subtag)
        {
            _isubtagsrepo.Delete(subtag);
            return RedirectToAction("SubTagList");

        }
















    }
}