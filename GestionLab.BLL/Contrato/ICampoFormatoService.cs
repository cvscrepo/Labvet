using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface ICampoFormatoService
    {
        public Task<CampoFormatoDTO> ListarCampo(int idCampo);

        public Task<CampoFormatoDTO> CrearCampo(CampoFormatoDTO campo);

        public Task<CampoFormatoDTO> EditarCampo(CampoFormatoDTO campo);

        public Task<bool> ElimarCampo(int id);
    }
}
