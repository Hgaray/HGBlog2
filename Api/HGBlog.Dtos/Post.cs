using System;
using System.Collections.Generic;
using System.Text;

namespace HGBlog.Dtos
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
         public string TitlePost { get; set; }
        public string PostText { get; set; }
        public  User User { get; set; }
        public  State State { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
