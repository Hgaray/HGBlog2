using HGBlog.Dtos;
using HGBlog.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HGBlog.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _repository;
        public UserLogic(IUserRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = await _repository.GetUsers();

                return users;

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
                var result = await _repository.GetUser(request);
                return result;

            }
            catch (Exception ex)
            {

                throw;
            }

        }


    }
}
