using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Appventadominio;
using Appventadominio.Interfaces.Repositorios;
using AppVenta.Infraestructura.Datos.Contextos;
using Microsoft.EntityFrameworkCore;


namespace AppVenta.Infraestructura.Datos.Repositorios
{
    public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid>
    {
        private VentaContexto db;

        public VentaRepositorio(VentaContexto db)
        {
            this.db = db;
        }

        public Venta Agregar(Venta entidad)
        {
            entidad.ventaId = Guid.NewGuid();
            db.Ventas.Add(entidad);
            return entidad;
        }

        public void Anular(Guid entidadID)
        {
            var ventaSeleccionada = db.Ventas.Where(x => x.ventaId == entidadID).FirstOrDefault();
            if (ventaSeleccionada == null)
                throw new NullReferenceException("Intentando anular venta inexistente");
            ventaSeleccionada.anulado = true;
            db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Venta> Listar()
        {
            return db.Ventas.ToList();
        }

        public Venta SeleccionarPorId(Guid entidadID)
        {
            return db.Ventas.Where(x => x.ventaId == entidadID).Select(x => x).FirstOrDefault();             
        }
    }
}
