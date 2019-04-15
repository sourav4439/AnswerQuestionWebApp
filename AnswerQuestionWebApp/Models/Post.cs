using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerQuestionWebApp.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PostDT { get; set; }
        //public  MyProperty { get; set; }


        public PostTag Tag { get; set; }

        public int TagId { get; set; }

    }
    public  class PostTag
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

