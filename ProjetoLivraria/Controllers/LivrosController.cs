using AutoMapper;
using LivrariasApp.Domain.Exceptions;
using LivrariasApp.Domain.Interfaces.Repositories;
using LivrariasApp.Domain.Interfaces.Services;
using LivrariasApp.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Entities;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {

        private readonly ILivroDomainService _livroDomainService;
        private readonly IMapper _mapper;
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IEditoraDomainService _editoraDomainService;
        private readonly IGeneroDomainService _generoDomainService;
        private readonly ILivroRepository _livroRepository;

        //construtor para injeção de dependências das interfaces
        public LivrosController(ILivroDomainService livroDomainService, IMapper mapper, IUsuarioDomainService usuarioDomainService, IEditoraDomainService editoraDomainService, IGeneroDomainService generoDomainService, ILivroRepository livroRepository)
        {
            _livroDomainService = livroDomainService;
            _mapper = mapper;
            _usuarioDomainService = usuarioDomainService;
            _editoraDomainService = editoraDomainService;
            _generoDomainService = generoDomainService;
            _livroRepository = livroRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(LivrosPostResponseModel), 200)]
        public IActionResult Post(LivrosPostRequestModel model)
        {
            try
            {
                //salvando o livro no dominio
                var livro = _livroDomainService.Cadastrar(_mapper.Map<Livro>(model));

                // Recuperar os dados adicionais (usuário, editora, gênero)
                var usuario = _usuarioDomainService.ConsultarPorId(livro.UsuarioId); // Assumindo que você tem um repositório para usuários
                var editora = _editoraDomainService.ConsultarPorId(livro.EditoraId); // Assumindo que você tem um repositório para editoras
                var genero = _generoDomainService.ConsultarPorId(livro.GeneroId); // Assumindo que você tem um repositório para gêneros

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<LivrosGetResponseModel>(livro);

                // Preencher os campos de nome
                response.NomeUsuario = usuario?.Nome;
                response.NomeEditora = editora?.Nome;
                response.NomeGenero = genero?.Nome;

                return StatusCode(201, response);
            }
            catch (DomainException e)
            {
                //HTTP 422 (UNPROCESSABLE CONTENT)
                return StatusCode(422, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(LivrosPutResponseModel), 200)]
        public IActionResult Put(LivrosPutRequestModel model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(LivrosDeleteResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(LivrosGetResponseModel), 200)]
        public IActionResult GetAll() 
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<LivrosGetResponseModel>), 200)]
        public IActionResult GetById(Guid id)
        {

            try
            {
                //consultar 1 livro baseado no ID
                var livro = _livroDomainService.ConsultarPorId(id);

                //verificar se o livro não foi encontrada
                if (livro == null)
                    return StatusCode(204);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<LivrosGetResponseModel>(livro);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
