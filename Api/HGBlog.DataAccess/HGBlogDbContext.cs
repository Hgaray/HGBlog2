using HGBlog.Domain;
using Microsoft.EntityFrameworkCore;

namespace HGBlog.DataAccess
{
    public class HGBlogDbContext : DbContext
    {
        public HGBlogDbContext(DbContextOptions<HGBlogDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        

    }
}
