using System.ComponentModel.DataAnnotations;

namespace Finance_Core.DTOs;
public class LoginRequestDTO
{
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
}
