using HGBlog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HGBlog.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();

        Task<Post> CreatePost(Post post);

        Task<bool> DeletePost(int idPost);

        Task<Post> UpdatePost(Post post);

        Task<bool> UpdateStatePost(UpdateStatePostRequest parameters);

        Task<IEnumerable<Post>> GetPendingPosts();

        Task<bool> SaveComment(Comment comment);
    }
}
