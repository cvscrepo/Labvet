using GestionLab.DTO;
using GestionLab.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.ServiciosTareas.Contrato
{
    public interface ILoginService
    {
        public Task<ResponseLogin> Login(LoginDTO user);
        public Task<UsuarioDTO> Register(UsuarioDTO usuario);
    }
}
