using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Model;
using Server.Service.Abstract;

namespace Server.Service.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var prooduct = _context.Products.Where(p => p.Id ==id).FirstOrDefault();
            _context.Products.Remove(prooduct);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var response =await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return response;
        }
    }
}
