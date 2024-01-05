using System;
using System.Collections.Generic;
using System.Text;
using Appventadominio.Interfaces;

namespace Appventadominio.Interfaces.Repositorios
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad,TEntidadID>, ITransaccion
    {
        void Anular(TEntidadID entidadID);
    }
}
