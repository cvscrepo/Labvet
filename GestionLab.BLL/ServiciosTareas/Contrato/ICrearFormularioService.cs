using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.ServiciosTareas.Contrato
{
    public interface ICrearFormularioService
    {
        public Task<FormatoDTO> CrearFormulario(FormatoDTO formato);
    }
}
