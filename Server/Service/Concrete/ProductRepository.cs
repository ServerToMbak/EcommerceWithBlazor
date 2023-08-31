using Microsoft.EntityFrameworkCore;
using Server.Controllers;
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
        public async Task<Response> Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(); 
            return new Response
            {
                Message = "Product Added Successfuly ",
                Success = true,
            };
        }

        public async Task<Response> Delete(int id)
        {
            var prooduct = _context.Products.Where(p => p.Id ==id).FirstOrDefault();
            _context.Products.Remove(prooduct);
            await _context.SaveChangesAsync();
            return new Response {Message = "Product Has Deleted",Success = true};
        }
        public async Task<DataResponse<List<Product>>> GetAll()
        {
            var products =  await _context.Products.Include(p=>p.Category).ToListAsync();
            return new DataResponse<List<Product>>
            {
                Data = products,
                Message = "All Products has listed successfuly",
                Success=true,
            };
        }

        public async Task<DataResponse<Product>> GetById(int id)
        {
            var product =await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return new DataResponse<Product>
            {
                Data = product,
                Success = true,
                Message = "Product is getted by id"
            };
        }
    }
}
