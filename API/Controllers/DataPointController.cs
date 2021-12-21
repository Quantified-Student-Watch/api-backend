using System;
using System.Threading.Tasks;
using API.Controllers.DTO.IN;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("dataPoint/")]
    public class DataPointController
    {
        private readonly IDeviceService _deviceService;
        private IUserService _userService;
        private readonly IDataPointService _dataPointService;
        public DataPointController(IDeviceService deviceService, IUserService userService, IDataPointService dataPointService)
        {
            _deviceService = deviceService;
            _userService = userService;
            _dataPointService = dataPointService;
        }
        
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<DataPoint> CreateDevice([FromBody] NewDataPoint newDataPoint)
        {
            Device device = await _deviceService.GetDevice(Guid.Parse(newDataPoint.DeviceId));
            DataPoint dataPoint = _dataPointService.Create(device, newDataPoint.DataPointType, newDataPoint.Value);
            return dataPoint;
        }

    }
}