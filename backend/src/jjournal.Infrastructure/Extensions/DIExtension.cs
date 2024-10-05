using jjournal.Domain.Interfaces.Repositories;
using jjournal.Domain.Models.Entities;
using jjournal.Infrastructure.Data;
using jjournal.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jjournal.Infrastructure.Extensions;

public static class DIExtension
{
    public static void AddInfra(this IServiceCollection services, IConfiguration config)
    {
        services.AddRepositories();

        if (config.GetValue<bool>("InMemoryTest"))
            return;

        services.AddDatabase(config);
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("Default"));
        });
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
    }
}