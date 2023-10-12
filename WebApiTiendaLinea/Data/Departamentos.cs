using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;


namespace WebApiTiendaLinea.Data
{
    public class Departamentos
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsDepartamento2 departamento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDepartamentos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                  //  cmd.Parameters.AddWithValue("@id_departamento", departamento.IdDepartamento);
                    cmd.Parameters.AddWithValue("@nombre", departamento.Nombre);
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
            List<clsDepartamento> lstDepartamento= new List<clsDepartamento>();

            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudDepartamentos", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion", 4);

                try
                {
                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsDepartamento departamento = new clsDepartamento();

                            int id;
                            if (int.TryParse(dr["id_departamento"].ToString(), out id))
                                departamento.IdDepartamento = id;

                            departamento.Nombre = dr["nombre"].ToString();


                            lstDepartamento.Add(departamento);

                        }
                        return lstDepartamento;
                    }
                }
                catch (SqlException ex)
                {
                    lstDepartamento.Add(new clsDepartamento()
                    {
                      
                    });
                    return lstDepartamento;
                }
            }
        }


    }
}