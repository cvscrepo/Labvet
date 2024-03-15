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
    public class TipoSolicitudService : ITipoSolicitudService
    {
        private readonly IGenericRepository<TipoSolicitud> _tipoSolicitudRepository;
        private readonly IMapper _mapper;

        public TipoSolicitudService(IGenericRepository<TipoSolicitud> tipoSolicitud, IMapper mapper)
        {
            _tipoSolicitudRepository = tipoSolicitud;
            _mapper = mapper;
        }
        public async Task<List<TipoSolicitudDTO>> ListarTipoSolicitud()
        {
            try
            {
                IQueryable<TipoSolicitud> tipoSolicitud = await _tipoSolicitudRepository.Consultar();
                return _mapper.Map<List<TipoSolicitudDTO>>(tipoSolicitud);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TipoSolicitudDTO> CrearTipSolicitud(TipoSolicitudDTO tipoSolicitud)
        {
            try
            {
                TipoSolicitud TipoSolicitudCreada = await _tipoSolicitudRepository.Crear(_mapper.Map<TipoSolicitud>(tipoSolicitud));
                if (TipoSolicitudCreada == null) throw new TaskCanceledException("Tipo solicitud no pudo ser creado");
                return _mapper.Map<TipoSolicitudDTO>(TipoSolicitudCreada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarTipoSolicitud(TipoSolicitudDTO tipoSolicitud)
        {
            try
            {

                bool tipoSolicitudEditado = await _tipoSolicitudRepository.Editar(_mapper.Map<TipoSolicitud>(tipoSolicitud));
                if (!tipoSolicitudEditado) throw new TaskCanceledException("Tipo solicitud no encontrado");
                return tipoSolicitudEditado;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarTipoSolicitud(int idTipoSolicitud)
        {
            try
            {

                TipoSolicitud tipoSolicitud = await _tipoSolicitudRepository.Obtener(c => c.IdTipoSolicitud == idTipoSolicitud);
                if (tipoSolicitud == null) throw new TaskCanceledException($"El tipo solicitud no fue encontrado con el id {idTipoSolicitud}");
                bool tipoFormatoEliminado = await _tipoSolicitudRepository.Eliminar(tipoSolicitud);
                return tipoFormatoEliminado;

            }
            catch
            {
                throw;
            }
        }

    }
}
