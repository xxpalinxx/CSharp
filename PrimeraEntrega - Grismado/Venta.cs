using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega
{
    public abstract class Venta
    {
        protected int Id { get; set; }
        protected string Comentarios { get; set; }
        protected int IdUsuario { get; set; }

        public Venta (int id, string comentarios, int idUsuario)
        {
            this.Id = id;
            this.Comentarios = comentarios;
            this.IdUsuario = idUsuario;
        }
    }
}
