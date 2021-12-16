using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers.DTO;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("user/")]
    public class UserController
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        
        
        [HttpGet("{id}")]
        public async Task<User> GetUser(Guid id)
        {
            return await _userService.GetUserByIdAsync(id);
        }
        
        
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public User CreateUser([FromBody] UserDtoIn user)
        {
            return _userService.CreateUser(user.name, user.email);
        }


    }
}