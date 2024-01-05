using System;
using System.Collections.Generic;
using System.Text;
using Appventadominio;
using Appventadominio.Interfaces.Repositorios;
using AppVenta.Aplicaciones.Interfaces;

namespace AppVenta.Aplicaciones.Servicios
{
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> repoProducto;

        public ProductoServicio(IRepositorioBase<Producto, Guid> repoProducto)
        {
            this.repoProducto = repoProducto;
        }

        public Producto Agregar(Producto entidad)
        {
            if(entidad == null)
                throw new ArgumentNullException("El producto es requerido");
            var resultProducto = repoProducto.Agregar(entidad);
            repoProducto.GuardarTodosLosCambios();
            return resultProducto;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El producto es requerido para editar");
            repoProducto.Editar(entidad);
            repoProducto.GuardarTodosLosCambios();         
        }

        public void Eliminar(Guid entidadId)
        {
            repoProducto.Eliminar(entidadId);
            repoProducto.GuardarTodosLosCambios();
        }

        public List<Producto> Listar()
        {
            return repoProducto.Listar();
        }

        public Producto SeleccionarPorId(Guid entidadID)
        {
            return repoProducto.SeleccionarPorId(entidadID);
        }
    }
}
