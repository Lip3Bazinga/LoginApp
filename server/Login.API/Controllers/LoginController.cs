using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Login.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        public LoginController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var documento = await _mongoDBService.FindAsync(model.Email);
            if (documento != null && documento["password"].AsString == model.Password)
            {
                return Ok("Login realizado com sucesso!");
            }
            else
            {
                return Unauthorized("Credenciais inválidas");
            }
        }
        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
