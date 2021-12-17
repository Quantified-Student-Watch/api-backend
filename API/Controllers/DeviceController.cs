using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers.DTO;
using API.Controllers.DTO.IN;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("device/")]
    public class DeviceController
    {
        private IDeviceService _deviceService;
        private IUserService _userService;
        public DeviceController(IDeviceService deviceService, IUserService userService)
        {
            _deviceService = deviceService;
            _userService = userService;
        }
        
        
        
        [HttpGet("{id}")]
        public async Task<Device> GetDevice(Guid id)
        {
            return await _deviceService.GetDevice(id);
        }
        
        
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Device> CreateDevice([FromBody] NewDevice newDevice)
        {
            User user = await _userService.GetUserByIdAsync(Guid.Parse(newDevice.userId));
            return _deviceService.CreateDevice(user, newDevice.name, newDevice.productName);
        }


    }
}