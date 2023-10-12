using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class CuponData
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsCupon2 cupon)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudCupones", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo_cupon", cupon.CodigoCupon);
                    cmd.Parameters.AddWithValue("@descuento", cupon.Descuento);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", cupon.FechaVencimiento);
                    cmd.Parameters.AddWithValue("@id_producto", cupon.IdProducto);
                    cmd.Parameters.AddWithValue("@fecha_canjeo", cupon.FechaCanjeo);
                    cmd.Parameters.AddWithValue("@id_persona", cupon.IdPersona);
                    cmd.Parameters.AddWithValue("@id_estado", cupon.IdEstado);
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

        public static bool Actualizar(clsCupon cupon)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudCupones", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_cupon", cupon.IdCupon);
                    cmd.Parameters.AddWithValue("@codigo_cupon", cupon.CodigoCupon);
                    cmd.Parameters.AddWithValue("@descuento", cupon.Descuento);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", cupon.FechaVencimiento);
                    cmd.Parameters.AddWithValue("@id_producto", cupon.IdProducto);
                    cmd.Parameters.AddWithValue("@fecha_canjeo", cupon.FechaCanjeo);
                    cmd.Parameters.AddWithValue("@id_persona", cupon.IdPersona);
                    cmd.Parameters.AddWithValue("@id_estado", cupon.IdEstado);
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

                    SqlCommand cmd = new SqlCommand("crudCupones", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_cupon", id);
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

        public static List<clsCupon> Listar()
        {
            List<clsCupon> lstCupones = new List<clsCupon>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudCupones", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsCupon cupon = new clsCupon();
                            cupon.IdCupon = Convert.ToInt32(dr["id_cupon"]);
                            cupon.CodigoCupon = dr["codigo_cupon"].ToString();
                            cupon.Descuento = Convert.ToInt32(dr["descuento"]);
                            cupon.FechaVencimiento = Convert.ToDateTime(dr["fecha_vencimiento"]);
                            cupon.IdProducto = Convert.ToInt32(dr["id_producto"]);
                            cupon.FechaCanjeo = Convert.ToDateTime(dr["fecha_canjeo"]);
                            cupon.IdPersona = Convert.ToInt32(dr["id_persona"]);
                            cupon.IdEstado = Convert.ToInt32(dr["id_estado"]);
                            lstCupones.Add(cupon);
                        }
                    }

                    return lstCupones;
                }
                catch (Exception)
                {
                    return lstCupones;
                }
            }
        }
    }
}
