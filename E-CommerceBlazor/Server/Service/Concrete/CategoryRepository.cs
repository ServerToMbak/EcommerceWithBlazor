using E_CommerceBlazor.Server.Data;
using E_CommerceBlazor.Server.Model;
using E_CommerceBlazor.Server.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBlazor.Server.Service.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return new Response
            { Success = true, Message = "Category Added" };
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

        public async Task<DataResponse<Category>> GetById(int categoryId)
        {
            var category = await _context.Categories.Include(opt => opt.Products).Where(opt => opt.Id == categoryId).FirstOrDefaultAsync();
            return new DataResponse<Category> { Data = category, Message = "Category Getted", Success = true };
        }
    }
}
