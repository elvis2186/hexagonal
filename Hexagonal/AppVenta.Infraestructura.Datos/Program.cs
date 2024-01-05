using System;
using AppVenta.Infraestructura.Datos.Contextos;

namespace AppVenta.Infraestructura.Datos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("creando la db!");
            VentaContexto db = new VentaContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("se creo la db!");
            Console.ReadKey();
        }
    }
}
