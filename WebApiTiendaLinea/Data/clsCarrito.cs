using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class CarritosDeCompras
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsCarrito carrito)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudCarritosDeCompras", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_persona", carrito.id_persona);
                    cmd.Parameters.AddWithValue("@id_detalle_carrito_compras", carrito.id_detalle_carrito_compras);
                    cmd.Parameters.AddWithValue("@opcion", 1);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool Actualizar(clsCarrito carrito)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudCarritosDeCompras", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", carrito.id_carrito_compras);
                    cmd.Parameters.AddWithValue("@id_persona", carrito.id_persona);
                    cmd.Parameters.AddWithValue("@id_detalle_carrito_compras", carrito.id_detalle_carrito_compras);
                    cmd.Parameters.AddWithValue("@opcion", 2);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
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

                    SqlCommand cmd = new SqlCommand("crudCarritosDeCompras", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@opcion", 3);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static List<clsCarrito> Listar()
        {
            List<clsCarrito> lstCarritos = new List<clsCarrito>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudCarritosDeCompras", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsCarrito carrito = new clsCarrito();
                            carrito.id_carrito_compras = Convert.ToInt32(dr["id_carrito_compras"]);
                            carrito.id_persona = Convert.ToInt32(dr["id_persona"]);
                            carrito.id_detalle_carrito_compras = Convert.ToInt32(dr["id_detalle_carrito_compras"]);
                            lstCarritos.Add(carrito);
                        }
                    }

                    return lstCarritos;
                }
                catch (Exception)
                {
                    return lstCarritos;
                }
            }
        }
    }
}
