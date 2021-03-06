﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnswerQuestionWebApp.Models.Post;

namespace AnswerQuestionWebApp.Data.Interfaces
{
   public interface IPostReportRepo:IRepository<Postreport>
   {
       IEnumerable<Postreport> GetPostreportsReview();
   }
}
