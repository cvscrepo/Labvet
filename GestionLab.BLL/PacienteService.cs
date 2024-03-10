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
    public class PacienteService : IPacienteService
    {
        private readonly IGenericRepository<Paciente> _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(IGenericRepository<Paciente> pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }
        public async Task<List<PacienteDTO>> ListarPacientes()
        {
            try
            {
                IQueryable<Paciente> listarPacientes = await _pacienteRepository.Consultar();
                return _mapper.Map<List<PacienteDTO>>(listarPacientes.ToList());
            }
            catch
            {
                throw;
            }
        }
        public async Task<PacienteDTO> ListarPaciente(int idPaciente)
        {
            try
            {
                IQueryable<Paciente> listarPaciente = await _pacienteRepository.Consultar(c => c.IdPaciente == idPaciente);
                return _mapper.Map<PacienteDTO>(listarPaciente);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PacienteDTO> CrearPaciente(PacienteDTO paciente)
        {
            try
            {
                Paciente PacienteCreado = await _pacienteRepository.Crear(_mapper.Map<Paciente>(paciente));
                if (PacienteCreado == null) throw new TaskCanceledException("Paciente no pudo ser creado");
                IQueryable<Paciente> BuscarPaciente = await _pacienteRepository.Consultar(c => c.IdPaciente == PacienteCreado.IdPaciente);
                return _mapper.Map<PacienteDTO>(BuscarPaciente);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarPaciente(PacienteDTO paciente)
        {
            try
            {

                bool pacienteEditado = await _pacienteRepository.Editar(_mapper.Map<Paciente>(paciente));
                if (!pacienteEditado) throw new TaskCanceledException("Paciente noencontrado");
                return pacienteEditado;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ElimarPaciente(int idPaciente)
        {
            try
            {

                Paciente listarPaciente = await _pacienteRepository.Obtener(c => c.IdPaciente == idPaciente);
                if (listarPaciente == null) throw new TaskCanceledException($"El paciente no fue encontrado con el id {idPaciente}");
                bool PacienteEliminado = await _pacienteRepository.Eliminar(listarPaciente);
                return PacienteEliminado;

            }
            catch
            {
                throw;
            }
        }


    }
}
