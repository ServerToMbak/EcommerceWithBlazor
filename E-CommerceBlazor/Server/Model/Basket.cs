namespace E_CommerceBlazor.Server.Model
{
    public class Basket
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<BasketItem> Items { get; set; }
        public double TotalPrice { get; set; }
    }
    
}
