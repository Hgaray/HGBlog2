using HGBlog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HGBlog.Logic
{
    public interface IUserLogic
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(UserRequest request);
    }
}
