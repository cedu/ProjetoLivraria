using LivrariasApp.Domain.Interfaces.Repositories;
using LivrariasApp.Domain.Interfaces.Services;
using LivrariasApp.Domain.Services;
using LivrariasApp.Infra.Data.Repositories;

namespace LivrariasApp.API.Extensions
{
    // <summary>
    /// Classe de extensão para configurar as injeções de dependência do projeto
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //injeção de dependência de usuários
            services.AddScoped<IUsuarioDomainService, UsuarioDomainService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //injeção de dependência de livros



            //injeção de dependência de editora
            services.AddScoped<IEditoraDomainService, EditoraDomainService>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();

            //injeção de dependência de gênero
            services.AddScoped<IGeneroDomainService, GeneroDomainService>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();


            return services;
        }
    }
}
