using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace HGBlog.Domain
{
    [Table("tbUsers")]
    public class User
    {
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
    }
}
