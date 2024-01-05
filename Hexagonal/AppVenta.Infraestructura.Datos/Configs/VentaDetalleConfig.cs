using System;
using System.Collections.Generic;
using System.Text;
using Appventadominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVenta.Infraestructura.Datos.Configs
{
    public class VentaDetalleConfig : IEntityTypeConfiguration<VentaDetalle>
    {
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {
            builder.ToTable("tblVentaDetalles");
            builder.HasKey(x=> new {x.productoId, x.ventaId});

            builder.HasOne(detalle => detalle.Producto)
                .WithMany(producto => producto.VentaDetalles);

            builder.HasOne(detalle => detalle.Venta)
                .WithMany(venta => venta.VentaDetalles);
        }
    }
}
