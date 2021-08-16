using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplWebService.SimplWebService.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplWebService.Extensions
{
    public static class DatabaseContextExtensions
    {
        public static IServiceCollection AddDbContextExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure(50));
            });

            services.AddDbContext<GamesDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            return services;
        }
    }
}
