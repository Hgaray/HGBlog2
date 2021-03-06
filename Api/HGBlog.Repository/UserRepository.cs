using HGBlog.DataAccess;
using HGBlog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HGBlog.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HGBlogDbContext _context;
        public UserRepository(HGBlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = await _context.Users.Select(x => new User()
                {
                    Id = x.Id,
                    UserGuid = x.UserGuid,
                    Name = x.Name,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Password = x.Password,
                    RolId = x.RolId
                }).ToListAsync();

                return await Task.FromResult(users);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<User> GetUser(UserRequest request)
        {
            try
            {

                if (_context.Users.Where(x => x.UserName == request.userName && x.Password == request.password).Count() > 0)
                {
                    var user =  await _context.Users.Where(x => x.UserName == request.userName && x.Password == x.Password).Select(x => new User()
                    {
                        Id = x.Id,
                        UserGuid = x.UserGuid,
                        Name = x.Name,
                        LastName = x.LastName,
                        UserName = x.UserName,
                        Password = x.Password,
                        RolId = x.RolId
                    }).FirstOrDefaultAsync();

                    return await Task.FromResult( user);
                }

                return null;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
