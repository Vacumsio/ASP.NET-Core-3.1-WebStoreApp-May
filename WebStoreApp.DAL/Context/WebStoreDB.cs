using Microsoft.EntityFrameworkCore;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Domain.Entities.Employees;

namespace WebStoreApp.DAL.Context
{
    public class WebStoreDB: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public WebStoreDB(DbContextOptions<WebStoreDB> Options): base(Options) { }
    }
}
