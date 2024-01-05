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
using Microsoft.EntityFrameworkCore;

namespace ABC.BLL.Servicios
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioService(IGenericRepository<Usuario> usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }
        public async Task<List<UsuarioDTO>> Lista()
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar();
                var listaUsuarios = queryUsuario.ToList();

                return _mapper.Map<List<UsuarioDTO>>(listaUsuarios);
            }
            catch 
            {

                throw;
            }

        }

        public async Task<SesionDTO> ValidarCredenciales(string usuario, string clave)
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar(u =>
                u.Usuario1 == usuario && u.Contrasena == clave
            );

                if (queryUsuario.FirstOrDefault() == null)
                    throw new TaskCanceledException("El usuario no existe");
                Usuario devolverUsuario = queryUsuario.First();
                return _mapper.Map<SesionDTO>(devolverUsuario);
            }
            catch 
            {

                throw;
            }
            
        }
        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
                var usuarioCreado = await _usuarioRepositorio.Crear(_mapper.Map<Usuario>(modelo));

                if (usuarioCreado.IdUsuario == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _usuarioRepositorio.Consultar(u => u.IdUsuario == usuarioCreado.IdUsuario);

                usuarioCreado = query.First();

                return _mapper.Map<UsuarioDTO>(usuarioCreado);

            }
            catch 
            {

                throw;
            }
        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var usuarioModelo = _mapper.Map<Usuario>(modelo);

                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.IdUsuario == usuarioModelo.IdUsuario);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                usuarioEncontrado.Nombres = usuarioModelo.Nombres;
                usuarioEncontrado.Usuario1 = usuarioModelo.Usuario1;
                usuarioEncontrado.Contrasena = usuarioModelo.Contrasena;
                usuarioEncontrado.IsActive = usuarioEncontrado.IsActive;
                usuarioEncontrado.Apellidos = usuarioEncontrado.Apellidos;
                usuarioEncontrado.IdentificacionCiudadania = usuarioEncontrado.IdentificacionCiudadania;

                bool respuesta = await _usuarioRepositorio.Editar(usuarioEncontrado);

                if(!respuesta)
                    throw new TaskCanceledException("No se pudo editar el usuario");

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
                var usuarioEncontrado = await _usuarioRepositorio.Obtener(u => u.IdUsuario == id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool respuesta = await _usuarioRepositorio.Eliminar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar el usuario");

                return respuesta;
            }
            catch 
            {

                throw;
            }
            

        }


    }
}
