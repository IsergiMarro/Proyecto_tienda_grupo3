using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class Factura
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsFactura2 factura)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudFacturas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_persona", factura.id_persona);
                    cmd.Parameters.AddWithValue("@fecha_venta", factura.fechventa);
                    cmd.Parameters.AddWithValue("@total_venta", factura.totalVenta);
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

        public static bool Actualizar(clsFactura factura)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudFacturas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_factura", factura.id_factura);
                    cmd.Parameters.AddWithValue("@id_persona", factura.id_persona);
                    cmd.Parameters.AddWithValue("@fecha_venta", factura.fechventa);
                    cmd.Parameters.AddWithValue("@total_venta", factura.totalVenta);
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

                    SqlCommand cmd = new SqlCommand("crudFacturas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_factura", id);
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

        public static List<clsFactura> Listar()
        {
            List<clsFactura> lstFacturas = new List<clsFactura>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudFacturas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsFactura factura = new clsFactura();
                            int idfactu;
                            if (int.TryParse(dr["id_factura"].ToString(), out idfactu))
                                factura.id_factura = idfactu;
                            int idpers;
                            if (int.TryParse(dr["id_persona"].ToString(), out idpers))
                                factura.id_persona = idpers; 

                            factura.fechventa = dr["fecha_venta"].ToString();

                            int totalfac;
                            if (int.TryParse(dr["total_venta"].ToString(), out totalfac))
                                factura.totalVenta = totalfac;

                            lstFacturas.Add(factura);
                        }
                    }

                    return lstFacturas;
                }
                catch (Exception)
                {
                    return lstFacturas;
                }
            }
        }
    }
}