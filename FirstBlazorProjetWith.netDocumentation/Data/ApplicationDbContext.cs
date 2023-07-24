using FirstBlazorProjetWith.netDocumentation.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorProjetWith.netDocumentation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }     
    }
}
