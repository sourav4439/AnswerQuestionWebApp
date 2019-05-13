using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnswerQuestionWebApp.ViewComponents
{
    public class CommentViewComponent:ViewComponent
    {
        private readonly IPostCommentrepo _comment;


        public CommentViewComponent(IPostCommentrepo comment)
        {
            _comment = comment;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var comment = _comment.GetAll().AsQueryable();

            var allcom =await comment.Where(c => c.PostId == id).Include(u => u.ApplicationUsers).ToListAsync();

            return View(allcom);
        }
    }
}
