using GestionLab.BLL.Contrato;
using GestionLab.DTO;
using GestionLab.Model;
using GestionLab.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GestionLab.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            ResponseController response = new ResponseController();
            try
            {
                List<UsuarioDTO> usuarios = await _usuarioService.ListarUsuarios();
                response.Success = true;
                response.Message = "Ok";
                response.Value = usuarios;
                return Ok(response);
            }catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Value = ex;
                return BadRequest(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarUsuario([FromQuery] int id)
        {
            ResponseController response = new ResponseController();
            try
            {
                UsuarioDTO usuario = await _usuarioService.ListarUsuario(id);
                response.Success = true;
                response.Message = "Ok";
                response.Value = usuario;
                return Ok(response);

            }catch (Exception ex)
            {
                response.Success = false;
                response.Message =ex.Message;
                response.Value = ex;
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistarUsuario([FromBody] UsuarioDTO usuario)
        {
            ResponseController response= new ResponseController();
            try
            {
                UsuarioDTO usuarioCreado = await _usuarioService.CrearUsuario(usuario);
                response.Success = true;
                response.Message = "Ok";
                response.Value = usuarioCreado;
                return Ok(response);

            }catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Value = ex;
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario([FromBody] UsuarioDTO usuario)
        {
            ResponseController response = new ResponseController();
            try
            {
                bool usuarioEditado = await _usuarioService.EditarUsuario(usuario);
                response.Success = usuarioEditado;
                response.Message = "ok";
                response.Value = usuarioEditado;
                return Ok(response);

            }catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Value = ex;
                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarUsuario([FromQuery] int id)
        {
            ResponseController response = new ResponseController();
            try
            {
                bool usuarioEliminado = await _usuarioService.ElimarUsuario(id);
                response.Success = usuarioEliminado;
                response.Message = "Ok";
                return Ok(response);
            }catch(Exception ex)
            {
                response.Success = false;
                response.Message=ex.Message;
                response.Value = ex;
                return BadRequest(response);
            }
        }
    }
}
