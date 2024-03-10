using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface IPacienteService
    {
        public Task<List<PacienteDTO>> ListarPacientes();

        public Task<PacienteDTO> ListarPaciente(int idPaciente);

        public Task<PacienteDTO> CrearPaciente(PacienteDTO formato);

        public Task<bool> EditarPaciente(PacienteDTO paciente);

        public Task<bool> ElimarPaciente(int idPaciente);
    }
}
