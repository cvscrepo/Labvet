using AutoMapper;
using GestionLab.BLL.Contrato;
using GestionLab.DAL.Repositorios.Contratos;
using GestionLab.DTO;
using GestionLab.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IGenericRepository<Usuario> usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<List<UsuarioDTO>> ListarUsuarios()
        {
            try
            {
                IQueryable<Usuario> listarUsuarios = await _usuarioRepository.Consultar();
                var query = listarUsuarios.Include(usuario => usuario.IdRolNavigation).ToList();
                return _mapper.Map<List<UsuarioDTO>>(listarUsuarios);
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<UsuarioDTO> ListarUsuario(int idUsuario)
        {
            try
            {
                IQueryable<Usuario> usuarioEncontrado = await _usuarioRepository.Consultar(c => c.IdUsuario == idUsuario);
                if (usuarioEncontrado.AsEnumerable().IsNullOrEmpty()) throw new TaskCanceledException("No se encontraró el usuario");
                var query = usuarioEncontrado.Include(u => u.IdRolNavigation);
                return _mapper.Map<UsuarioDTO>(usuarioEncontrado.First());
            }
            catch
            {
                throw;
            }
        }

        public async Task<UsuarioDTO> CrearUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                Usuario usuarioCreado = await _usuarioRepository.Crear(_mapper.Map<Usuario>(usuarioDTO));
                if (usuarioCreado == null) throw new TaskCanceledException("Usuario no pudo ser creado");
                return _mapper.Map<UsuarioDTO>(usuarioCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {

                bool usuarioEditao = await _usuarioRepository.Editar(_mapper.Map<Usuario>(usuarioDTO));
                if (!usuarioEditao) throw new TaskCanceledException("Usuario no encontrado");
                return usuarioEditao;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarUsuario(int idUsuario)
        {
            try
            {

                Usuario usuario = await _usuarioRepository.Obtener(c => c.IdUsuario == idUsuario);
                if (usuario == null) throw new TaskCanceledException($"El usuario no fue encontrado con el id {idUsuario}");
                bool usuarioEliminado = await _usuarioRepository.Eliminar(usuario);
                return usuarioEliminado;

            }
            catch
            {
                throw;
            }
        }

    }
}
