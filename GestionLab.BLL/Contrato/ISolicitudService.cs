using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface ISolicitudService
    {
        public Task<List<SolicitudDTO>> ListarSolicitud();

        public Task<SolicitudDTO> ListarSolicitud(int idSolicitud);

        public Task<SolicitudDTO> CrearSolicitud(SolicitudDTO solicitud);

        public Task<bool> EditarSolicitud(SolicitudDTO solicitud);

        public Task<bool> ElimarSolicitud(int idSolicitud);
    }
}
