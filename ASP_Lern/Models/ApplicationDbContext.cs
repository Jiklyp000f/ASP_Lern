using Microsoft.EntityFrameworkCore;

namespace ASP_Lern.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<ApplicationUser> Users { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base( options )
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        // Настройка дополнительных правил (если нужно)
        modelBuilder.Entity<ApplicationUser>( entity =>
        {
            entity.Property( e => e.Email ).IsRequired().HasMaxLength( 100 );
            entity.Property( e => e.Username ).IsRequired().HasMaxLength( 50 );
        } );
    }
}
