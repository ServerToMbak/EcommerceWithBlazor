using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Server.Dto
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
