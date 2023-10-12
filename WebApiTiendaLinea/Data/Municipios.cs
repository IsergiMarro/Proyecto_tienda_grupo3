using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class Municipios
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsMunicipio2 municipio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudMunicipios", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@id_municipio", municipio.Id);
                    cmd.Parameters.AddWithValue("@nombre", municipio.Nombre);
                    cmd.Parameters.AddWithValue("@id_departamento", municipio.IdMunicipio);
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

        public static bool Actualizar(clsMunicipio municipio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudMunicipios", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_municipio", municipio.Id);
                    cmd.Parameters.AddWithValue("@nombre", municipio.Nombre);
                    cmd.Parameters.AddWithValue("@id_departamento", municipio.IdMunicipio);
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

                    SqlCommand cmd = new SqlCommand("crudMunicipios", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_municipio", id);
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

        public static List<clsMunicipio> Listar()
        {
            List<clsMunicipio> lstmunicipio = new List<clsMunicipio>();

            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudMunicipios", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion", 4);

                try
                {
                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsMunicipio municipio = new clsMunicipio();

                            int id;
                            if (int.TryParse(dr["id_municipio"].ToString(), out id))
                                municipio.Id = id;


                            municipio.Nombre = dr["nombre"].ToString();
                            lstmunicipio.Add(municipio);

                            int idM;
                            if (int.TryParse(dr["id_departamento"].ToString(), out idM))
                                municipio.IdMunicipio = idM;

                        }
                        return lstmunicipio;
                    }
                }
                catch (SqlException ex)
                {
                    lstmunicipio.Add(new clsMunicipio()
                    {
                      
                    });
                    return lstmunicipio;
                }
            }
        }


    }
}
