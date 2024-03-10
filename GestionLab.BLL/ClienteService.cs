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
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> ListarClientes()
        {
            try
            {
                IQueryable<Cliente> listaClientes = await _clienteRepository.Consultar();
                List<Cliente> query = listaClientes.Include(c => c.Pacientes).AsEnumerable().ToList();
                return _mapper.Map<List<ClienteDTO>>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ClienteDTO> ListarClienteById(int id)
        {
            try
            {
                IQueryable<Cliente> listaCliente = await _clienteRepository.Consultar(c => c.IdCliente == id);
                Cliente query = listaCliente.Include(c => c.Pacientes).First();
                return _mapper.Map<ClienteDTO>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ClienteDTO> CrearCliente(ClienteDTO cliente)
        {
            try
            {
                Cliente clienteCreado = await _clienteRepository.Crear(_mapper.Map<Cliente>(cliente));
                if (clienteCreado == null) throw new TaskCanceledException("Cliente no pudo ser creado");
                IQueryable<Cliente> BuscarCliente = await _clienteRepository.Consultar(c => c.IdCliente == clienteCreado.IdCliente);
                Cliente query = BuscarCliente.Include(c => c.Pacientes).First();
                return _mapper.Map<ClienteDTO>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarCliente(ClienteDTO cliente)
        {
            try
            {
                bool clienteEditado = await _clienteRepository.Editar(_mapper.Map<Cliente>(cliente));
                if (!clienteEditado) throw new TaskCanceledException("Cliente noencontrado");
                return clienteEditado;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EliminarCliente(int id)
        {
            try
            {
                Cliente listarCliente = await _clienteRepository.Obtener(c => c.IdCliente == id);
                if(listarCliente == null) throw new TaskCanceledException($"El cliente no fue encontrado con el id {id}");
                bool clienteEliminado = await _clienteRepository.Eliminar(listarCliente);
                return clienteEliminado;
            }
            catch
            {
                throw;
            }
        }
    }
}
