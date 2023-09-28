using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class DepartamentoData
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsDepartamento departamento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDepartamentos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", departamento.Nombre);
                    cmd.Parameters.AddWithValue("@id_municipio", departamento.IdMunicipio);
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

        public static bool Actualizar(clsDepartamento departamento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDepartamentos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_departamento", departamento.IdDepartamento);
                    cmd.Parameters.AddWithValue("@nombre", departamento.Nombre);
                    cmd.Parameters.AddWithValue("@id_municipio", departamento.IdMunicipio);
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

                    SqlCommand cmd = new SqlCommand("crudDepartamentos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_departamento", id);
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

        public static List<clsDepartamento> Listar()
        {
            List<clsDepartamento> lstDepartamentos = new List<clsDepartamento>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDepartamentos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsDepartamento departamento = new clsDepartamento();
                            departamento.IdDepartamento = Convert.ToInt32(dr["id_departamento"]);
                            departamento.Nombre = dr["nombre"].ToString();
                            departamento.IdMunicipio = Convert.ToInt32(dr["id_municipio"]);
                            lstDepartamentos.Add(departamento);
                        }
                    }

                    return lstDepartamentos;
                }
                catch (Exception)
                {
                    return lstDepartamentos;
                }
            }
        }
    }
}
