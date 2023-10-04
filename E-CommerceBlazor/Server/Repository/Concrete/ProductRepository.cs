using Microsoft.EntityFrameworkCore;
using E_CommerceBlazor.Server.Data;
using E_CommerceBlazor.Shared.Model;
using E_CommerceBlazor.Shared.Dto;
using AutoMapper;
using E_CommerceBlazor.Server.Repository.Abstract;

namespace E_CommerceBlazor.Server.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<DataResponse<List<ProductReadDTO>>> GetAll()
        {
            var products =  await _context.Products.Include(p=>p.Category).ToListAsync();
            var data = _mapper.Map<List<ProductReadDTO>>(products);
            return new DataResponse<List<ProductReadDTO>>
            {
                Data = data,
                Message = "All Products has listed successfuly",
                Success=true,
            };
        }

        public async Task<DataResponse<ProductReadDTO>> GetById(int id)
        {
            var product =await _context.Products.Where(p => p.Id == id).Include(opt => opt.Category).FirstOrDefaultAsync();

            var data = _mapper.Map<ProductReadDTO>(product);
            
            return new DataResponse<ProductReadDTO>
            {
                Data = data,
                Success = true,
                Message = "ProductReadDTO is getted by id"
            };
        }
    }
}
