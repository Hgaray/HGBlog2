using HGBlog.Dtos;
using HGBlog.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HGBlog.Logic
{
    public class PostLogic : IPostLogic
    {
        private readonly IPostRepository _repository;
        public PostLogic(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            try
            {
                return await _repository.GetAllPosts();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Post> CreatePost(Post post)
        {
            try
            {
                return await _repository.CreatePost(post);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeletePost(int idPost)
        {
            try
            {
                return await _repository.DeletePost(idPost);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<bool> UpdatePost(UpdatePostRequest post)
        {
            try
            {
                return await _repository.UpdatePost(post);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> UpdateStatePost(UpdateStatePostRequest parameters)
        {
            try
            {
                return await _repository.UpdateStatePost(parameters);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IEnumerable<Post>> GetPostsByState(int state)
        {
            try
            {
                return await _repository.GetPostsByState(state);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> SaveComment(Comment comment)
        {
            try
            {
                return await _repository.SaveComment(comment);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
