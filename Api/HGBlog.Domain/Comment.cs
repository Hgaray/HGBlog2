using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HGBlog.Domain
{
    [Table("tbComments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public int PostId { get; set; }
    }
}
