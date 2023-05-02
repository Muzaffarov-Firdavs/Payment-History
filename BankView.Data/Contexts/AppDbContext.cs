using BankView.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankView.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DailyCost> DailyCosts { get; set; }
        public DbSet<MonthlyCost> MonthlyCosts { get; set; }
        public DbSet<YearlyCost> YearlyCost { get; set; }
    }
}
