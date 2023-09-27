using AutoMapper;
using E_CommerceBlazor.Server.Data;
using E_CommerceBlazor.Shared.Model;
using E_CommerceBlazor.Server.Repository.Abstract;
using E_CommerceBlazor.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBlazor.Server.Repository.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response> Add(CategoryCreateDTO categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return new Response
            { Success = true, Message = "Category Added"};
        }

        public async Task<Response> Delete(int categoryId)
        {
            var category = await _context.Categories
                .Where(opt => opt.Id == categoryId).FirstOrDefaultAsync();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return new Response { Message="Category Deleted", Success=true };
        }

        public async Task<DataResponse<List<Category>>> GetAll()
        {
            var categories =await _context.Categories.Include(opt => opt.Products).ToListAsync();
            return new DataResponse<List<Category>> { Data = categories, Message = "Category Listed", Success = true };
        }

        public async Task<DataResponse<CategoryDto>> GetById(int categoryId)
        {
            var category = await _context.Categories.Include(opt => opt.Products).Where(opt => opt.Id == categoryId).FirstOrDefaultAsync();
            var data = _mapper.Map<CategoryDto>(category);
            return new DataResponse<CategoryDto> 
            { 
                Data = data, 
                Message = "Category Getted", 
                Success = true 
            };
        }
    }
}
