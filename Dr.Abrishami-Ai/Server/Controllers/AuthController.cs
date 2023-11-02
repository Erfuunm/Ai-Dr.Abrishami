using Dr.Abrishami_Ai.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dr.Abrishami_Ai.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            SessionDTO sessionDTO = new SessionDTO();

            if (login.Username == "admin" && login.Password == "admin159753")
            {
                sessionDTO.Nombre = "admin";
                sessionDTO.Correo = login.Username;
                sessionDTO.Rol = "Administrator";
            }
            else
            {
                sessionDTO.Nombre = "User";
                sessionDTO.Correo = login.Username;
                sessionDTO.Rol = "User";

            }
            return StatusCode(StatusCodes.Status200OK, sessionDTO);
        }
    }
}
