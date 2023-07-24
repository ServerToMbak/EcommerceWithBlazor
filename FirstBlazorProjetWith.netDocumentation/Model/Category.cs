using System.ComponentModel.DataAnnotations;

namespace FirstBlazorProjetWith.netDocumentation.Model
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
