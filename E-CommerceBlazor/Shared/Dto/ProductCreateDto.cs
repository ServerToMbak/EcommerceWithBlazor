using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Shared.Dto
{
    public class ProductCreateDto
    {

        [Required(ErrorMessage ="Ürün Adı Boş Geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You should add a Price for the product")]
        public int Price { get; set; }
 
        [Required(ErrorMessage = "You should lect A Description for your product")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "You should Choose the Category your product")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You should add A Picture of your product for your Customer")]
        public string PictureUrl { get; set; }
    }
}
