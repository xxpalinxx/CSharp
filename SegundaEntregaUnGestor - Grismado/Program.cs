

using SegundaEntrega.Database;
using SegundaEntrega.Models;

namespace SegundaEntrega
{
    public class Program
    {
        static void Main(string[] args)
        {
            GestorBaseDatos gbd = new GestorBaseDatos();
            
            try
            {
                Producto productoNuevo = new Producto("Cartera",100.00,350.00,20,5);
                if (gbd.CreateProduct(productoNuevo))
                {
                    Console.WriteLine("Producto Creado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Usuario nuevoUsuario = new Usuario("Estefania", "Dominico", "Stefy", "asdg3asd", "stefy@gmail.com");
                if (gbd.CreateUser(nuevoUsuario))
                {
                    Console.WriteLine("Usuario Creado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                ProductoVendido nuevoProductoVendido = new ProductoVendido(1,5,3);
                if (gbd.CreateProductoVendido(nuevoProductoVendido))
                {
                    Console.WriteLine("ProductoVendido Creado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Venta nuevoVenta = new Venta(1,"Camisa",3);
                if (gbd.CreateVenta(nuevoVenta))
                {
                    Console.WriteLine("Venta Creado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
