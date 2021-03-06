using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HGBlog.Domain
{
    [Table("tbPosts")]
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string TitlePost { get; set; }
        public string PostText { get; set; }
        public virtual User User { get; set; }
        public virtual State State { get; set; }
    }
}
