using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using KotorsGate.Application.Interfaces;

namespace KotorsGate.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Dev:ConnectionString"]!;

            services.AddDbContext<KotorsGateDbContext>(options => {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IKotorsGateDbContext>(provider  => provider.GetRequiredService<KotorsGateDbContext>());

            return services;
        }
    }
}
