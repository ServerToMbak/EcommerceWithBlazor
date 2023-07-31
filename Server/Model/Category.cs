using System.ComponentModel.DataAnnotations;

namespace Server.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Product> products { get; set; }

    }
}
