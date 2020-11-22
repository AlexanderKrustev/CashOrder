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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FirmEntityModel>()
                .HasMany<DocumentEntityModel>(c => c.DocumenCollection)
                .WithOne(c => c.Firm);

            base.OnModelCreating(builder);

        }


        public DbSet<UserEntityModel> CashUsers { get; set; }

        public DbSet<FirmEntityModel> Firms { get; set; }
        public DbSet<DocumentEntityModel> Documents { get; set; }

    }
}
