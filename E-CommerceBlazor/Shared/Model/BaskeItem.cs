namespace E_CommerceBlazor.Shared.Model
{
    public class BasketItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public int TotalItemPrice { get; set; }
    }
}
