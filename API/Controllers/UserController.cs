using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("user/")]
    public class UserController
    {
        public UserController(IUser)
        {
            
        }
        
        
        
        [HttpGet("{id}")]
        public User GetUser(Guid id)
        {
            return OkResult()
        }


    }
}