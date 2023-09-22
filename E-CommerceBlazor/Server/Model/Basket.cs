namespace E_CommerceBlazor.Server.Model
{
    public class Basket
    {
        public int Id { get; set; }
        public List<BasketItem> Items { get; set; }
        public double TotalPrice { get; set; }
    }
    
}
