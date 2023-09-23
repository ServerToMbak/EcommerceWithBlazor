using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Shared.Dto
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        public List<ProductReadDTO> Products { get; set; }
    }
}
