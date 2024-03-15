using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface IUsuarioService
    {
        public Task<List<UsuarioDTO>> ListarUsuarios();

        public Task<UsuarioDTO> ListarUsuario(int idUsuario);

        public Task<UsuarioDTO> CrearUsuario(UsuarioDTO usuarioDTO);

        public Task<bool> EditarUsuario(UsuarioDTO usuarioDTO);

        public Task<bool> ElimarUsuario(int idUsuario);
    }
}
