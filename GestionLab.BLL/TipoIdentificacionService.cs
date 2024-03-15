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
    public class TipoIdentificacionService : ITipoIdentificaccionService
    {
        private readonly IGenericRepository<TipoIdentificacion> _tipoIdentificacionRepository;
        private readonly IMapper _mapper;

        public TipoIdentificacionService(IGenericRepository<TipoIdentificacion> tipoIdentificacionRepository, IMapper mapper)
        {
            _tipoIdentificacionRepository = tipoIdentificacionRepository;
            _mapper = mapper;
        }
        public async Task<List<TipoIdentificacionDTO>> ListarTiposIdentificacion()
        {
            try
            {
                IQueryable<TipoIdentificacion> listarTiposIdentificacion = await _tipoIdentificacionRepository.Consultar();
                return _mapper.Map<List<TipoIdentificacionDTO>>(listarTiposIdentificacion.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<TipoIdentificacionDTO> CrearTipoIdentificacion(TipoIdentificacionDTO tipoIdentificacion)
        {
            try
            {
                TipoIdentificacion tipoIdentificacionCreado = await _tipoIdentificacionRepository.Crear(_mapper.Map<TipoIdentificacion>(tipoIdentificacion));
                if (tipoIdentificacionCreado == null) throw new TaskCanceledException("Tipo identificacion no pudo ser creado");
                return _mapper.Map<TipoIdentificacionDTO>(tipoIdentificacionCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarTipoIdentificacion(TipoIdentificacionDTO TipoFormato)
        {
            try
            {

                bool tipoIdentificacion = await _tipoIdentificacionRepository.Editar(_mapper.Map<TipoIdentificacion>(TipoFormato));
                if (!tipoIdentificacion) throw new TaskCanceledException("Tipo formato no encontrado");
                return tipoIdentificacion;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarTipoIdentificacion(int idTipoIdentificacion)
        {
            try
            {

                TipoIdentificacion tipoIdentificacion = await _tipoIdentificacionRepository.Obtener(c => c.IdTipoIdentificacion == idTipoIdentificacion);
                if (tipoIdentificacion == null) throw new TaskCanceledException($"El tipo identificacion no fue encontrado con el id {idTipoIdentificacion}");
                bool tipoIdentificacionEliminado = await _tipoIdentificacionRepository.Eliminar(tipoIdentificacion);
                return tipoIdentificacionEliminado;

            }
            catch
            {
                throw;
            }
        }

    }
}
