using Microsoft.EntityFrameworkCore;
using ShapeAccountManagementSystem.Core.Entities;

namespace ShapeAccountManagementSystem.Infrastracture.Context
{
    public class ShapeDbContext : DbContext
    {
        public ShapeDbContext() : base()
        {

        }
        public ShapeDbContext(DbContextOptions<ShapeDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
