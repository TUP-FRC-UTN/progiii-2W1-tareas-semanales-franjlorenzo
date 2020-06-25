using ABM_Persona.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABM_Persona.AccesoDeDatos
{
    public class AccesoDatos_EliminarPersona
    {
        //ESTE METODO BORRA UNA PERSONA DE LA BBDD
        public static bool EliminarPersona(Persona persona)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "DELETE FROM Persona WHERE id = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", persona.Id);

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