using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface ITipoCampoService
    {
        public Task<List<TipoCampoDTO>> ListarTipoCampo();

        public Task<TipoCampoDTO> CrearTipoCampo(TipoCampoDTO tipoCampo);

        public Task<bool> EditarTipoCampo(TipoCampoDTO tipoCampo);

        public Task<bool> ElimarTipoCampo(int idTipoCampo);
    }
}
