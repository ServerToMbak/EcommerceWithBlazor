using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Server.Dto
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
