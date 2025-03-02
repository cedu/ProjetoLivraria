using Microsoft.OpenApi.Models;

namespace LivrariasApp.API.Extensions
{
    /// <summary>
    /// Classe de extensão para configuração do Swagger
    /// </summary>
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LivrariaApp - API para controle de livros",
                    Description = "Desafio CCAA",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "CCAA",
                        Email = "contato@grupoccaa.com.br",
                        Url = new Uri("https://www.ccaa.com.br")
                    }
                });
            });

            return services;
        }
    }
}
