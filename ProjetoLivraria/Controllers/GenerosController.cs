using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(GenerosPostResponseModel), 200)]
        public IActionResult Post(GenerosPostRequestModel model)
        {
            return Ok();
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
