using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using AnswerQuestionWebApp.Models.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnswerQuestionWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        private ImainTagRepository _imainrepo;

        public TagsController(ImainTagRepository imaintagrepository)
        {
            _imainrepo = imaintagrepository;
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
    }
}