using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega
{
    public abstract class ProductoVendido
    {
        protected int Id {  get; set; }
        protected int IdProducto { get; set; }
        protected double Stock { get; set; } //por el mismo motivo que le puse double al stock de la clase producto
        protected int IdVenta { get; set; }

        public ProductoVendido (int id, int idProducto, double stock, int idVenta)
        {
            this.Id = id;
            this.IdProducto = idProducto;
            this.Stock = stock;
            this.IdVenta = idVenta;
        }
    }
}
