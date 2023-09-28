using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class DetalleCarritoComprasData
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsDetalleCarritoCompras detalleCarrito)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDetalleCarritoCompras", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_carrito_compras", detalleCarrito.Carrito);
                    cmd.Parameters.AddWithValue("@id_producto", detalleCarrito.Producto);
                    cmd.Parameters.AddWithValue("@cantidad", detalleCarrito.Cantidad);
                    cmd.Parameters.AddWithValue("@subtotal", detalleCarrito.SubTotal);
                    cmd.Parameters.AddWithValue("@total", detalleCarrito.Total);
                    cmd.Parameters.AddWithValue("@id_persona", detalleCarrito.Persona);
                    cmd.Parameters.AddWithValue("@opcion", 1);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar el detalle del carrito de compras: {ex.Message}");
                    return false;
                }
            }
        }

        public static bool Actualizar(clsDetalleCarritoCompras detalleCarrito)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDetalleCarritoCompras", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_detalle_carrito_compras", detalleCarrito.Id);
                    cmd.Parameters.AddWithValue("@id_carrito_compras", detalleCarrito.Carrito);
                    cmd.Parameters.AddWithValue("@id_producto", detalleCarrito.Producto);
                    cmd.Parameters.AddWithValue("@cantidad", detalleCarrito.Cantidad);
                    cmd.Parameters.AddWithValue("@subtotal", detalleCarrito.SubTotal);
                    cmd.Parameters.AddWithValue("@total", detalleCarrito.Total);
                    cmd.Parameters.AddWithValue("@id_persona", detalleCarrito.Persona);
                    cmd.Parameters.AddWithValue("@opcion", 2);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el detalle del carrito de compras: {ex.Message}");
                    return false;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDetalleCarritoCompras", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_detalle_carrito_compras", id);
                    cmd.Parameters.AddWithValue("@opcion", 3);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar el detalle del carrito de compras: {ex.Message}");
                    return false;
                }
            }
        }

        public static List<clsDetalleCarritoCompras> Listar()
        {
            List<clsDetalleCarritoCompras> lstDetalleCarrito = new List<clsDetalleCarritoCompras>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDetalleCarritoCompras", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsDetalleCarritoCompras detalleCarrito = new clsDetalleCarritoCompras();
                            detalleCarrito.Id = Convert.ToInt32(dr["id_detalle_carrito_compras"]);
                            detalleCarrito.Carrito = Convert.ToInt32(dr["id_carrito_compras"]);
                            detalleCarrito.Producto = Convert.ToInt32(dr["id_producto"]);
                            detalleCarrito.Cantidad = Convert.ToInt32(dr["cantidad"]);
                            detalleCarrito.SubTotal = Convert.ToDecimal(dr["subtotal"]);
                            detalleCarrito.Total = Convert.ToDecimal(dr["total"]);
                            detalleCarrito.Persona = Convert.ToInt32(dr["id_persona"]);
                            lstDetalleCarrito.Add(detalleCarrito);
                        }
                    }

                    return lstDetalleCarrito;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al listar los detalles del carrito de compras: {ex.Message}");
                    return lstDetalleCarrito;
                }
            }
        }
    }
}
