﻿using System;
using System.Collections.Generic;
using System.Text;
using Appventadominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVenta.Infraestructura.Datos.Configs
{
    public class ProductoConfig: IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("tblProductos");
            builder.HasKey(c => c.productoId);

            builder.HasMany(producto => producto.VentaDetalles)
                .WithOne(detalle => detalle.Producto);
        }
    }
}
