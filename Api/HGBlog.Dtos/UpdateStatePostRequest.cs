using System;
using System.Collections.Generic;
using System.Text;

namespace HGBlog.Dtos
{
    public class UpdateStatePostRequest
    {
        public int idPost { get; set; }
        public int idState { get; set; }
    }
}
