using AutoMapper;
using GestionLab.BLL.Contrato;
using GestionLab.DAL.Repositorios.Contratos;
using GestionLab.DTO;
using GestionLab.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL
{
    public class SolicitudService : ISolicitudService
    {
        private readonly IGenericRepository<Solicitud> _solicitudRepository;
        private readonly IMapper _mapper;

        public SolicitudService(IGenericRepository<Solicitud> solicitudRepository, IMapper mapper)
        {
            _solicitudRepository = solicitudRepository;
            _mapper = mapper;
        }
        public async Task<List<SolicitudDTO>> ListarSolicitud()
        {
            try
            {
                IQueryable<Solicitud> listarSolicitudes = await _solicitudRepository.Consultar();
                List<Solicitud> query = listarSolicitudes.Include(s => s.Formatos).Include(s => s.IdClienteNavigation).Include(s => s.IdTipoSolicitudNavigation).AsEnumerable().ToList();
                return _mapper.Map<List<SolicitudDTO>>(query);
            }   
            catch
            {
                throw;
            }
        }

        public async Task<SolicitudDTO> ListarSolicitud(int idSolicitud)
        {
            try
            {
                IQueryable<Solicitud> listarSolicitud = await _solicitudRepository.Consultar(c => c.IdSolicitud == idSolicitud);
                return _mapper.Map<SolicitudDTO>(listarSolicitud);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SolicitudDTO> CrearSolicitud(SolicitudDTO solicitud)
        {
            try
            {
                Solicitud SolicitudCreada = await _solicitudRepository.Crear(_mapper.Map<Solicitud>(solicitud));
                if (SolicitudCreada == null) throw new TaskCanceledException("Solicitud no pudo ser creada");
                IQueryable<Solicitud> BuscarSolicitud = await _solicitudRepository.Consultar(c => c.IdSolicitud == SolicitudCreada.IdPaciente);
                List<Solicitud> query = BuscarSolicitud.Include(s => s.Formatos).Include(s => s.IdClienteNavigation).Include(s => s.IdTipoSolicitudNavigation).AsEnumerable().ToList();
                return _mapper.Map<SolicitudDTO>(query.First());
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarSolicitud(SolicitudDTO solicitud)
        {
            try
            {

                bool solicitudEditada = await _solicitudRepository.Editar(_mapper.Map<Solicitud>(solicitud));
                if (!solicitudEditada) throw new TaskCanceledException("Solcitud noencontrado");
                return solicitudEditada;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarSolicitud(int idSolicitud)
        {
            try
            {

                Solicitud listarSolicitud = await _solicitudRepository.Obtener(c => c.IdSolicitud == idSolicitud);
                if (listarSolicitud == null) throw new TaskCanceledException($"La solicitud no fue encontrada con el id {idSolicitud}");
                bool PacienteEliminado = await _solicitudRepository.Eliminar(listarSolicitud);
                return PacienteEliminado;

            }
            catch
            {
                throw;
            }
        }

    }
}
