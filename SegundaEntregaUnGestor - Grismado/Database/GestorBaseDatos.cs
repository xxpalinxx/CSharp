using SegundaEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaEntrega.Database
{
    internal class GestorBaseDatos
    {
        private string connectionString;

        public GestorBaseDatos()
        {
            connectionString = "Server=.;Database=SistemaGestion;Trusted_Connection=True;";
        }
        //PRODUCTOS
        public bool DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Producto WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public bool CreateProduct(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" +
                    "VALUES(@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Descripciones", producto.Descripcion);
                command.Parameters.AddWithValue("@Costo", producto.Costo);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public Producto GetProductByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["Id"]);
                    string descripcion = reader["Descripciones"].ToString();
                    double costo = Convert.ToDouble(reader["Costo"]);
                    double precioVenta = Convert.ToDouble(reader["PrecioVenta"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    Producto producto = new Producto(productId, descripcion, costo, precioVenta, stock, idUsuario);
                    return producto;
                }
                throw new Exception("Id no encontrado");
            }
        }
        public bool UpdateProduct(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Descripciones", producto.Descripcion);
                command.Parameters.AddWithValue("@Costo", producto.Costo);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public List<Producto> ListaProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();
                            producto.Id = Convert.ToInt32(reader["Id"]);
                            producto.Descripcion = reader["Descripciones"].ToString();
                            producto.Costo = Convert.ToDouble(reader["Costo"]);
                            producto.PrecioVenta = Convert.ToDouble(reader["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(reader["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                            listaProductos.Add(producto);
                        }
                    }
                }
                return listaProductos;
            }
        }
        //PRODUCTO VENDIDO
        public bool DeleteProductoVendido(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ProductoVendido WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
        public bool CreateProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProductoVendido(Stock,IdProducto,IdVenta)" +
                    "VALUES(@Stock,@IdProducto,@IdVenta)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public ProductoVendido GetProductoVendidoByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int productoVendidoId = Convert.ToInt32(reader["Id"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idProducto = Convert.ToInt32(reader["IdProducto"]);
                    int idVenta = Convert.ToInt32(reader["IdVenta"]);
                    ProductoVendido productoVendido = new ProductoVendido(productoVendidoId, stock, idProducto, idVenta);
                    return productoVendido;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public bool UpdateProductoVendido(int id, ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductoVendido SET Stock = @Stock, IdProducto = @IdProducto, IdVenta = @IdVenta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<ProductoVendido> ListaProductoVendido()
        {
            List<ProductoVendido> listaProductoVendido = new List<ProductoVendido>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ProductoVendido";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductoVendido productoVendido = new ProductoVendido();
                            productoVendido.Id = Convert.ToInt32(reader["Id"]);
                            productoVendido.Stock = Convert.ToInt32(reader["Stock"]);
                            productoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                            productoVendido.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                            listaProductoVendido.Add(productoVendido);
                        }
                    }
                }
                return listaProductoVendido;
            }
        }
        //USUARIOS
        public bool DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool CreateUser(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuario(Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                    "VALUES(@nombre, @apellido, @nombreUsuario, @contraseña, @mail)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("@mail", usuario.Mail);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public Usuario GetUserByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["Id"]);
                    string nombre = reader["Nombre"].ToString();
                    string apellido = reader["Apellido"].ToString();
                    string nombreUsuario = reader["NombreUsuario"].ToString();
                    string contraseña = reader["Contraseña"].ToString();
                    string mail = reader["Mail"].ToString();
                    Usuario usuario = new Usuario(userId, nombre, apellido, nombreUsuario, contraseña, mail);
                    return usuario;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public bool UpdateUser(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contraseña = @contraseña, Mail = @mail WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("@mail", usuario.Mail);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuario";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(reader["Id"]);
                            usuario.Nombre = reader["Nombre"].ToString();
                            usuario.Apellido = reader["Apellido"].ToString();
                            usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                            usuario.Contraseña = reader["Contraseña"].ToString();
                            usuario.Mail = reader["Mail"].ToString();
                            listaUsuarios.Add(usuario);
                        }
                    }
                }
                return listaUsuarios;
            }
        }
        //VENTAS
        public bool DeleteVenta(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Venta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool CreateVenta(Venta venta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Venta(Comentarios, IdUsuario)" +
                    "VALUES(@Comentarios, @IdUsuario)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public Venta GetVentaByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Venta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int ventaId = Convert.ToInt32(reader["Id"]);
                    string comentarios = reader["Comentarios"].ToString();
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    Venta venta = new Venta(ventaId, comentarios, idUsuario);
                    return venta;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public bool UpdateVenta(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Venta> ListaVenta()
        {
            List<Venta> listaVenta = new List<Venta>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Venta";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venta venta = new Venta();
                            venta.Id = Convert.ToInt32(reader["Id"]);
                            venta.Comentarios = reader["Comentarios"].ToString();
                            venta.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                            listaVenta.Add(venta);
                        }
                    }
                }
                return listaVenta;
            }
        }
    }
}
