
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_CommerceBlazor.Shared.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; } 
        public double Price { get; set; }
        public int Quantity{ get; set; }
        public double ProductItemPrice { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
    }
}
