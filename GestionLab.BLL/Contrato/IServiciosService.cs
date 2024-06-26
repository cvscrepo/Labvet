using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface IServiciosService
    {
        public Task<List<ServiciosDTO>> GetAllServcios();
        public Task<ServiciosDTO> CreateServcio(ServiciosDTO serviciosDTO);
        public Task<bool> EditServicio(ServiciosDTO serviciosDTO);
        public Task<bool> DeleteServicio(ServiciosDTO serviciosDTO);
    }
}
