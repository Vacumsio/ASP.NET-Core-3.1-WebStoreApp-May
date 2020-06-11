using Microsoft.EntityFrameworkCore;
using WebStoreApp.Domain.Entities;

namespace WebStoreApp.DAL.Context
{
    public class WebStoreDB: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public WebStoreDB(DbContextOptions<WebStoreDB> Options): base(Options) { }
    }
}
