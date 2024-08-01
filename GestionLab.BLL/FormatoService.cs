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
    public class FormatoService : IFormatoService
    {
        private readonly IGenericRepository<Formato> _formatoRepository;
        private readonly IMapper _mapper;

        public FormatoService(IGenericRepository<Formato> formatoRepository, IMapper mapper)
        {
            _formatoRepository = formatoRepository;
            _mapper = mapper;
        }

        public async Task<List<FormatoDTO>> ListarFormatos()
        {
            try
            {
                IQueryable<Formato> listaFormatos = await _formatoRepository.Consultar();
                List<Formato> query = listaFormatos.Include(c => c.CampoFormatos).AsEnumerable().ToList();
                return _mapper.Map<List<FormatoDTO>>(query);
            }
            catch
            {
                throw;
            }
        }
        public async Task<FormatoDTO> ListarFormato(int idFormato)
        {
            try
            {
                IQueryable<Formato> listaCliente = await _formatoRepository.Consultar(c => c.IdFormato == idFormato);
                Formato query = listaCliente.Include(c => c.CampoFormatos).First();
                return _mapper.Map<FormatoDTO>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<FormatoDTO> CrearFormato(FormatoDTO formato)
        {
            try
            {
                Formato FormatoCreado = await _formatoRepository.Crear(_mapper.Map<Formato>(formato));
                if (FormatoCreado == null) throw new TaskCanceledException("Formato no pudo ser creado");
                IQueryable<Formato> BuscarCliente = await _formatoRepository.Consultar(c => c.IdFormato == FormatoCreado.IdFormato);
                Formato query = BuscarCliente.Include(c => c.CampoFormatos).First();
                return _mapper.Map<FormatoDTO>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<FormatoDTO> EditarFormato(FormatoDTO formato)
        {
            try
            {
                bool formatoEditado = await _formatoRepository.Editar(_mapper.Map<Formato>(formato));
                if (!formatoEditado) throw new TaskCanceledException("Formato noencontrado");
                return formato;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarFormato(int idFormato)
        {
            try
            {
                Formato listarFormato = await _formatoRepository.Obtener(c => c.IdFormato == idFormato);
                if (listarFormato == null) throw new TaskCanceledException($"El formato no fue encontrado con el id {idFormato}");
                bool formatoEliminado = await _formatoRepository.Eliminar(listarFormato);
                return formatoEliminado;
            }
            catch
            {
                throw;
            }
        }

    }
}
