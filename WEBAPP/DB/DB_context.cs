
using Microsoft.EntityFrameworkCore;
using WEBAPP.Models;
namespace WEBAPP.DB
{
    public class DB_context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MOHAMMAD-ALOMAR\SQLEXPRESS;Initial Catalog=MVC_project;Integrated Security=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}





    

