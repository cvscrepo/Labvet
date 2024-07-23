using GestionLab.BLL;
using GestionLab.BLL.Contrato;
using GestionLab.DTO;
using GestionLab.Utility;
using Microsoft.AspNetCore.Mvc;

namespace GestionLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRol()
        {
            ResponseController response = new ResponseController();
            try
            {
                List<RolDTO> listaServicios = await _rolService.ListarRoles();
                response.Success = true;
                response.Message = "Ok";
                response.Value = listaServicios;
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

        [HttpPost]
        public async Task<IActionResult> CreateRol([FromBody] RolDTO rolDTO)
        {
            ResponseController response = new ResponseController();
            try
            {
                RolDTO servicioCreado = await _rolService.CrearRol(rolDTO);
                response.Success = true;
                response.Message = "Ok";
                response.Value = servicioCreado;
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
