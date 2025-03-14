using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ASP_Lern.Services;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext( string[] args )
    {
        // Загрузите строку подключения из appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath( Directory.GetCurrentDirectory() )
            .AddJsonFile( "appsettings.json" )
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer( configuration.GetConnectionString( "DefaultConnection" ) );

        return new ApplicationDbContext( optionsBuilder.Options );
    }
}
