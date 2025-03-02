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
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(GenerosDeleteResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(GenerosGetResponseModel), 200)]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<GenerosGetResponseModel>), 200)]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}
