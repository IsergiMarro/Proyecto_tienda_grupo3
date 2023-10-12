using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;



namespace WebApiTiendaLinea.Data
{
    public class DetalleFactura
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsDetalleFactura2 detalleFactura)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudDetallesFacturas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_factura", detalleFactura.ID_factura);
                    cmd.Parameters.AddWithValue("@id_producto", detalleFactura.ID_prducto);
                    cmd.Parameters.AddWithValue("@cantidad", detalleFactura.CANTIDAD);
                    cmd.Parameters.AddWithValue("@id_metodo_pago", detalleFactura.ID_metodo_pago);
                    cmd.Parameters.AddWithValue("@id_pedido", detalleFactura.ID_pedido);
                    cmd.Parameters.AddWithValue("@precio_unitario", detalleFactura.PRECIO_unitario);
                    cmd.Parameters.AddWithValue("@precio_linea", detalleFactura.PRECIO_linea);
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
                    cmd.Parameters.AddWithValue("@id_factura", detalleFactura.ID_factura);
                    cmd.Parameters.AddWithValue("@id_producto", detalleFactura.ID_prducto);
                    cmd.Parameters.AddWithValue("@cantidad", detalleFactura.CANTIDAD);
                    cmd.Parameters.AddWithValue("@id_metodo_pago", detalleFactura.ID_metodo_pago);
                    cmd.Parameters.AddWithValue("@id_pedido", detalleFactura.ID_pedido);
                    cmd.Parameters.AddWithValue("@precio_unitario", detalleFactura.PRECIO_unitario);
                    cmd.Parameters.AddWithValue("@precio_linea", detalleFactura.PRECIO_linea);
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
                            detalleFactura.ID_factura = Convert.ToInt32(dr["id_factura"]);
                            detalleFactura.ID_prducto = Convert.ToInt32(dr["id_producto"]);
                            detalleFactura.CANTIDAD = Convert.ToInt32(dr["cantidad"]);
                            detalleFactura.ID_metodo_pago = Convert.ToInt32(dr["id_metodo_pago"]);
                            detalleFactura.ID_pedido = Convert.ToInt32(dr["id_pedido"]);
                            detalleFactura.PRECIO_unitario = Convert.ToInt32(dr["precio_unitario"]);
                            detalleFactura.PRECIO_linea = Convert.ToInt32(dr["precio_linea"]);
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
