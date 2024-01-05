using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ABC.DAL.DBContext;
using ABC.DAL.Repositorios.Contrato;
using ABC.Model;
using Microsoft.EntityFrameworkCore;

namespace ABC.DAL.Repositorios
{
    public class PedidoRepository: GenericRepository<Pedido>, IPedidoRepository
    {
        private readonly DBContext.AbcContext _dbcontext;

      

        public PedidoRepository(AbcContext dbcontext): base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Pedido> Registrar(Pedido modelo)
        {
            Pedido pedidoCreado = new Pedido();

            using(var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    foreach(PedidoProducto pp in modelo.PedidoProductos)
                    {
                        Producto producto_encontrado = _dbcontext.Productos.Where(p => p.IdProducto == pp.IdProducto).First();

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - pp.Cantidad;
                        _dbcontext.Productos.Update(producto_encontrado);
                    }
                    await _dbcontext.SaveChangesAsync();

                    await _dbcontext.Pedidos.AddAsync(modelo);
                    await _dbcontext.SaveChangesAsync();
                    pedidoCreado = modelo;

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;

                }
                return pedidoCreado; 
            }
        }
    }
}
