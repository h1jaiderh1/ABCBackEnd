using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using ABC.BLL.Servicios.Contratos;
using ABC.DAL.Repositorios.Contrato;
using ABC.DTO;
using ABC.Model;

namespace ABC.BLL.Servicios
{
    public class ClienteService:IClienteService
    {
        private readonly IGenericRepository<Cliente> _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> Lista()
        {
            try
            {
                var queryProducto = await _clienteRepositorio.Consultar();

                var listaClientes = queryProducto.ToList();

                return _mapper.Map<List<ClienteDTO>>(listaClientes.ToList());
            }
            catch
            {

                throw;
            }
        }

        public async Task<ClienteDTO> Crear(ClienteDTO modelo)
        {
            try
            {
                var clienteCreado = await _clienteRepositorio.Crear(_mapper.Map<Cliente>(modelo));

                if (clienteCreado.IdCliente == 0)
                    throw new TaskCanceledException("No se pudo crear");

                return _mapper.Map<ClienteDTO>(clienteCreado);
            }
            catch 
            {

                throw;
            }
        }

        public async Task<bool> Editar(ClienteDTO modelo)
        {
            try
            {
                var clienteModelo = _mapper.Map<Cliente>(modelo);

                var clienteEncontrado = await _clienteRepositorio.Obtener(u =>
                    u.IdCliente == clienteModelo.IdCliente
                );

                if (clienteEncontrado == null)
                    throw new TaskCanceledException("el cliente no existe");
                clienteEncontrado.Telefono = clienteModelo.Telefono;
                clienteEncontrado.Tipo = clienteModelo.Tipo;
                clienteEncontrado.Correo = clienteModelo.Correo;
                clienteEncontrado.Direccion = clienteModelo.Direccion;
                clienteEncontrado.Barrio = clienteModelo.Barrio;
                clienteEncontrado.Ciudad = clienteModelo.Ciudad;
                clienteEncontrado.Departamento = clienteModelo.Departamento;
                clienteEncontrado.IsActive = clienteModelo.IsActive;
                clienteEncontrado.FechaActualizacion = DateTime.Now.Date;
                clienteEncontrado.NumeroDocumento = clienteModelo.NumeroDocumento;

                bool respuesta = await _clienteRepositorio.Editar(clienteEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("El cliente no se pudo editar");

                return respuesta;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var clienteEncontrado = await _clienteRepositorio.Obtener(u => u.IdCliente == id);

                if (clienteEncontrado == null)
                    throw new TaskCanceledException("El cliente no existe");

                bool respuesta = await _clienteRepositorio.Eliminar(clienteEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar el cliente");

                return respuesta;
            }
            catch
            {

                throw;
            }
        }

        
    }
}
