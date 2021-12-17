using System;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers.DTO.IN
{
    public class NewDevice
    {
        [Required] [MaxLength(100)] public string name { get; set; }

        [Required] [MaxLength(100)] public string productName { get; set;  }
        
        [Required] [MaxLength(100)] public string userId { get; set;  }
    }
}