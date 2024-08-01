using GestionLab.BLL.Contrato;
using GestionLab.DTO;
using GestionLab.Utility;
using Microsoft.AspNetCore.Mvc;

namespace GestionLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudController  : ControllerBase
    {
        private ISolicitudService _solicitudService;
        public SolicitudController(ISolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSolicitudes()
        {
            ResponseController responseController = new ResponseController();
            try
            {
                List<SolicitudDTO> solicitudes = await _solicitudService.ListarSolicitud();
                responseController.Success = true;
                responseController.Message = "Ok";
                responseController.Value = solicitudes;
                return Ok(responseController);
            }
            catch (Exception ex)
            {
                responseController.Success = false;
                responseController.Message = ex.Message;

                return BadRequest(responseController);
            }
        }

        [HttpGet("{idSolicitud}")]
        public async Task<IActionResult> GetSolicitud(int idSolicitud)
        {
            ResponseController responseController = new ResponseController();
            try
            {
                SolicitudDTO solicitud = await _solicitudService.ListarSolicitud(idSolicitud);
                responseController.Success = true;
                responseController.Message = "Ok";
                responseController.Value = solicitud;
                return Ok(responseController);
            }
            catch (Exception ex)
            {
                responseController.Success = false;
                responseController.Message = ex.Message;
                return BadRequest(responseController);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSolicitud([FromBody] SolicitudDTO solicitud)
        {
            ResponseController responseController = new ResponseController();
            try
            {
                SolicitudDTO solicitudCreada = await _solicitudService.CrearSolicitud(solicitud);
                responseController.Success = true;
                responseController.Message = "Ok";
                responseController.Value = solicitudCreada;
                return Ok(responseController);
            }
            catch (Exception ex)
            {
                responseController.Success = false;
                responseController.Message = ex.Message;
                return BadRequest(responseController);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSolicitud([FromBody] SolicitudDTO solicitud)
        {
            ResponseController responseController = new ResponseController();
            try
            {
                bool solicitudActualizada = await _solicitudService.EditarSolicitud(solicitud);
                responseController.Success = true;
                responseController.Message = "Ok";
                responseController.Value = solicitudActualizada;
                return Ok(responseController);
            }
            catch (Exception ex)
            {
                responseController.Success = false;
                responseController.Message = ex.Message;
                return BadRequest(responseController);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSolicitud([FromBody] SolicitudDTO solicitud)
        {
            ResponseController responseController = new ResponseController();
            try
            {
                await _solicitudService.ElimarSolicitud(solicitud.IdSolicitud);
                responseController.Success = true;
                responseController.Message = "Ok";
                return Ok(responseController);
            }
            catch (Exception ex)
            {
                responseController.Success = false;
                responseController.Message = ex.Message;
                return BadRequest(responseController);
            }
        }
    }
}
