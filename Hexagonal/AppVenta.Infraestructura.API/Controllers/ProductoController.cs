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
    public class ProductoController : ControllerBase
    {        
        private readonly AppVenta.Aplicaciones.Interfaces.IServicioBase<Producto,Guid> _ser;

        public ProductoController(Aplicaciones.Interfaces.IServicioBase<Producto, Guid> ser)
        {
            _ser = ser;
        }

        //ProductoServicio CrearServicio()
        //{            
        //    ProductoRepositorio repo = new ProductoRepositorio(_db);            
        //    ProductoServicio servicio = new ProductoServicio(repo);
        //    return servicio;
        //}

        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            //var servicio = CrearServicio();
            return Ok(_ser.Listar());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            //var servicio = CrearServicio();
            return Ok(_ser.SeleccionarPorId(id));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            //var servicio = CrearServicio();
            _ser.Agregar(producto);
            return Ok("Se inserto producto");
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto producto)
        {
            //var servicio = CrearServicio();
            producto.productoId = id;
            _ser.Editar(producto);
            return Ok("Se edito el producto");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            //var servicio = CrearServicio();
            _ser.Eliminar(id);
            return Ok("Producto eliminado");
        }
    }
}
