using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class CategoriaProductosData
    {
        private static string connectionString = "TuCadenaDeConexion"; // Reemplaza con tu cadena de conexión

        public static bool Registrar(CategoriaProductos categoriaProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudCategoriaProductos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", categoriaProducto.descripcion);
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

        public static bool Actualizar(CategoriaProductos categoriaProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudCategoriaProductos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", categoriaProducto.id_categoria_producto);
                    cmd.Parameters.AddWithValue("@descripcion", categoriaProducto.descripcion);
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

                    SqlCommand cmd = new SqlCommand("crudCategoriaProductos", connection);
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

        public static List<CategoriaProductos> Listar()
        {
            List<CategoriaProductos> lstCategoriaProductos = new List<CategoriaProductos>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudCategoriaProductos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CategoriaProductos categoriaProducto = new CategoriaProductos();
                            categoriaProducto.id_categoria_producto = Convert.ToInt32(dr["id_categoria_producto"]);
                            categoriaProducto.descripcion = dr["descripcion"].ToString();
                            lstCategoriaProductos.Add(categoriaProducto);
                        }
                    }

                    return lstCategoriaProductos;
                }
                catch (Exception)
                {
                    return lstCategoriaProductos;
                }
            }
        }
    }
}
