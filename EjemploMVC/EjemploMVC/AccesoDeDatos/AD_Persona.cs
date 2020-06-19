using EjemploMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using EjemploMVC.ViewModels;

namespace EjemploMVC.AccesoDeDatos
{
    public class AD_Persona
    {
        public static bool InsertarNuevaPersona(Persona persona)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion); //creamos una nueva conexion con la BBDD

            try
            {
                SqlCommand comando = new SqlCommand(); //creamos un nuevo comando para ejecutar consultas
                string consulta = "INSERT INTO Persona VALUES(@nombre, @apellido, @telefono, @edad, @idSexo)"; //guardamos la consulta en una variable string
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", persona.nombre); //agregamos los parametros de esta forma para no permitir inyeccion SQL
                comando.Parameters.AddWithValue("@apellido", persona.apellido);
                comando.Parameters.AddWithValue("@telefono", persona.telefono);
                comando.Parameters.AddWithValue("@edad", persona.edad);
                comando.Parameters.AddWithValue("@idSexo", persona.IdSexo);
                
                comando.CommandType = System.Data.CommandType.Text; //le decimos al comando que le pasamos una consulta de tipo texto
                comando.CommandText = consulta; //le pasamos al comando la consulta guardada en la variable

                conexion.Open();
                comando.Connection = conexion; //al comando le decimos a donde conectarse, en este caso a nuestra conexion
                comando.ExecuteNonQuery(); //el comando ejecuta la sentencia. NonQuery es para consultas que devuelven valores
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

        public static List<Persona> ObtenerListaPersona()
        {
            List<Persona> resultado = new List<Persona>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "SELECT * FROM Persona";
                comando.Parameters.Clear();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader(); //ExecuteReader es para consultas que si devuelven resultados
                if(lector != null)
                {
                    while (lector.Read())
                    {
                        Persona auxiliar = new Persona();
                        auxiliar.id = int.Parse(lector["id"].ToString());
                        auxiliar.nombre = lector["nombre"].ToString();
                        auxiliar.apellido = lector["apellido"].ToString();
                        auxiliar.telefono = lector["telefono"].ToString();
                        auxiliar.edad = int.Parse(lector["edad"].ToString());

                        resultado.Add(auxiliar);
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

        public static List<SexoItemVM> ObtenerListaSexos()
        {
            List<SexoItemVM> resultado = new List<SexoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "SELECT * FROM Sexo";
                comando.Parameters.Clear();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader(); //ExecuteReader es para consultas que si devuelven resultados
                if (lector != null)
                {
                    while (lector.Read())
                    {
                        SexoItemVM auxiliar = new SexoItemVM();
                        auxiliar.IdSexo = int.Parse(lector["id"].ToString());
                        auxiliar.Nombre = lector["nombre"].ToString();
                        resultado.Add(auxiliar);
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

        public static Persona ObtenerPersona(int idPersona)
        {
            Persona resultado = new Persona();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

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
                        
                        resultado.id = int.Parse(lector["id"].ToString());
                        resultado.nombre = lector["nombre"].ToString();
                        resultado.apellido = lector["apellido"].ToString();
                        resultado.telefono = lector["telefono"].ToString();
                        resultado.edad = int.Parse(lector["edad"].ToString());
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

        public static bool ActualizarDatosPersona(Persona persona)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "UPDATE Persona SET nombre = @nombre, apellido = @apellido, telefono = @telefono, edad = @edad, idSexo = @idSexo WHERE id = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", persona.nombre);
                comando.Parameters.AddWithValue("@apellido", persona.apellido);
                comando.Parameters.AddWithValue("@telefono", persona.telefono);
                comando.Parameters.AddWithValue("@edad", persona.edad);
                comando.Parameters.AddWithValue("@idSexo", persona.IdSexo);
                comando.Parameters.AddWithValue("@id", persona.id);

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

        public static bool EliminarDatosPersona(Persona persona)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "DELETE FROM Persona WHERE id = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", persona.id);

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
    }
}