using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class Tipo_personas
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsTipo_personas2 tipo_personas)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudTipoPersonas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@id_tipo_persona", tipo_personas.Id);
                    cmd.Parameters.AddWithValue("@nombre_tipo_persona", tipo_personas.Nombre);
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

        public static bool Actualizar(clsTipo_personas tipo_personas)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudTipoPersonas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_tipo_persona", tipo_personas.Id);
                    cmd.Parameters.AddWithValue("@nombre_tipo_persona", tipo_personas.Nombre);
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

                    SqlCommand cmd = new SqlCommand("crudTipoPersonas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_tipo_persona", id);
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

        public static List<clsTipo_personas> Listar()
        {
            List<clsTipo_personas> lstTipo_personas = new List<clsTipo_personas>();

            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudTipoPersonas", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion", 4);

                try
                {
                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsTipo_personas Tipo_personas = new clsTipo_personas();

                            int id;
                            if (int.TryParse(dr["id_tipo_persona"].ToString(), out id))
                                Tipo_personas.Id = id;

                            Tipo_personas.Nombre = dr["nombre_tipo_persona"].ToString();
                            lstTipo_personas.Add(Tipo_personas);

                        }
                        return lstTipo_personas;
                    }
                }
                catch (SqlException ex)
                {
                    lstTipo_personas.Add(new clsTipo_personas()
                    {
                        Error = ex.Message
                    });
                    return lstTipo_personas;
                }
            }
        }


    }
}
