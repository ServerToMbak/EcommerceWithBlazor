using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Shared.Dto
{
    public class ProductReadDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="You should add A Name for your product")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You should add A Price for your product")]
        public int Price { get; set; }
        [Required(ErrorMessage = "You should Choose the Category your product")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "You should lect A Description for your product")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You should add A Picture of your product for your Customer")]
        public string PictureUrl { get; set; }
    }
}
