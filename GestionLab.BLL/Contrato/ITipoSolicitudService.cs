using GestionLab.DTO;
using GestionLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface ITipoSolicitudService
    {
        public Task<List<TipoSolicitudDTO>> ListarTipoSolicitud();

        public Task<TipoSolicitudDTO> CrearTipSolicitud(TipoSolicitudDTO tipoSolicitud);

        public Task<bool> EditarTipoSolicitud(TipoSolicitudDTO tipoSolicitud);

        public Task<bool> ElimarTipoSolicitud(int idTipoSolicitud);
    }
}
