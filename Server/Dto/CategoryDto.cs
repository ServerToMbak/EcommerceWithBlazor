using System.ComponentModel.DataAnnotations;

namespace Server.Dto
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
