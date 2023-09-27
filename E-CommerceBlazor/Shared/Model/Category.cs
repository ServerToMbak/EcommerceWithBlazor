using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Shared.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}
