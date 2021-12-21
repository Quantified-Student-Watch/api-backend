using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.Controllers.DTO.IN
{
    public class NewDataPoint
    {
        [Required] public string DeviceId { get; set; }

        [Required] public DataPointType DataPointType { get; set;  }
        [Required] public string Value { get; set;  }
    }
}