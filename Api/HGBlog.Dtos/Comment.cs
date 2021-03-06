using System;
using System.Collections.Generic;
using System.Text;

namespace HGBlog.Dtos
{
    public class Comment
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public int PostId { get; set; }
    }
}
