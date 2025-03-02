using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(LivrosPostResponseModel), 200)]
        public IActionResult Post(LivrosPostRequestModel model)
        {
            return Ok();
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
            return Ok();
        }
    }
}
