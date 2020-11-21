namespace CashOrder.Data
{

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CoDbContext : IdentityDbContext
    {
        public CoDbContext(DbContextOptions<CoDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntityModel> CashUsers { get; set; }

        public DbSet<FirmEntityModel> Firms { get; set; }
    }
}
