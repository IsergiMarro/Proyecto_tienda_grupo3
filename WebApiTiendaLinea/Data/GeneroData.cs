using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class GeneroData
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsGenero genero)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudGeneros", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", genero.descripcion);
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

        public static bool Actualizar(clsGenero genero)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudGeneros", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_genero", genero.id_genero);
                    cmd.Parameters.AddWithValue("@descripcion", genero.descripcion);
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

                    SqlCommand cmd = new SqlCommand("crudGeneros", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_genero", id);
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

        public static List<clsGenero> Listar()
        {
            List<clsGenero> lstGeneros = new List<clsGenero>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudGeneros", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsGenero genero = new clsGenero();
                            genero.id_genero = Convert.ToInt32(dr["id_genero"]);
                            genero.descripcion = dr["descripcion"].ToString();
                            lstGeneros.Add(genero);
                        }
                    }

                    return lstGeneros;
                }
                catch (Exception)
                {
                    return lstGeneros;
                }
            }
        }
    }
}
