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

            public static bool Registrar(clsPersona2 persona)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("crudPersonas", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@id_persona", persona.Id);
                        cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", persona.Apellido);
                        cmd.Parameters.AddWithValue("@contraseña", persona.Pass);
                        cmd.Parameters.AddWithValue("@correo_electronico", persona.Correo);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", persona.FechaN);
                        cmd.Parameters.AddWithValue("@telefono", persona.tel);
                        cmd.Parameters.AddWithValue("@id_genero", persona.Genero);
                        cmd.Parameters.AddWithValue("@DPI", persona.DPI);
                        cmd.Parameters.AddWithValue("@NIT", persona.NIT);
                        cmd.Parameters.AddWithValue("@id_tipo_persona", persona.TipoPersona);
                        cmd.Parameters.AddWithValue("@direccion", persona.Direccion);
                        cmd.Parameters.AddWithValue("@id_municipio", persona.Municipio);
                        cmd.Parameters.AddWithValue("@id_departamento", persona.Departamento);
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

        public static bool Actualizar(clsPersona persona)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("crudPersonas", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_persona", persona.Id);
                    cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", persona.Apellido);
                    cmd.Parameters.AddWithValue("@contraseña", persona.Pass);
                    cmd.Parameters.AddWithValue("@correo_electronico", persona.Correo);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", persona.FechaN);
                    cmd.Parameters.AddWithValue("@telefono", persona.tel);
                    cmd.Parameters.AddWithValue("@id_genero", persona.Genero);
                    cmd.Parameters.AddWithValue("@DPI", persona.DPI);
                    cmd.Parameters.AddWithValue("@NIT", persona.NIT);
                    cmd.Parameters.AddWithValue("@id_tipo_persona", persona.TipoPersona);
                    cmd.Parameters.AddWithValue("@direccion", persona.Direccion);
                    cmd.Parameters.AddWithValue("@id_municipio", persona.Municipio);
                    cmd.Parameters.AddWithValue("@id_departamento", persona.Departamento);
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

                            persona.Nombre = dr["nombre"].ToString();
                            persona.Apellido = dr["apellido"].ToString();
                            persona.Pass = dr["contraseña"].ToString();
                            persona.Correo = dr["correo_electronico"].ToString();
                            persona.FechaN = dr["fecha_nacimiento"].ToString();

                            int Telefono;
                            if (int.TryParse(dr["telefono"].ToString(), out Telefono))
                                persona.tel = Telefono;

                            int Genero;
                            if (int.TryParse(dr["id_genero"].ToString(), out Genero))
                                persona.Genero = Genero;

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

                    });
                    return lstPersona;
                }
            }
        }

    }
}