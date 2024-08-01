using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface IFormatoService
    {
        public Task<List<FormatoDTO>> ListarFormatos();

        public Task<FormatoDTO> ListarFormato(int idFormato);

        public Task<FormatoDTO> CrearFormato(FormatoDTO formato);

        public Task<FormatoDTO> EditarFormato(FormatoDTO formato);

        public Task<bool> ElimarFormato(int idFormato);
    }
}
