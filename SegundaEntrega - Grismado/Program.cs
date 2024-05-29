


using SegundaEntrega.Database;
using SegundaEntrega.Models;

namespace SegundaEntrega
{
    public class Program
    {
        static void Main(string[] args)
        {
            GestorBaseDeDatos gestorBaseDeDatos = new GestorBaseDeDatos();
            try
            {
                Usuario nuevoUsuario = new Usuario("Osvaldo", "Pescado", "Fishvaldo", "123asd", "fisher@gmail.com");
                if (gestorBaseDeDatos.CreateUser(nuevoUsuario))
                {
                    Console.WriteLine("Usuario Creado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            try
            {
                Producto nuevoProducto = new Producto("Pollera", 100.00, 250.00, 14, 4);
                if (gestorBaseDeDatos.CreateProduct(nuevoProducto))
                {
                    Console.WriteLine("Producto agregado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}