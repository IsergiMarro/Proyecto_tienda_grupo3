using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class CategoriaData
    {
        public static bool Registrar(clsCategoria categoria)
        {
            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                try
                {
                    objConexion.Open();

                    SqlCommand cmd = new SqlCommand("crudCategoriaProductos", objConexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_categoria", categoria.Id);
                    cmd.Parameters.AddWithValue("@descripcion_categoria", categoria.Descripcion);

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
            List<clsCategoria> lstCategorias = new List<clsCategoria>();

            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                try
                {
                    objConexion.Open();

                    SqlCommand cmd = new SqlCommand("crudCategoriaProductos", objConexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsCategoria categoria = new clsCategoria();
                            int id;

                            // Corrección aquí
                            if (int.TryParse(dr["id_categoria_producto"].ToString(), out id))
                                categoria.Id = id;

                            categoria.Descripcion = dr["descripcion"].ToString();
                            lstCategorias.Add(categoria);
                        }
                    }

                    return lstCategorias;
                }
                catch (SqlException ex)
                {
                    lstCategorias.Add(new clsCategoria()
                    {
                        Error = ex.Message
                    });
                    return lstCategorias;
                }
            }
        }
    }
}
