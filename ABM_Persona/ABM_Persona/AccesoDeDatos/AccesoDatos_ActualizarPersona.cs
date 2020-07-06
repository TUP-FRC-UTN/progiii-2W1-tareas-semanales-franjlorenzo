using ABM_Persona.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABM_Persona.AccesoDeDatos
{
    public class AccesoDatos_ActualizarPersona
    {
        public static bool ActualizarPersona(Persona persona)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"UPDATE Persona SET nombre = @nombre,
                                                       apellido = @apellido,
                                                       telefono = @telefono,
                                                       edad = @edad,
                                                       idSexo = @idSexo
                                                       WHERE id = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", persona.Id);
                comando.Parameters.AddWithValue("@nombre", persona.Nombre);
                comando.Parameters.AddWithValue("@apellido", persona.Apellido);
                comando.Parameters.AddWithValue("@telefono", persona.Telefono);
                comando.Parameters.AddWithValue("@edad", persona.Edad);
                comando.Parameters.AddWithValue("@idSexo", persona.IdSexo);

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }

        public static Persona ObtenerPersona(int idPersona)
        {
            Persona resultado = new Persona();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "SELECT * FROM Persona WHERE id = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", idPersona);

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader(); //ExecuteReader es para consultas que si devuelven resultados
                if (lector != null)
                {
                    while (lector.Read())
                    {

                        resultado.Id = int.Parse(lector["id"].ToString());
                        resultado.Nombre = lector["nombre"].ToString();
                        resultado.Apellido = lector["apellido"].ToString();
                        resultado.Telefono = lector["telefono"].ToString();
                        resultado.Edad = int.Parse(lector["edad"].ToString());
                        resultado.IdSexo = int.Parse(lector["idSexo"].ToString());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }
    }
}