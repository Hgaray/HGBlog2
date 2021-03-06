using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HGBlog.Dtos;
using HGBlog.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HGBlogApi.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostLogic _postLogic;
        public PostsController(IPostLogic postLogic)
        {
            _postLogic = postLogic;
        }

        [HttpGet("GetAllPosts")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllPosts()
        {

            try
            {
                var result = await _postLogic.GetAllPosts();

                if (result.Any())
                {
                    return Ok(result);

                }

                return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("CreatePost")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreatePost([FromBody] Post post)
        {

            try
            {

                var result = await _postLogic.CreatePost(post);

                if (result != null)
                {
                    return Ok(result);

                }

                return BadRequest();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        


        [HttpPost("ApproveReject")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateStatePost([FromBody] UpdateStatePostRequest parameters)
        {


            try
            {

                var result = await _postLogic.UpdateStatePost(parameters);

                if (result)
                {

                    return Ok(result);
                }

                return BadRequest();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetPendingPosts")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetPendingPosts()
        {

            try
            {
                var result = await _postLogic.GetPendingPosts();

                if (result.Any())
                {
                    return Ok(result);

                }

                return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost("SaveComment")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> SaveComment([FromBody] Comment parameters)
        {


            try
            {
                var result = await _postLogic.SaveComment(parameters);

                if (result)
                {
                    return Ok(result);
                }

                return BadRequest();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("DeletePost")]
        public async Task<ActionResult> DeletePost(int idPost)
        {
            var result = await _postLogic.DeletePost(idPost);
            return Ok(result);
        }

        [HttpPost("UpdatePost")]
        public async Task<ActionResult> UpdatePost(Post post)
        {

            try
            {
                var result = await _postLogic.UpdatePost(post);
                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
