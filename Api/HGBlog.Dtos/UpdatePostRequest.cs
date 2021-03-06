using System;
using System.Collections.Generic;
using System.Text;

namespace HGBlog.Dtos
{
    public class UpdatePostRequest
    {
        public int IdPost { get; set; }
        public string TitlePost { get; set; }
        public string TextPost { get; set; }
    }
}
