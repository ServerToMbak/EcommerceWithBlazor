namespace E_CommerceBlazor.Shared.Model
{
    public class Basket
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<BasketItem> Items { get; set; }
        public double TotalPrice { get; set; }

        public Basket(List<BasketItem> items)
        {
            Items = items;
        }
        public Basket()
        {

        }
    }
    
    
}
