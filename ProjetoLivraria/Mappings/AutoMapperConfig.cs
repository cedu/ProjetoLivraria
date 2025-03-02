using AutoMapper;
using ProjetoLivraria.Entities;
using ProjetoLivraria.Models;

namespace LivrariasApp.API.Mappings
{
    public class AutoMapperConfig:Profile 
    {
        public AutoMapperConfig()
        {
            //Mapeamento Usuario
            CreateMap<UsuariosPostRequestModel, Usuario>();
            CreateMap<UsuariosPutRequestModel, Usuario>();
            CreateMap<Usuario, UsuariosGetResponseModel>();

            //Mapeamento Livros
            //CreateMap<LivrosPostRequestModel, Livro>();
            //CreateMap<LivrosPutRequestModel, Livro>();
            //CreateMap<Livro, LivrosGetResponseModel>();

            //Mapeamento Editora
            CreateMap<EditorasPostRequestModel, Editora>();
            CreateMap<EditorasPutRequestModel, Editora>();
            CreateMap<Editora, EditorasGetResponseModel>();
        }
    }
}
