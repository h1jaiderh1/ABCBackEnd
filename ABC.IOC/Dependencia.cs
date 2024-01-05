using ABC.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ABC.Utility;

using ABC.DAL.Repositorios.Contrato;
using ABC.DAL.Repositorios;
using Microsoft.Identity.Client;
using ABC.BLL.Servicios.Contratos;
using ABC.BLL.Servicios;

namespace ABC.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AbcContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<DbContext, AbcContext>();
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

    }
}
