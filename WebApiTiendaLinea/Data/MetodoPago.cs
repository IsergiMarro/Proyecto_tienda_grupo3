using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class MetodoPago
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsMetodoPago2 MetodoPago)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudMetodosPagos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                   /// cmd.Parameters.AddWithValue("@id_metodo_pago", MetodoPago.Id);
                    cmd.Parameters.AddWithValue("@metodo", MetodoPago.Metodo);
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

        public static bool Actualizar(clsMetodoPago MetodoPago)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudMetodosPagos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_metodo_pago", MetodoPago.Id);
                    cmd.Parameters.AddWithValue("@metodo", MetodoPago.Metodo);
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

                    SqlCommand cmd = new SqlCommand("crudMetodosPagos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_metodo_pago", id);
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

        public static List<clsMetodoPago> Listar()
        {
            List<clsMetodoPago> lstMetodoPago = new List<clsMetodoPago>();

            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudMetodosPagos", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion", 4);

                try
                {
                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsMetodoPago MetodoPago = new clsMetodoPago();

                            int id;
                            if (int.TryParse(dr["id_metodo_pago"].ToString(), out id))
                                MetodoPago.Id = id;

                            MetodoPago.Metodo = dr["metodo"].ToString();
                            lstMetodoPago.Add(MetodoPago);

                        }
                        return lstMetodoPago;
                    }
                }
                catch (SqlException ex)
                {
                    lstMetodoPago.Add(new clsMetodoPago()
                    {
                    //    Error = ex.Message
                    });
                    return lstMetodoPago;
                }
            }
        }


    }
}