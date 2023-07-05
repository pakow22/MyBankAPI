using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
              _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<LoanStatus> LoanStatuses { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
    }
}
