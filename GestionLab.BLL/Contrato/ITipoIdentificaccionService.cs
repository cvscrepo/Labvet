using GestionLab.DTO;
using GestionLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface ITipoIdentificaccionService
    {
        public Task<List<TipoIdentificacionDTO>> ListarTiposIdentificacion();

        public Task<TipoIdentificacionDTO> CrearTipoIdentificacion(TipoIdentificacionDTO tipoIdentificacion);

        public Task<bool> EditarTipoIdentificacion(TipoIdentificacionDTO TipoFormato);

        public Task<bool> ElimarTipoIdentificacion(int idTipoIdentificacion);
    }
}
