using System;
using System.Collections.Generic;
using System.Text;
using Appventadominio.Interfaces;

namespace Appventadominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IEditar<TEntidad>,
          IEliminar<TEntidadID>, IListar<TEntidad,TEntidadID>,
          ITransaccion
    {

    }
}
