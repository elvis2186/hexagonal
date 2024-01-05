using System;
using System.Collections.Generic;
using System.Text;

namespace Appventadominio.Interfaces
{
    public interface IListar<TEntidad, TEntidadID>
    {
        public List<TEntidad> Listar();
        TEntidad SeleccionarPorId(TEntidadID entidadID);
    }
}
