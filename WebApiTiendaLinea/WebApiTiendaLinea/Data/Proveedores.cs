using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;


namespace WebApiTiendaLinea.Data
{
    public class Proveedores
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsProveedores proveedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudProveedores", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_proveedor", proveedor.Id);
                    cmd.Parameters.AddWithValue("@nombre_proveedor", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@telefono_proveedro", proveedor.Tel);
                    cmd.Parameters.AddWithValue("@descripcion", proveedor.Descripcion);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
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

        public static bool ActualizarProveedores(clsProveedores proveedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudProveedores", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_proveedor", proveedor.Id);
                    cmd.Parameters.AddWithValue("@nombre_proveedor", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@telefono_proveedro", proveedor.Tel);
                    cmd.Parameters.AddWithValue("@descripcion", proveedor.Descripcion);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
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

                    SqlCommand cmd = new SqlCommand("crudProveedores", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id_proveedor", id);
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

        public static List<clsProveedores> Listar()
        {
            List<clsProveedores> lstProveedores = new List<clsProveedores>();

            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudProveedores", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion", 4);

                try
                {
                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsProveedores proveedor = new clsProveedores();

                            int id;
                            if (int.TryParse(dr["id_proveedor"].ToString(), out id))
                                proveedor.Id = id;

                            proveedor.Nombre = dr["nombre_proveedor"].ToString();

                            int tel;
                            if (int.TryParse(dr["telefono_proveedro"].ToString(), out tel))
                                proveedor.Tel = tel;

                            proveedor.Descripcion = dr["descripcion"].ToString();
                            proveedor.Direccion = dr["direccion"].ToString();

                            lstProveedores.Add(proveedor);

                        }
                        return lstProveedores;
                    }
                }
                catch (SqlException ex)
                {
                    lstProveedores.Add(new clsProveedores()
                    {
                        Error = ex.Message
                    });
                    return lstProveedores;
                }
            }
        }


    }
}
