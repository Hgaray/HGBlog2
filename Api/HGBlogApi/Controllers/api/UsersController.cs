using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HGBlog.Dtos;
using HGBlog.Logic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HGBlogApi.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        public UsersController(IUserLogic userLogic)
        {

            _userLogic = userLogic;

        }

        


        [HttpPost("GetUser")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser([FromBody] UserRequest request)
        {

            try
            {
                var user = await _userLogic.GetUser(request);
                if (user != null)
                {
                    return Ok(user);
                }

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }           
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var users = await _userLogic.GetUsers();
            return Ok(users);
        }
    }
}
