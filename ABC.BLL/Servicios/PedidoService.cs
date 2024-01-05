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
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace ABC.BLL.Servicios
{
    public class PedidoService:IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepositorio;
        private readonly IGenericRepository<PedidoProducto> _pedidoProductoRepositorio;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepositorio, IGenericRepository<PedidoProducto> pedidoProductoRepositorio, IMapper mapper)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _pedidoProductoRepositorio = pedidoProductoRepositorio;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> Registrar(PedidoDTO modelo)
        {
            try
            {
                var pedidoGenerado = await _pedidoRepositorio.Registrar(_mapper.Map<Pedido>(modelo));

                if (pedidoGenerado.IdPedido == 0)
                    throw new TaskCanceledException("No se pudo crear");

                return _mapper.Map<PedidoDTO>(pedidoGenerado);
            }
            catch 
            {
                throw;
            }
        }        
        // public async Task<List<PedidoDTO>> Historial(string buscarPor, string numeroPedido, string fechaInicio, string fechaFin)
        //{
        //    IQueryable<Pedido> query = await _pedidoRepositorio.Consultar();
        //    var ListaResultado = new List<Pedido>();

        //    try
        //    {
        //        if(buscarPor == "fecha")
        //        {
        //            DateTime fecha_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-CO"));
        //            DateTime fecha_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-CO"));

        //            ListaResultado = await query.Where(v =>
        //                v.FechaCreacion.Value.Date >= fecha_Inicio.Date &&
        //                v.FechaCreacion.Value.Date <= fecha_Fin.Date
                        
        //            ).Include(pp => pp.PedidoProductos)
        //             .ThenInclude(p => p.IdProductoNavigation)
        //             .ToListAsync();
        //        }
        //        else
        //        {
                   
        //            ListaResultado = await query.Where(v => v.IdPedido == numeroPedido

        //            ).Include(pp => pp.PedidoProductos)
        //             .ThenInclude(p => p.IdProductoNavigation)
        //             .ToListAsync();
        //        }
        //    }
        //    catch 
        //    {

        //        throw;
        //    }
        //}

        
    }
}
