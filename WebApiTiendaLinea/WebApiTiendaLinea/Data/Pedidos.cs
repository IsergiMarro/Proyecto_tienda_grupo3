using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class Pedidos
    {
        private static string connectionString = Conexiones.rutaConexion;

        public static bool Registrar(clsPedidos pedido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudPedidos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pedido", pedido.Id);
                    cmd.Parameters.AddWithValue("@id_persona", pedido.Persona);
                    cmd.Parameters.AddWithValue("@fecha_pedido", pedido.Fecha_Pedido);
                    cmd.Parameters.AddWithValue("@total", pedido.Total);
                    cmd.Parameters.AddWithValue("@id_estado", pedido.Estado);
                    cmd.Parameters.AddWithValue("@cantidad", pedido.Cantidad);
                    cmd.Parameters.AddWithValue("@id_detalle_carrito", pedido.Detalle_carrito);
                    cmd.Parameters.AddWithValue("@id_metodo_pago", pedido.Metodo_Pago);
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

        public static bool Actualizar(clsPedidos pedido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudPedidos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pedido", pedido.Id);
                    cmd.Parameters.AddWithValue("@id_persona", pedido.Persona);
                    cmd.Parameters.AddWithValue("@fecha_pedido", pedido.Fecha_Pedido);
                    cmd.Parameters.AddWithValue("@total", pedido.Total);
                    cmd.Parameters.AddWithValue("@id_estado", pedido.Estado);
                    cmd.Parameters.AddWithValue("@cantidad", pedido.Cantidad);
                    cmd.Parameters.AddWithValue("@id_detalle_carrito", pedido.Detalle_carrito);
                    cmd.Parameters.AddWithValue("@id_metodo_pago", pedido.Metodo_Pago);
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

                    SqlCommand cmd = new SqlCommand("crudPedidos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pedido", id);
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

        public static List<clsPedidos> Listar()
        {
            List<clsPedidos> lstpedidos = new List<clsPedidos>();

            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudPedidos", objConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion", 4);

                try
                {
                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsPedidos pedidos = new clsPedidos();

                            int id;
                            if (int.TryParse(dr["id_pedido"].ToString(), out id))
                                pedidos.Id = id;
                            int id_Persona;
                            if (int.TryParse(dr["id_persona"].ToString(), out id_Persona))
                                pedidos.Persona = id_Persona;

                            pedidos.Fecha_Pedido = dr["fecha_pedido"].ToString();

                            int Total;
                            if (int.TryParse(dr["total"].ToString(), out Total))
                                pedidos.Total = Total;

                            int Estado;
                            if (int.TryParse(dr["id_estado"].ToString(), out Estado))
                                pedidos.Estado = Estado;

                            int Cantidad;
                            if (int.TryParse(dr["cantidad"].ToString(), out Cantidad))
                                pedidos.Cantidad = Cantidad;

                            int detalle_carrito;
                            if (int.TryParse(dr["id_detalle_carrito"].ToString(), out detalle_carrito))
                                pedidos.Detalle_carrito = detalle_carrito;

                            int metodo_pago;
                            if (int.TryParse(dr["id_detalle_carrito"].ToString(), out metodo_pago))
                                pedidos.Metodo_Pago = metodo_pago;

                            lstpedidos.Add(pedidos);

                        }
                        return lstpedidos;
                    }
                }
                catch (SqlException ex)
                {
                    lstpedidos.Add(new clsPedidos()
                    {
                        Error = ex.Message
                    });
                    return lstpedidos;
                }
            }
        }


    }
}

