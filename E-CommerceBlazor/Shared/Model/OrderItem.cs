using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Shared.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
