using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Storage> Storages { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
