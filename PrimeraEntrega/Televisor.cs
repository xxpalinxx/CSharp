using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega
{
    public class Televisor : Producto
    {
        public Televisor(int id, string descripcion, double costo, double precioVenta, double stock, int idUsuario) : base(id, descripcion, costo, precioVenta, stock, idUsuario)
        {
        }
    }
}
