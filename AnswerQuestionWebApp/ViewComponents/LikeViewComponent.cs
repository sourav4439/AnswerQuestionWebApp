using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnswerQuestionWebApp.ViewComponents
{
    public class LikeViewComponent:ViewComponent
    {
        private readonly ILikeRepo _iLikeRepo;


        public LikeViewComponent(ILikeRepo iLikeRepo)
        {
            _iLikeRepo = iLikeRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var like = _iLikeRepo.GetAll().AsQueryable();

            ViewBag.totallike = await like.Where(p => p.PostId == id).CountAsync();
            
            return View();
        }
    }
}
