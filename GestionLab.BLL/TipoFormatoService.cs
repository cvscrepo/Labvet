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
    public class TipoFormatoService : ITipoFormatoService
    {
        private readonly IGenericRepository<TipoFormato> _tipoFormatoRepository;
        private readonly IMapper _mapper;

        public TipoFormatoService(IGenericRepository<TipoFormato> tipoFormatoRepository, IMapper mapper)
        {
            _tipoFormatoRepository = tipoFormatoRepository;
            _mapper = mapper;
        }
        public async Task<List<TipoFormatoDTO>> ListarTiposFormatos()
        {
            try
            {
                IQueryable<TipoFormato> listarTipoFormatos = await _tipoFormatoRepository.Consultar();
                return _mapper.Map<List<TipoFormatoDTO>>(listarTipoFormatos);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TipoFormatoDTO> CrearTipoFormato(TipoFormatoDTO tipoFormato)
        {
            try
            {
                TipoFormato TipoFormatoCreada = await _tipoFormatoRepository.Crear(_mapper.Map<TipoFormato>(tipoFormato));
                if (TipoFormatoCreada == null) throw new TaskCanceledException("Tipo formato no pudo ser creado");
                return _mapper.Map<TipoFormatoDTO>(TipoFormatoCreada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarTIpoFormato(TipoFormatoDTO TipoFormato)
        {
            try
            {

                bool tipoFormatoEditado = await _tipoFormatoRepository.Editar(_mapper.Map<TipoFormato>(TipoFormato));
                if (!tipoFormatoEditado) throw new TaskCanceledException("Tipo formato no encontrado");
                return tipoFormatoEditado;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarTipoFormato(int idTipoFormato)
        {
            try
            {

                TipoFormato tipoFormato = await _tipoFormatoRepository.Obtener(c => c.IdTipoFormato == idTipoFormato);
                if (tipoFormato == null) throw new TaskCanceledException($"El tipo formato no fue encontrado con el id {idTipoFormato}");
                bool tipoFormatoEliminado = await _tipoFormatoRepository.Eliminar(tipoFormato);
                return tipoFormatoEliminado;

            }
            catch
            {
                throw;
            }
        }

    }
}
