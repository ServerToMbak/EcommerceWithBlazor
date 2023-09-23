using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_CommerceBlazor.Server.Model
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
