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
    public class ServiciosService : IServiciosService
    {
        private readonly IGenericRepository<Servicios> _servicesRepository;
        private IMapper _mapper;

        public ServiciosService(IGenericRepository<Servicios> servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }

        public async Task<List<ServiciosDTO>> GetAllServcios()
        {
            try
            {
                IQueryable<Servicios> listaServicios = await _servicesRepository.Consultar();
                return _mapper.Map<List<ServiciosDTO>>(listaServicios.AsEnumerable().ToList());
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> EditServicio(ServiciosDTO serviciosDTO)
        {
            try
            {
                bool servicioEditado = await _servicesRepository.Editar(_mapper.Map<Servicios>(serviciosDTO));
                return servicioEditado;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ServiciosDTO> CreateServcio(ServiciosDTO serviciosDTO)
        {
            try
            {
                Servicios servicioCreado = await _servicesRepository.Crear(_mapper.Map<Servicios>(serviciosDTO));
                return _mapper.Map<ServiciosDTO>(servicioCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteServicio(ServiciosDTO serviciosDTO)
        {
            try
            {
                bool servicioEliminado = await _servicesRepository.Eliminar(_mapper.Map<Servicios>(serviciosDTO));
                return servicioEliminado;
            }
            catch
            {
                throw;
            }
        }


    }
}
