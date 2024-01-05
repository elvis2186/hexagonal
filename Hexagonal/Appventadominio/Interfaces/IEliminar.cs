using System;
using System.Collections.Generic;
using System.Text;

namespace Appventadominio.Interfaces
{
    public interface IEliminar<TEntidadID>
    {
        public void Eliminar(TEntidadID entidadId);
    }
}
