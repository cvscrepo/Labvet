using GestionLab.BLL.Contrato;
using GestionLab.DTO;
using GestionLab.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiciosService _serviciosService;

        public ServiciosController(IServiciosService serviciosService)
        {
            _serviciosService = serviciosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServicios()
        {
            ResponseController response = new ResponseController();
            try
            {
                List<ServiciosDTO> listaServicios = await _serviciosService.GetAllServcios();
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
        public async Task<IActionResult> CreateService([FromBody]ServiciosDTO servicio)
        {
            ResponseController response = new ResponseController(); 
            try
            {
                ServiciosDTO servicioCreado = await _serviciosService.CreateServcio(servicio);
                response.Success = true;
                response.Message = "Ok";
                response.Value = servicioCreado; 
                return Ok(response);

            }catch (Exception ex)
            {
                response.Success=false;
                response.Message = ex.Message;
                response.Value = ex;
                return BadRequest(response);
            }
        }
    }
}
