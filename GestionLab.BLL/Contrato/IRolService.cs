using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface IRolService
    {
        public Task<List<RolDTO>> ListarRoles();

        public Task<RolDTO> CrearRol(RolDTO rol);

        public Task<bool> EditarRol(RolDTO rol);

        public Task<bool> ElimarRol(int idRol);
    }
}
