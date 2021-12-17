using System.ComponentModel.DataAnnotations;

namespace API.Controllers.DTO.IN
{
    public class NewUser
    {
        [Required] [MaxLength(100)] public string name { get; set; }

        [Required] [MaxLength(100)] public string email { get; set;  }
    }
}