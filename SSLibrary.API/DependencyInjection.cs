using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSLibrary.API.Entities;

namespace SSLibrary.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql(connectionString));
        services.AddScoped<IApplicationDbContext>(provider => provider
            .GetService<ApplicationDbContext>());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}