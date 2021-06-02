using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Api.DataAcces
{
    public class PersonaDto
    {
        public bool Agregar(IList<Models.Persona> persona)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.StringConexion()))
                {
                    cn.Open();
                    using (SqlTransaction transaction = cn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_a_Persona", cn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                foreach ( var per in persona)
                                {
                                    cmd.Parameters.Add(new SqlParameter("@nombre", per.Nombre));
                                    cmd.Parameters.Add(new SqlParameter("@apellido", per.Apellido));
                                    cmd.Parameters.Add(new SqlParameter("@curso", per.Curso));
                                    cmd.Parameters.Add(new SqlParameter("@anio", per.Año));
                                    cmd.Parameters.Add(new SqlParameter("@dni", per.Dni));
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                           }
                            
                            transaction.Commit();

                            return true;

                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Models.Persona Listado(string nroDoc) 
        {
  
            Models.Persona persona;

            try
            {
               

                using (SqlConnection cn = new SqlConnection(Conexion.StringConexion()))
                {
                    cn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_l_personas", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@dni", nroDoc));
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
    
                                    while (reader.Read())
                                    {
                                        persona = new Models.Persona();
                                        persona.Dni = reader["dni"].ToString();
                                        persona.Nombre = reader["nombre"].ToString();
                                        persona.Apellido = reader["apellido"].ToString();
                                        persona.Curso = reader["curso"].ToString();
                                        persona.Año = Int32.Parse(reader["anio"].ToString());


                                        return persona;
                                    }

                                    return null;
                                }
                                else
                                {
                                    return null;
                                }
                            }

                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<Models.Persona> ListadoGeneral()
        {
            IList<Models.Persona> ilistPersonas;
            Models.Persona persona;

            try
            {


                using (SqlConnection cn = new SqlConnection(Conexion.StringConexion()))
                {
                    cn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_l_general_personas", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    ilistPersonas = new List<Models.Persona>();


                                    while (reader.Read())
                                    {
                                        persona = new Models.Persona();
                                        persona.Dni = reader["dni"].ToString();
                                        persona.Nombre = reader["nombre"].ToString();
                                        persona.Apellido = reader["apellido"].ToString();
                                        persona.Curso = reader["curso"].ToString();
                                        persona.Año = Int32.Parse(reader["anio"].ToString());


                                        ilistPersonas.Add(persona);
                                    }

                                    return ilistPersonas;
                                }
                                else
                                {
                                    return null;
                                }
                            }

                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
