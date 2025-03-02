using AutoMapper;
using LivrariasApp.API.Models;
using LivrariasApp.API.Services;
using LivrariasApp.Domain.Exceptions;
using LivrariasApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Entities;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IMapper _mapper;

        //construtor para injeção de dependências das interfaces
        public UsuariosController(IUsuarioDomainService usuarioDomainService, IMapper mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsuariosPostResponseModel), 201)]
        public IActionResult Post([FromBody] UsuariosPostRequestModel model)
        {

            try
            {
                //salvando o usuario no dominio
                var usuario = _usuarioDomainService.Cadastrar(_mapper.Map<Usuario>(model));

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<UsuariosGetResponseModel>(usuario);
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
        [ProducesResponseType(typeof(UsuariosPutResponseModel), 200)]
        public IActionResult Put(UsuariosPutRequestModel model)
        {
            try
            {
                //atualizar o usuario
                var usuario = _usuarioDomainService.Atualizar(_mapper.Map<Usuario>(model));

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<UsuariosGetResponseModel>(usuario);
                return StatusCode(200, response);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UsuariosDeleteResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {

            try
            {
                //excluir o usuario
                var usuario = _usuarioDomainService.Excluir(id);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<UsuariosGetResponseModel>(usuario);
                return StatusCode(200, response);
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

        [HttpGet]
        [ProducesResponseType(typeof(List<UsuariosGetResponseModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                //consultar todos os usuarios
                var usuarios = _usuarioDomainService.ConsultarTodos();

                //verificar se nenhum usuario foi encontrado
                if (!usuarios.Any())
                    return StatusCode(204);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<List<UsuariosGetResponseModel>>(usuarios);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuariosGetResponseModel), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                //consultar 1 usuario baseado no ID
                var usuario = _usuarioDomainService.ConsultarPorId(id);

                //verificar se o usuario não foi encontrada
                if (usuario == null)
                    return StatusCode(204);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<UsuariosGetResponseModel>(usuario);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPost]
        [Route("autenticar")] //ENDPOINT: api/usuarios/autenticar
        [ProducesResponseType(typeof(AutenticarUsuarioResponseModel), 200)]
        public IActionResult Autenticar(AutenticarUsuarioRequestModel model)
        {
            //capturando os dados do usuário "mockado"
            var usuario = Usuarios.MockUsuario();

            //verificando se o dto confere com os dados do usuário
            if (usuario.Email.Equals(model.Email) && usuario.Senha.Equals(model.Senha))
            {
                //criando os dados do usuário autenticado
                var response = new AutenticarUsuarioResponseModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    DataHoraAcesso = DateTime.Now,
                    AccessToken = JwtBearerService.GenerateToken(usuario.Id.Value),
                    DataHoraExpiracao = DateTime.Now.AddHours(Convert.ToDouble(JwtBearerService.ExpirationInHours))
                };

                //retornando os dados do usuário autenticado
                return StatusCode(200, response);
            }
            else
            {
                //retornar acesso negado (401 - UNAUTHORIZED)
                return StatusCode(401, new { message = "Acesso negado. Usuário inválido." });
            }
        }

        [HttpGet]
        [Route("obter-dados")]
        public IActionResult ObterDados()
        {
            return Ok();
        }
    }
}