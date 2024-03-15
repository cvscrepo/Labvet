using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface ITipoFormatoService
    {
        public Task<List<TipoFormatoDTO>> ListarTiposFormatos();

        public Task<TipoFormatoDTO> CrearTipoFormato(TipoFormatoDTO tipoFormato);

        public Task<bool> EditarTIpoFormato(TipoFormatoDTO TipoFormato);

        public Task<bool> ElimarTipoFormato(int idTipoFormato);
    }
}
