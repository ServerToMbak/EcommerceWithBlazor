using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Shared.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int UserId { get; set; }
        public int SubTotal { get; set; }
        public User User { get; set; }
    }
}
