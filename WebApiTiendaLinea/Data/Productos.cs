using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class Productos
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsProducto2 producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudProductos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@id_productos", producto.Id);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@id_proveedor", producto.Proveedor);
                    cmd.Parameters.AddWithValue("@id_categoria_producto", producto.Categoria);
                    cmd.Parameters.AddWithValue("@id_marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@imagen_producto",producto.Imagen);
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

        public static bool Actualizar(clsProducto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudProductos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_productos", producto.Id);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@id_proveedor", producto.Proveedor);
                    cmd.Parameters.AddWithValue("@id_categoria_producto", producto.Categoria);
                    cmd.Parameters.AddWithValue("@id_marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@imagen_producto", producto.Imagen);
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

                    SqlCommand cmd = new SqlCommand("crudProductos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_productos", id);
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

        public static List<clsProducto> Listar()
        {
            List<clsProducto> lstproductos = new List<clsProducto>();

            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudProductos", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion", 4);

                try
                {
                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsProducto productos = new clsProducto();

                            int id;
                            if (int.TryParse(dr["id_productos"].ToString(), out id))
                                productos.Id = id;

                            productos.Nombre = dr["nombre"].ToString();
                            productos.Descripcion = dr["descripcion"].ToString();
                            

                            int precio;
                            if (int.TryParse(dr["precio"].ToString(), out precio))
                                productos.Precio = precio;

                            int Stok;
                            if (int.TryParse(dr["stock"].ToString(), out Stok))
                                productos.Stock = Stok;

                            int probeedor;
                            if (int.TryParse(dr["id_proveedor"].ToString(), out probeedor))
                                productos.Proveedor = probeedor;

                            int categoria;
                            if (int.TryParse(dr["id_categoria_producto"].ToString(), out categoria))
                                productos.Categoria = categoria;

                            int marca;
                            if (int.TryParse(dr["id_marca"].ToString(), out marca))
                                productos.Marca = marca;

                            productos.Imagen = dr["imagen_producto"].ToString();

                            lstproductos.Add(productos);

                        }
                        return lstproductos;
                    }
                }
                catch (SqlException ex)
                {
                    lstproductos.Add(new clsProducto()
                    {
                     //   Error = ex.Message
                    });
                    return lstproductos;
                }
            }
        }


    }
}
