using jjournal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jjournal.Infrastructure.Extensions;

public static class DIExtension
{
    public static void AddInfra(this IServiceCollection services, IConfiguration config)
    {
        AddDatabase(services, config);
    }

    private static void AddDatabase(IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("Default"));
        });
    }
}