using System;
using System.Collections.Generic;
using System.Text;

namespace Appventadominio.Interfaces
{
    public interface IEditar<TEntidad>
    {
        public void Editar(TEntidad entidad);
    }
}
