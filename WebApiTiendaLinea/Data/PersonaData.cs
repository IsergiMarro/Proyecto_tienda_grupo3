using System.Data;
using System.Data.SqlClient;
using WebApiTiendaLinea.Models;
using System;
using System.Collections.Generic;

namespace WebApiTiendaLinea.Data
{
    public class PersonaData
    {
        private static string connectionString = Conexiones.rutaConexion;
        public static bool Registrar(clsPersona objPersona)
        {
            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudPersonas", objConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_persona", objPersona.Id);
                cmd.Parameters.AddWithValue("@nombre_persona", objPersona.Nombre);
                cmd.Parameters.AddWithValue("@apellido_persona", objPersona.Apellido);
                cmd.Parameters.AddWithValue("@contraseña", objPersona.Pass);
                cmd.Parameters.AddWithValue("@correo_electronico", objPersona.Correo);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", objPersona.FechaN);
                cmd.Parameters.AddWithValue("@id_genero", objPersona.Genero);
                cmd.Parameters.AddWithValue("@DPI", objPersona.DPI);
                cmd.Parameters.AddWithValue("@NIT", objPersona.NIT);
                cmd.Parameters.AddWithValue("@id_tipo_persona", objPersona.TipoPersona);
                cmd.Parameters.AddWithValue("@direccion", objPersona.Direccion);
                cmd.Parameters.AddWithValue("@id_municipio", objPersona.Municipio);
                cmd.Parameters.AddWithValue("@id_departamento", objPersona.Departamento);
                cmd.Parameters.AddWithValue("@opcion, 4", objPersona.OPC);

                try
                {
                    objConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<clsPersona> Listar()
        {
            List<clsPersona> lstPersona = new List<clsPersona>();
            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudPersonas", objConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion", 4);

                try
                {
                    objConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clsPersona persona = new clsPersona();

                            int id;
                            if (int.TryParse(dr["id_persona"].ToString(), out id))
                                persona.Id = id;

                            persona.Nombre = dr["nombre_persona"].ToString();
                            persona.Apellido = dr["apellido_persona"].ToString();
                            persona.Pass = dr["contraseña"].ToString();
                            persona.Correo = dr["correo_electronico"].ToString();
                            persona.FechaN = dr["fecha_nacimiento"].ToString();

                            int genero;
                            if (int.TryParse(dr["id_genero"].ToString(), out genero))
                                persona.Genero = genero;

                            int dpi;
                            if (int.TryParse(dr["DPI"].ToString(), out dpi))
                                persona.DPI = dpi;

                            int nit;
                            if (int.TryParse(dr["NIT"].ToString(), out nit))
                                persona.NIT = nit;

                            int tipoPersona;
                            if (int.TryParse(dr["id_tipo_persona"].ToString(), out tipoPersona))
                                persona.TipoPersona = tipoPersona;

                            persona.Direccion = dr["direccion"].ToString();

                            int municipio;
                            if (int.TryParse(dr["id_municipio"].ToString(), out municipio))
                                persona.Municipio = municipio;

                            int departamento;
                            if (int.TryParse(dr["id_departamento"].ToString(), out departamento))
                                persona.Departamento = departamento;

                            lstPersona.Add(persona);
                        }
                        return lstPersona;
                    }
                }
                catch (SqlException ex)
                {
                    lstPersona.Add(new clsPersona()
                    {
                        Error = ex.Message
                    });
                    return lstPersona;
                }
            }
        }
        public static bool Insertar(clsPersona objPersona)
        {
            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudPersonas", objConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Configura los parámetros para la inserción
                cmd.Parameters.AddWithValue("@id_persona", objPersona.Id);
                cmd.Parameters.AddWithValue("@nombre_persona", objPersona.Nombre);
                cmd.Parameters.AddWithValue("@apellido_persona", objPersona.Apellido);
                cmd.Parameters.AddWithValue("@contraseña", objPersona.Pass);
                cmd.Parameters.AddWithValue("@correo_electronico", objPersona.Correo);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", objPersona.FechaN);
                cmd.Parameters.AddWithValue("@id_genero", objPersona.Genero);
                cmd.Parameters.AddWithValue("@DPI", objPersona.DPI);
                cmd.Parameters.AddWithValue("@NIT", objPersona.NIT);
                cmd.Parameters.AddWithValue("@id_tipo_persona", objPersona.TipoPersona);
                cmd.Parameters.AddWithValue("@direccion", objPersona.Direccion);
                cmd.Parameters.AddWithValue("@id_municipio", objPersona.Municipio);
                cmd.Parameters.AddWithValue("@id_departamento", objPersona.Departamento);
                cmd.Parameters.AddWithValue("@opcion", 1); // 1 para inserción

                try
                {
                    objConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Actualizar(clsPersona objPersona)
        {
            using (SqlConnection objConexion = new SqlConnection(Conexiones.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("crudPersonas", objConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_persona", objPersona.Id);
                cmd.Parameters.AddWithValue("@nombre_persona", objPersona.Nombre);
                cmd.Parameters.AddWithValue("@apellido_persona", objPersona.Apellido);
                cmd.Parameters.AddWithValue("@contraseña", objPersona.Pass);
                cmd.Parameters.AddWithValue("@correo_electronico", objPersona.Correo);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", objPersona.FechaN);
                cmd.Parameters.AddWithValue("@id_genero", objPersona.Genero);
                cmd.Parameters.AddWithValue("@DPI", objPersona.DPI);
                cmd.Parameters.AddWithValue("@NIT", objPersona.NIT);
                cmd.Parameters.AddWithValue("@id_tipo_persona", objPersona.TipoPersona);
                cmd.Parameters.AddWithValue("@direccion", objPersona.Direccion);
                cmd.Parameters.AddWithValue("@id_municipio", objPersona.Municipio);
                cmd.Parameters.AddWithValue("@id_departamento", objPersona.Departamento);
                cmd.Parameters.AddWithValue("@opcion , 2", objPersona.OPC);

                try
                {
                    objConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
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

                    SqlCommand cmd = new SqlCommand("crudPersonas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_persona", id);
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

    }
}