using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class Estado
    {
            private static string connectionString = Conexiones.rutaConexion;

            public static bool Registrar(clsEstados2 estado)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("crudEstados", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@descripcion", estado.descripcion);
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

            public static bool Actualizar(clsEstados estado)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("crudEstados", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_estado", estado.id_estado);
                        cmd.Parameters.AddWithValue("@descripcion", estado.descripcion);
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

                        SqlCommand cmd = new SqlCommand("crudEstados", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_estado", id);
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

            public static List<clsEstados> Listar()
            {
                List<clsEstados> lstEstados = new List<clsEstados>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("crudEstados", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@opcion", 4);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                clsEstados estado = new clsEstados();
                                estado.id_estado = Convert.ToInt32(dr["id_estado"]);
                                estado.descripcion = dr["descripcion"].ToString();
                                lstEstados.Add(estado);
                            }
                        }

                        return lstEstados;
                    }
                    catch (Exception)
                    {
                        return lstEstados;
                    }
                }
            }
        }
    }




