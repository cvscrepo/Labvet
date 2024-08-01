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
    public class CampoFormatoService : ICampoFormatoService
    {
        private readonly IGenericRepository<CampoFormato> _campoFormatoRepository;
        private readonly IMapper _mapper;

        public CampoFormatoService(IGenericRepository<CampoFormato> campoFormatoRepository, IMapper mapper)
        {
            _campoFormatoRepository = campoFormatoRepository;
            _mapper = mapper;
        }
        public async Task<CampoFormatoDTO> ListarCampo(int idCampo)
        {
            try
            {
                IQueryable<CampoFormato> listaCampo = await _campoFormatoRepository.Consultar(c => c.IdCampo == idCampo);
                CampoFormato query = listaCampo.Include(c => c.IdTipoCampoNavigation).First();
                return _mapper.Map<CampoFormatoDTO>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CampoFormatoDTO> CrearCampo(CampoFormatoDTO campo)
        {
            try
            {
                CampoFormato campoCreado = await _campoFormatoRepository.Crear(_mapper.Map<CampoFormato>(campo));
                if (campoCreado == null) throw new TaskCanceledException("El campo no pudo ser creado");
                IQueryable<CampoFormato> BuscarCampo = await _campoFormatoRepository.Consultar(c => c.IdCampo == campoCreado.IdCampo);
                return _mapper.Map<CampoFormatoDTO>(BuscarCampo.First());
            }
            catch
            {
                throw;
            }
        }

        public async Task<CampoFormatoDTO> EditarCampo(CampoFormatoDTO campo)
        {
            try
            {
                bool campoEditado = await _campoFormatoRepository.Editar(_mapper.Map<CampoFormato>(campo));
                if (!campoEditado) throw new TaskCanceledException("Cliente noencontrado");
                return campo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarCampo(int id)
        {
            try
            {
                CampoFormato campoaEliminar  = await _campoFormatoRepository.Obtener(c => c.IdCampo == id);
                if (campoaEliminar == null) throw new TaskCanceledException($"El cliente no fue encontrado con el id {id}");
                bool campoEliminado = await _campoFormatoRepository.Eliminar(campoaEliminar);
                return campoEliminado;
            }
            catch
            {
                throw;
            }
        }

       
    }
}
