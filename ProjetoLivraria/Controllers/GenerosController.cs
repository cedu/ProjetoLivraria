using AutoMapper;
using LivrariasApp.Domain.Exceptions;
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
    public class GenerosController : ControllerBase
    {

        private readonly IGeneroDomainService _generoDomainService;
        private readonly IMapper _mapper;

        //construtor para injeção de dependências das interfaces
        public GenerosController(IGeneroDomainService generoDomainService, IMapper mapper)
        {
            _generoDomainService = generoDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenerosPostResponseModel), 200)]
        public IActionResult Post(GenerosPostRequestModel model)
        {
            try
            {
                //salvando o usuario no dominio
                var genero = _generoDomainService.Cadastrar(_mapper.Map<Genero>(model));

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<GenerosGetResponseModel>(genero);
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
        [ProducesResponseType(typeof(GenerosPutResponseModel), 200)]
        public IActionResult Put(GenerosPutRequestModel model)
        {
            try
            {
                //atualizar o genero
                var genero = _generoDomainService.Atualizar(_mapper.Map<Genero>(model));

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<GenerosGetResponseModel>(genero);
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
        [ProducesResponseType(typeof(GenerosDeleteResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //excluir o genero
                var genero = _generoDomainService.Excluir(id);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<GenerosGetResponseModel>(genero);
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
        [ProducesResponseType(typeof(GenerosGetResponseModel), 200)]
        public IActionResult GetAll()
        {
            try
            {
                //consultar todas os  generos
                var generos = _generoDomainService.ConsultarTodos();

                //verificar se nenhum genero foi encontrado
                if (!generos.Any())
                    return StatusCode(204);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<List<GenerosGetResponseModel>>(generos);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<GenerosGetResponseModel>), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                //consultar 1 genero baseado no ID
                var genero = _generoDomainService.ConsultarPorId(id);

                //verificar se o genero não foi encontrado
                if (genero == null)
                    return StatusCode(204);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<GenerosGetResponseModel>(genero);
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
