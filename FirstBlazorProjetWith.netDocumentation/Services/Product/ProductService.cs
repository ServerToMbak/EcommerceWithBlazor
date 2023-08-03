namespace FirstBlazorProjetWith.netDocumentation.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
    }
}
