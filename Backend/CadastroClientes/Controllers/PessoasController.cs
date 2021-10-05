using CadastroClientes.Application.Interfaces;
using CadastroClientes.Domain.Entitites;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroClientes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaApplication _application;
        public PessoasController(IPessoaApplication application) => _application = application;

        [HttpGet]
        public virtual IActionResult Get([FromQuery] string query) => Ok(_application.GetAll(query));

        [HttpGet("{id}")]
        public virtual IActionResult Get(long id) => Ok(_application.GetById(id));

        [HttpPost]
        public virtual IActionResult Post([FromBody]Pessoa pessoa)
        {
            try
            {
                _application.AddOrUpdate(pessoa);

                return Ok(pessoa.Id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(long id)
        {
            try
            {
                _application.Remove(id);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("listarPorTelefones")]
        public virtual IActionResult GetByTelefones([FromQuery] string query) => Ok(_application.GetByTelefones(query));

    }
}
