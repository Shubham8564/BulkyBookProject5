using BulkyBookProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookProject.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<BookModel> Books { get; set; }
    }
}
