using System;
using System.Collections.Generic;
using System.Text;
using Appventadominio.Interfaces;

namespace Appventadominio.Interfaces.Repositorios
{
    public interface IRepositorioDetalle<TEntidad, IMovimientoID>
        : IAgregar<TEntidad>, ITransaccion
    {
        public TEntidad SeleccionarPorVentaId(IMovimientoID ventaID);
    }
}
