namespace E_CommerceBlazor.Shared.Model
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public int TotalItemPrice { get; set; }
    }
}
