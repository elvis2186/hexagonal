using System;
using System.Collections.Generic;
using System.Text;

namespace Appventadominio.Interfaces
{
    public interface IAgregar<TEntidad>
    {
        TEntidad Agregar(TEntidad entidad);
    }
}
