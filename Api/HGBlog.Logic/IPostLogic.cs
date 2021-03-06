using HGBlog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HGBlog.Logic
{
    public interface IPostLogic
    {
        Task<IEnumerable<Post>> GetAllPosts();

        Task<Post> CreatePost(Post post);

        Task<bool> DeletePost(int idPost);

        Task<bool> UpdatePost(UpdatePostRequest post);

        Task<bool> UpdateStatePost(UpdateStatePostRequest parameters);

        Task<IEnumerable<Post>> GetPostsByState(int state);

        Task<bool> SaveComment(Comment comment);
    }
}
