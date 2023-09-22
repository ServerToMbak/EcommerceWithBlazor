namespace E_CommerceBlazor.Server.Model
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int OrderItemId { get; set; }
    }
}
