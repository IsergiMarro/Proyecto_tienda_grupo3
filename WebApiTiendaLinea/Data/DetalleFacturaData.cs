using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class DetalleFacturaData
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsDetalleFactura detalleFactura)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDetallesFacturas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", detalleFactura.descripcion);
                    cmd.Parameters.AddWithValue("@id_factura", detalleFactura.id_factura);
                    cmd.Parameters.AddWithValue("@id_metodo_pago", detalleFactura.id_metodo_pago);
                    cmd.Parameters.AddWithValue("@id_pedido", detalleFactura.id_pedido);
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

        public static bool Actualizar(clsDetalleFactura detalleFactura)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDetallesFacturas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_detalle_facturas", detalleFactura.id_detalle_facturas);
                    cmd.Parameters.AddWithValue("@descripcion", detalleFactura.descripcion);
                    cmd.Parameters.AddWithValue("@id_factura", detalleFactura.id_factura);
                    cmd.Parameters.AddWithValue("@id_metodo_pago", detalleFactura.id_metodo_pago);
                    cmd.Parameters.AddWithValue("@id_pedido", detalleFactura.id_pedido);
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

                    SqlCommand cmd = new SqlCommand("crudDetallesFacturas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_detalle_facturas", id);
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

        public static List<clsDetalleFactura> Listar()
        {
            List<clsDetalleFactura> lstDetallesFacturas = new List<clsDetalleFactura>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDetallesFacturas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@opcion", 4);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsDetalleFactura detalleFactura = new clsDetalleFactura();
                            detalleFactura.id_detalle_facturas = Convert.ToInt32(dr["id_detalle_facturas"]);
                            detalleFactura.descripcion = dr["descripcion"].ToString();
                            detalleFactura.id_factura = Convert.ToInt32(dr["id_factura"]);
                            detalleFactura.id_metodo_pago = Convert.ToInt32(dr["id_metodo_pago"]);
                            detalleFactura.id_pedido = Convert.ToInt32(dr["id_pedido"]);
                            lstDetallesFacturas.Add(detalleFactura);
                        }
                    }

                    return lstDetallesFacturas;
                }
                catch (Exception)
                {
                    return lstDetallesFacturas;
                }
            }
        }
    }
}
