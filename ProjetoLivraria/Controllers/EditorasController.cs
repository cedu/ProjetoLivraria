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
    public class EditorasController : ControllerBase
    {
        private readonly IEditoraDomainService _editoraDomainService;
        private readonly IMapper _mapper;

        //construtor para injeção de dependências das interfaces
        public EditorasController(IEditoraDomainService editoraDomainService, IMapper mapper)
        {
            _editoraDomainService = editoraDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EditorasPostResponseModel), 200)]
        public IActionResult Post(EditorasPostRequestModel model)
        {
            try
            {
                //salvando o usuario no dominio
                var editora = _editoraDomainService.Cadastrar(_mapper.Map<Editora>(model));

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<EditorasGetResponseModel>(editora);
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
        [ProducesResponseType(typeof(EditorasPutResponseModel), 200)]
        public IActionResult Put(EditorasPutRequestModel model)
        {
            try
            {
                //atualizar a editora
                var editora = _editoraDomainService.Atualizar(_mapper.Map<Editora>(model));

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<EditorasGetResponseModel>(editora);
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
        [ProducesResponseType(typeof(EditorasDeleteResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //excluir a editora
                var editora = _editoraDomainService.Excluir(id);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<EditorasGetResponseModel>(editora);
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
        [ProducesResponseType(typeof(EditorasGetResponseModel), 200)]
        public IActionResult GetAll()
        {
            try
            {
                //consultar todas as editoras
                var editoras = _editoraDomainService.ConsultarTodos();

                //verificar se nenhuma editora foi encontrada
                if (!editoras.Any())
                    return StatusCode(204);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<List<EditorasGetResponseModel>>(editoras);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<EditorasGetResponseModel>), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                //consultar 1 editora baseado no ID
                var editora = _editoraDomainService.ConsultarPorId(id);

                //verificar se a editora não foi encontrada
                if (editora == null)
                    return StatusCode(204);

                //objeto para retornar os dados da resposta
                var response = _mapper.Map<EditorasGetResponseModel>(editora);
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
