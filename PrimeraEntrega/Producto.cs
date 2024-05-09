using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega
{
    public abstract class Producto
    {
        protected int Id { get; set; }
        protected string Descripcion { get; set; }
        protected double Costo { get; set; }
        protected double PrecioVenta { get; set; }
        protected double Stock { get; set; } // por el momento le pongo double porque puede haber productos que se stockeen por kilo... cuando sepa bien de que va el proyecto modifico si es necesario
        protected int IdUsuario { get; set; }

        public Producto(int id, string descripcion, double costo, double precioVenta, double stock, int idUsuario)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.PrecioVenta = precioVenta;
            this.Stock = stock;
            this.IdUsuario = idUsuario;
        }

    }
}
