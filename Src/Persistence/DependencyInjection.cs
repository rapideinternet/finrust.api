using FinRust.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinRust.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinRustDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FinRustDatabase")));

            services.AddScoped<IFinRustDbContext>(provider => provider.GetService<FinRustDbContext>());

            return services;
        }
    }
}
