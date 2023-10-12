using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class Comentarios
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsComentarios2 comentario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudComentarios", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", comentario.Descripcion);
                    cmd.Parameters.AddWithValue("@id_persona", comentario.Persona);
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

        public static bool Actualizar(clsComentarios comentario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudComentarios", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", comentario.Id);
                    cmd.Parameters.AddWithValue("@descripcion", comentario.Descripcion);
                    cmd.Parameters.AddWithValue("@id_persona", comentario.Persona);
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

                    SqlCommand cmd = new SqlCommand("crudComentarios", connection);
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

        public static List<clsComentarios> Listar()
        {
            List<clsComentarios> lstComentarios = new List<clsComentarios>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudComentarios", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsComentarios comentario = new clsComentarios();
                            comentario.Id = Convert.ToInt32(dr["id_comentario"]);
                            comentario.Descripcion = dr["descripcion"].ToString();
                            comentario.Persona = Convert.ToInt32(dr["id_persona"]);
                            lstComentarios.Add(comentario);
                        }
                    }

                    return lstComentarios;
                }
                catch (Exception)
                {
                    return lstComentarios;
                }
            }
        }
    }
}
