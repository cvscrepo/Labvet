using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.Contrato
{
    public interface IClienteService
    {
        public Task<List<ClienteDTO>> ListarClientes();

        public  Task<ClienteDTO> ListarClienteById(int id);

        public Task<ClienteDTO> CrearCliente(ClienteDTO cliente);

        public Task<bool> EditarCliente(ClienteDTO cliente);

        public Task<bool> EliminarCliente(int id);
    }
}
