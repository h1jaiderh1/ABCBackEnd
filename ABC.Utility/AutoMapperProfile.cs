using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using ABC.DTO;
using ABC.Model;
using System.Globalization;

namespace ABC.Utility
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Usuario
            //de modelo a dto
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                    destino.IsActive,
                    opt => opt.MapFrom(origen => origen.IsActive == true ? 1 : 0)
            );

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino =>
                    destino.IsActive,
                    opt => opt.MapFrom(origen => origen.IsActive == 1 ? true : false)
            );

            CreateMap<Usuario, SesionDTO>().ReverseMap();



            #endregion

            #region Cliente
            //de modelo a dto
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(destino =>
                    destino.IsActive,
                    opt => opt.MapFrom(origen => origen.IsActive == true ? 1 : 0))
                .ForMember(destino =>
                    destino.FechaActualizacion,
                    opt => opt.MapFrom(origen => origen.FechaActualizacion.Value.ToString("dd/MM/yyyy")))
                .ForMember(destino =>
                    destino.FechaCreacion,
                    opt => opt.MapFrom(origen => origen.FechaCreacion.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<ClienteDTO, Cliente>()
                .ForMember(destino =>
                    destino.IsActive,
                    opt => opt.MapFrom(origen => origen.IsActive == 1 ? true : false)
                    );

            #endregion

            #region Pedido
            //de modelo a dto
            CreateMap<Pedido, PedidoDTO>()
                .ForMember(destino =>
                    destino.IsActive,
                    opt => opt.MapFrom(origen => origen.IsActive == true ? 1 : 0))
                .ForMember(destino =>
                    destino.FechaActualizacion,
                    opt => opt.MapFrom(origen => origen.FechaActualizacion.Value.ToString("dd/MM/yyyy")))
                .ForMember(destino =>
                    destino.FechaCreacion,
                    opt => opt.MapFrom(origen => origen.FechaCreacion.Value.ToString("dd/MM/yyyy")))
                .ForMember(destino =>
                    destino.FechaFacturacion,
                    opt => opt.MapFrom(origen => origen.FechaFacturacion.Value.ToString("dd/MM/yyyy")))
                .ForMember(destino =>
                    destino.FechaCierre,
                    opt => opt.MapFrom(origen => origen.FechaCierre.Value.ToString("dd/MM/yyyy")))
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-CO")))

                );


            //Mapeo de dto a modelo
            CreateMap<PedidoDTO, Pedido>()
                .ForMember(destino =>
                    destino.IsActive,
                    opt => opt.MapFrom(origen => origen.IsActive == 1 ? true : false))
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Total, new CultureInfo("es-CO")))
                );

            #endregion

            #region PedidoProducto
            //de modelo a dto

            CreateMap<PedidoProducto, PedidoProductoDTO>()
                .ForMember(destino =>
                    destino.PrecioUnitario,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.PrecioUnitario.Value, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                    destino.PrecioTotal,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.PrecioTotal.Value, new CultureInfo("es-CO")))
                );

            //Mapeo de dto a modelo

            CreateMap<PedidoProductoDTO, PedidoProducto>()
                .ForMember(destino =>
                    destino.PrecioUnitario,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioUnitario, new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                    destino.PrecioTotal,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTotal, new CultureInfo("es-CO")))
                );

            #endregion

            #region Producto
            //de modelo a dto
            CreateMap<Producto, ProductoDTO>()
                .ForMember(destino =>
                    destino.IsActive,
                    opt => opt.MapFrom(origen => origen.IsActive == true ? 1:0)
                )
                .ForMember(destino =>
                    destino.ValorUnitario,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.ValorUnitario.Value,new CultureInfo("es-CO")))
                )
                .ForMember(destino =>
                    destino.FechaActualizacion,
                    opt => opt.MapFrom(origen => origen.FechaActualizacion.Value.ToString("dd/MM/yyyy"))
                );
            //Mapeo de dto a modelo
            CreateMap<ProductoDTO, Producto>()
                .ForMember(destino =>
                    destino.IsActive,
                    opt => opt.MapFrom(origen => origen.IsActive == 1 ? true : false)
                )
                .ForMember(destino =>
                    destino.ValorUnitario,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.ValorUnitario, new CultureInfo("es-CO")))
                );

            #endregion
        }
    }
}
