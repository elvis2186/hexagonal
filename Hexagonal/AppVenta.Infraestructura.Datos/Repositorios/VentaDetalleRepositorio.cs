using System;
using System.Collections.Generic;
using System.Text;

using Appventadominio;
using Appventadominio.Interfaces.Repositorios;
using AppVenta.Infraestructura.Datos.Contextos;
using System.Linq;

namespace AppVenta.Infraestructura.Datos.Repositorios
{
    public class VentaDetalleRepositorio : IRepositorioDetalle<VentaDetalle, Guid>
    {
        private VentaContexto db;

        public VentaDetalleRepositorio(VentaContexto db)
        {
            this.db = db;
        }
    
        public VentaDetalle Agregar(VentaDetalle entidad)
        {
            db.VentaDetalles.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public VentaDetalle SeleccionarPorVentaId(Guid ventaID)
        {
            return db.VentaDetalles.Where(x => x.ventaId.Equals(ventaID)).FirstOrDefault();
        }
        
    }
}
