using Microsoft.AspNetCore.Mvc;

using Appventadominio;
using AppVenta.Aplicaciones.Servicios;
using AppVenta.Infraestructura.Datos.Contextos;
using AppVenta.Infraestructura.Datos.Repositorios;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppVenta.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly AppVenta.Aplicaciones.Interfaces.IServicioMovimiento<Venta, Guid> _ser;
        //private readonly VentaContexto _db;

        public VentaController(Aplicaciones.Interfaces.IServicioMovimiento<Venta, Guid> ser)
        {
            _ser = ser;
        }

        //VentaServicios CrearServicio()
        //{            
        //    VentaRepositorio repo = new VentaRepositorio(_db);
        //    ProductoRepositorio repoProducto = new ProductoRepositorio(_db);
        //    VentaDetalleRepositorio repoDetalle = new VentaDetalleRepositorio(_db);
        //    VentaServicios servicio = new VentaServicios(repoProducto,repo,repoDetalle);
        //    return servicio;
        //}

        // GET: api/<VentaController>
        [HttpGet]
        public ActionResult<List<Venta>> Get()
        {
            //var servicioCreado = CrearServicio();
            return Ok(_ser.Listar());
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public ActionResult<Venta> Get(Guid id)
        {
            //var servicio = CrearServicio();
            return Ok(_ser.SeleccionarPorId(id));
        }

        // POST api/<VentaController>
        [HttpPost]
        public ActionResult Post([FromBody] Venta venta)
        {
            //var servicio = CrearServicio();
            _ser.Agregar(venta);
            return Ok("Se inserto venta");
        }
                
        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            //var servicio = CrearServicio();
            _ser.Anular(id);
            return Ok("venta anulada");
        }
    }
}
