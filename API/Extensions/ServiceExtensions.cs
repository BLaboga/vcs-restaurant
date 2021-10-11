using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistance;
using Application.Core;
using Application.DailyDishes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
              
            });
             services.AddDbContext<DataContext>(opt =>
                {
                    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
                });
            services.AddCors(opt =>
                {
                    opt.AddPolicy("CorsPolicy",policy =>
                    {
                        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                    });
                });
            services.AddMediatR(typeof(DishesList.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            
            return services;
        }
    }
}