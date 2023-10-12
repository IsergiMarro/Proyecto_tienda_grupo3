using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class Categoria
  {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsCategoria2 categoriaProducto)
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

        public static bool Actualizar( clsCategoria categoriaProducto)
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
                    cmd.Parameters.AddWithValue("@id", id); // ID de la categoría a eliminar
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

        public static List<clsCategoria> Listar()
        {
            List<clsCategoria> lstCategoriasProductos = new List<clsCategoria>();

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
                            clsCategoria categoriaProducto = new clsCategoria();
                            categoriaProducto.id_categoria_producto = Convert.ToInt32(dr["id_categoria_producto"]);
                            categoriaProducto.descripcion = dr["descripcion"].ToString();
                            lstCategoriasProductos.Add(categoriaProducto);
                        }
                    }

                    return lstCategoriasProductos;
                }
                catch (Exception)
                {
                    return lstCategoriasProductos;
                }
            }
        }
    }
}