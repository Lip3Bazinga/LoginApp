using Microsoft.AspNetCore.Mvc;

namespace Login.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessaoController : ControllerBase
    {
        [HttpGet]
        public IActionResult SetSession([FromQuery] string nome)
        {
            HttpContext.Session.SetString("nome", nome);
            return Ok();
        }

        [HttpGet("listar")]
        public IActionResult GetSession()
        {
            var nome = HttpContext.Session.GetString("nome");
            return Ok(new { nome });
        }
    }

}
