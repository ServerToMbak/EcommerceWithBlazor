using Server.Model;

namespace Server.Service.Abstract
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Delete(int id);
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll();
    }
}
