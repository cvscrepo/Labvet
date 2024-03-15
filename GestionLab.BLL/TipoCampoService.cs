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
    public class TipoCampoService : ITipoCampoService
    {
        private readonly IGenericRepository<TipoCampo> _tipoCampoRepository;
        private readonly IMapper _mapper;

        public TipoCampoService(IGenericRepository<TipoCampo> tipoCampoRepository, IMapper mapper)
        {
            _tipoCampoRepository = tipoCampoRepository;
            _mapper = mapper;
        }

        public async Task<List<TipoCampoDTO>> ListarTipoCampo()
        {
            try
            {
                IQueryable<TipoCampo> listarTipoCampo = await _tipoCampoRepository.Consultar();
                return _mapper.Map<List<TipoCampoDTO>>(listarTipoCampo.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<TipoCampoDTO> CrearTipoCampo(TipoCampoDTO tipoCampo)
        {
            try
            {
                TipoCampo TipoCampoCreado = await _tipoCampoRepository.Crear(_mapper.Map<TipoCampo>(tipoCampo));
                if (TipoCampoCreado == null) throw new TaskCanceledException("Tipo Campo no pudo ser creado");
                return _mapper.Map<TipoCampoDTO>(TipoCampoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarTipoCampo(TipoCampoDTO tipoCampo)
        {
            try
            {

                bool tipoCampoEditado = await _tipoCampoRepository.Editar(_mapper.Map<TipoCampo>(tipoCampoS));
                if (!tipoCampoEditado) throw new TaskCanceledException("Tipo Campo no encontrado");
                return tipoCampoEditado;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarTipoCampo(int idTipoCampo)
        {
            try
            {

                TipoCampo listarTipoCampo = await _tipoCampoRepository.Obtener(c => c.IdTipoCampo == idTipoCampo);
                if (listarTipoCampo == null) throw new TaskCanceledException($"El tipo campo no fue encontrado con el id {idTipoCampo}");
                bool TipoCampoEliminado = await _tipoCampoRepository.Eliminar(listarTipoCampo);
                return TipoCampoEliminado;

            }
            catch
            {
                throw;
            }
        }

    }
}
