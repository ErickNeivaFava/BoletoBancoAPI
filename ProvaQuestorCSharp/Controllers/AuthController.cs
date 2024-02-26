using Microsoft.AspNetCore.Mvc;
using ProvaQuestorCSharp.Application.Services;

namespace ProvaQuestorCSharp.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "erick" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Domain.Model.Banco());
                return Ok(token);
            }

            return BadRequest("Nome ou senha inválidos");
        }
    }
}