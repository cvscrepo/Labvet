using AutoMapper;
using GestionLab.BLL.Contrato;
using GestionLab.DAL.Repositorios.Contratos;
using GestionLab.DTO;
using GestionLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;
        public async Task<List<RolDTO>> ListarRoles()
        {
            try
            {
                IQueryable<Rol> listarPacientes = await _rolRepository.Consultar();
                return _mapper.Map<List<RolDTO>>(listarPacientes.ToList());
            }
            catch
            {
                throw;
            }
        }
        public async Task<RolDTO> CrearRol(RolDTO rol)
        {
            try
            {
                Rol rolCreado = await _rolRepository.Crear(_mapper.Map<Rol>(rol));
                if (rolCreado == null) throw new TaskCanceledException("Paciente no pudo ser creado");
                IQueryable<Rol> buscarRol = await _rolRepository.Consultar(c => c.IdRol == rolCreado.IdRol);
                return _mapper.Map<RolDTO>(buscarRol);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarRol(RolDTO rol)
        {
            try
            {

                bool rolEditado = await _rolRepository.Editar(_mapper.Map<Rol>(rol));
                if (!rolEditado) throw new TaskCanceledException("Paciente noencontrado");
                return rolEditado;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarRol(int idRol)
        {
            try
            {

                Rol listarRol = await _rolRepository.Obtener(c => c.IdRol == idRol);
                if (listarRol == null) throw new TaskCanceledException($"El rol no fue encontrado con el id {idRol}");
                bool rolEliminado = await _rolRepository.Eliminar(listarRol);
                return rolEliminado;

            }
            catch
            {
                throw;
            }
        }

    }
}
