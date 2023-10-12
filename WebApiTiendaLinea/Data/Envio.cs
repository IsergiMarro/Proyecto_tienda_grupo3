using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;


namespace WebApiTiendaLinea.Data
{
    public class Envio
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsEnvio2 envio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudEnvio", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_estado", envio.id_estado);
                    cmd.Parameters.AddWithValue("@id_persona", envio.id_persona);
                    cmd.Parameters.AddWithValue("@direccion_envio", envio.direccion_envio);
                    cmd.Parameters.AddWithValue("@id_pedido", envio.id_pedido);
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

        public static bool Actualizar(clsEnvio envio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudEnvio", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_envio", envio.id_envio);
                    cmd.Parameters.AddWithValue("@id_estado", envio.id_estado);
                    cmd.Parameters.AddWithValue("@id_persona", envio.id_persona);
                    cmd.Parameters.AddWithValue("@direccion_envio", envio.direccion_envio);
                    cmd.Parameters.AddWithValue("@id_pedido", envio.id_pedido);
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

                    SqlCommand cmd = new SqlCommand("crudEnvio", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_envio", id);
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

        public static List<clsEnvio> Listar()
        {
            List<clsEnvio> lstEnvios = new List<clsEnvio>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudEnvio", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsEnvio envio = new clsEnvio();
                            envio.id_envio = Convert.ToInt32(dr["id_envio"]);
                            envio.id_estado = Convert.ToInt32(dr["id_estado"]);
                            envio.id_persona = Convert.ToInt32(dr["id_persona"]);
                            envio.direccion_envio = dr["direccion_envio"].ToString();
                            envio.id_pedido = Convert.ToInt32(dr["id_pedido"]);
                            lstEnvios.Add(envio);
                        }
                    }

                    return lstEnvios;
                }
                catch (Exception)
                {
                    return lstEnvios;
                }
            }
        }
    }
}
