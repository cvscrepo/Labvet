using GestionLab.BLL.ServiciosTareas.Contrato;
using GestionLab.DTO;
using GestionLab.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService) 
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDTO login)
        {
            ResponseController response = new ResponseController();
            try
            {
                ResponseLogin token = await _loginService.Login(login);
                response.Success = true;
                response.Message = token.token;
                response.Value = token.user;
                return Ok(response);

            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioDTO usuario)
        {
            ResponseController response = new ResponseController();
            try
            {
                UsuarioDTO usuarioRegistrado = await _loginService.Register(usuario);
                response.Success = true;
                response.Message = "Ok";
                response.Value = usuarioRegistrado;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Value = ex;
                return BadRequest(response);
            }
        }
    }
}
