using System;
using System.Collections.Generic;
using System.Text;
using Appventadominio;
using Appventadominio.Interfaces.Repositorios;
using AppVenta.Aplicaciones.Interfaces;

namespace AppVenta.Aplicaciones.Servicios
{
    public class VentaServicios : IServicioMovimiento<Venta, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> repoProducto;
        private readonly IRepositorioMovimiento<Venta, Guid> repoVenta;
        private readonly IRepositorioDetalle<VentaDetalle, Guid> _repoDetalle;

        public VentaServicios(
            IRepositorioBase<Producto, Guid> repoProducto,
            IRepositorioMovimiento<Venta, Guid> repoVenta,
            IRepositorioDetalle<VentaDetalle, Guid> repoDetalle)
        {
            this.repoProducto = repoProducto;
            this.repoVenta = repoVenta;
            _repoDetalle = repoDetalle;
        }

        public Venta Agregar(Venta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("la venta es requerida");
            //aqui agrega una venta
            var ventaAgregada = repoVenta.Agregar(entidad);
            entidad.VentaDetalles.ForEach(detalle =>
            {
                //buscando el producto
                var productoSeleccionado = repoProducto.SeleccionarPorId(detalle.productoId);
                if (productoSeleccionado == null)
                    throw new NullReferenceException("esta intentando vender un producto que no existe");

                //se agrega al detalle
                //var detalleNuevo = new VentaDetalle();
                //detalleNuevo.ventaId = ventaAgregada.ventaId;
                //detalleNuevo.productoId = detalle.productoId;
                detalle.costoUnitario = productoSeleccionado.costo;
                detalle.precioUnitario = productoSeleccionado.precio;
                //detalleNuevo.cantidadVendida = detalle.cantidadVendida;
                detalle.subtotal = detalle.precioUnitario * detalle.cantidadVendida;
                detalle.impuesto = detalle.subtotal * 7 / 100;
                detalle.total = detalle.subtotal + detalle.impuesto;
                _repoDetalle.Agregar(detalle);

                //se reduce del inventario de producto y se actualiza
                productoSeleccionado.cantidadEnStock -= detalle.cantidadVendida;
                repoProducto.Editar(productoSeleccionado);

                //devuelve la entidad aumentada en subtotal impuesto y total
                entidad.subTotal += detalle.subtotal;
                entidad.impuesto += detalle.impuesto;
                entidad.total += detalle.total;
            });
            repoVenta.GuardarTodosLosCambios();
            return entidad;
        }

        public void Anular(Guid entidadID)
        {
            repoVenta.Anular(entidadID);
            // si se anula entonces debe devolver el producto al inventario            
            var detalle = _repoDetalle.SeleccionarPorVentaId(entidadID);
            var productoSeleccionado = repoProducto.SeleccionarPorId(detalle.productoId);
            if (productoSeleccionado == null)
                throw new NullReferenceException("no hay producto en la venta");

            //regresa el producto al inventario y actualiza el producto
            productoSeleccionado.cantidadEnStock += detalle.cantidadVendida;
            repoProducto.Editar(productoSeleccionado);

            repoVenta.GuardarTodosLosCambios();
        }

        public List<Venta> Listar()
        {
            return repoVenta.Listar();
        }

        public Venta SeleccionarPorId(Guid entidadID)
        {
            return repoVenta.SeleccionarPorId((Guid)entidadID);
        }
    }
}
