using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaListaAtividade.Application.Services.General;
using SistemaListaAtividade.Application.Services.Interfaces;
using SistemaListaAtividade.Persistence.Connections;
using SistemaListaAtividade.Persistence.Repository.General;

namespace SistemaListaAtividade.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sistema de gestão de atividades",
                    Description = "Teste para seleção",
                });
            }
            );
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseNpgsql(config.GetConnectionString("WebApiDatabase"));
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200");
                });
            });

            services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
            services.AddScoped<IRepositoryUoW, RepositoryUoW>();

            return services;
        }
    }
}