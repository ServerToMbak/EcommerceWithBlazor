using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Server.Dto
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
