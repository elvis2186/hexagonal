using System;
using System.Collections.Generic;
using System.Text;
using Appventadominio.Interfaces;

namespace AppVenta.Aplicaciones.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad,TEntidadID>    
    {
    }
}
