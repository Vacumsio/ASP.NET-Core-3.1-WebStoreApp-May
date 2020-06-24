using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStoreApp.Domain.Entities;
using WebStoreApp.Domain.Entities.Employees;
using WebStoreApp.Domain.Entities.Identity;
using WebStoreApp.Domain.Entities.Orders;

namespace WebStoreApp.DAL.Context
{
    public class WebStoreDB: IdentityDbContext<User, Role, string>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public WebStoreDB(DbContextOptions<WebStoreDB> Options): base(Options) { }
    }
}
