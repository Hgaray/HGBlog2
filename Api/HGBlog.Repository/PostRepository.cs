using HGBlog.DataAccess;
using HGBlog.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGBlog.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly HGBlogDbContext _context;
        public PostRepository(HGBlogDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Post>> GetAllPosts()
        {

            try
            {
                var state = _context.States.Where(x => x.Name == "Approved").FirstOrDefault();

                var result = await _context.Posts.Where(x => x.State == state)
                    .Include(x => x.State)
                    .Include(a => a.User).Select(p =>
                    new Post
                    {
                        Id = p.Id,
                        TitlePost = p.TitlePost,
                        PostText = p.PostText,
                        CreationDate = p.CreationDate,
                        State = new State
                        {
                            Id = p.State.Id,
                            Name = p.State.Name
                        },
                        User = new User
                        {
                            Id = p.User.Id,
                            Name = p.User.Name,
                            LastName = p.User.LastName
                        },
                        Comments = _context.Comments.Where(a => a.PostId == p.Id).Select(g => new Comment
                        {
                            Id = g.Id,
                            Detail = g.Detail,
                            PostId = g.PostId
                        }).ToList()

                    }).AsNoTracking().ToListAsync();

                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<Post> CreatePost(Post post)
        {
            try
            {
                var stateNewPost = _context.States.Where(x => x.Id == post.State.Id).FirstOrDefault();
                var userNewPost = _context.Users.Where(x => x.Id == post.User.Id).FirstOrDefault();

                var newPost = new Domain.Post()
                {
                    CreationDate = DateTime.Now,
                    TitlePost = post.TitlePost,
                    PostText = post.PostText,
                    State = stateNewPost,
                    User = userNewPost
                };

                _context.Posts.Add(newPost);

                await _context.SaveChangesAsync();

                post.Id = newPost.Id;

                return post;


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

                var postToUpdate = _context.Posts.Where(x => x.Id == post.IdPost).FirstOrDefault();
                var statePostToUpdate = _context.States.Where(x => x.Id == 1).FirstOrDefault();


                postToUpdate.TitlePost = post.TitlePost;
                postToUpdate.PostText = post.TextPost;
                postToUpdate.State = statePostToUpdate;
                postToUpdate.CreationDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return true;


            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<bool> DeletePost(int idPost)
        {

            try
            {
                var postToDelete = _context.Posts.Where(x => x.Id == idPost).FirstOrDefault();

                if (postToDelete != null)
                {
                    _context.Remove(postToDelete);
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;



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
                var statePost = _context.States.Where(x => x.Id == parameters.idState).FirstOrDefault();
                var postToUpdate = _context.Posts.Where(x => x.Id == parameters.idPost).FirstOrDefault();


                postToUpdate.State = statePost;

                await _context.SaveChangesAsync();

                return true;


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
                var stateToFind = _context.States.Where(x => x.Id == state).FirstOrDefault();

                var result = await _context.Posts.Where(x => x.State == stateToFind)
                    .Include(x => x.State)
                    .Include(a => a.User).Select(p =>
                    new Post
                    {
                        Id = p.Id,
                        TitlePost = p.TitlePost,
                        PostText = p.PostText,
                        CreationDate = p.CreationDate,
                        State = new State
                        {
                            Id = p.State.Id,
                            Name = p.State.Name
                        },
                        User = new User
                        {
                            Id = p.User.Id,
                            Name = p.User.Name,
                            LastName = p.User.LastName
                        },
                        Comments = _context.Comments.Where(a => a.PostId == p.Id).Select(g => new Comment
                        {
                            Id = g.Id,
                            Detail = g.Detail,
                            PostId = g.PostId
                        }).AsNoTracking().ToList()

                    }).AsNoTracking().ToListAsync();

                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async Task<bool> SaveComment(Comment comment)
        {


            try
            {
                var newComment = new Domain.Comment()
                {
                    Detail = comment.Detail,
                    PostId = comment.PostId
                };

                 _context.Comments.Add(newComment);

                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
