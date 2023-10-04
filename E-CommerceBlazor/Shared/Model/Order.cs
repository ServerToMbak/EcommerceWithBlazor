using System.ComponentModel.DataAnnotations;

namespace E_CommerceBlazor.Shared.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double SubTotal { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<OrderItem> OrderItems { get; set; }

    }
}
