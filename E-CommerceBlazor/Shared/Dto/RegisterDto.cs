using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Shared.Dto
{
    public class RegisterDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Geçersiz Email adresi")]
        public string Email { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }
        [StringLength(15, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
       
    }
}
