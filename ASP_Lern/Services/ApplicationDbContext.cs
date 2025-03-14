using ASP_Lern.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Lern.Services;

public class ApplicationDbContext : DbContext
{
    public DbSet<ApplicationUser> Users { get; set; }

    public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base( options )
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        // Настройка таблицы Users
        modelBuilder.Entity<ApplicationUser>( entity =>
        {
            entity.ToTable( "Users", "dbo" ); // Явно указываем имя таблицы

            entity.HasKey( e => e.Id ); // Первичный ключ

            entity.Property( e => e.Username )
                .IsRequired()
                .HasMaxLength( 50 );

            entity.Property( e => e.Email )
                .IsRequired()
                .HasMaxLength( 100 );

            entity.Property( e => e.PasswordHash )
                .IsRequired();

            entity.Property( e => e.IsActive )
                .HasDefaultValue( true );

            entity.Property( e => e.CreatedAt )
                .HasDefaultValueSql( "GETUTCDATE()" );

            entity.HasIndex( e => e.Username ).IsUnique();
            entity.HasIndex( e => e.Email ).IsUnique();
        } );
    }
}