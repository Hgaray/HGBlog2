using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HGBlog.Domain
{
    [Table("stbStates")]
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
