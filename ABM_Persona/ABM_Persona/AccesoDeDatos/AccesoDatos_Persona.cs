using ABM_Persona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ABM_Persona.AccesoDeDatos
{
    public class AccesoDatos_Persona
    {
        //ESTE METODO INSERTA UNA PERSONA EN LA BBDD
        public static bool InsertarNuevaPersona(Persona persona)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion); //creamos una nueva conexion con la BBDD

            try
            {
                SqlCommand comando = new SqlCommand(); //creamos un nuevo comando para ejecutar consultas
                string consulta = "INSERT INTO Persona (nombre, apellido, telefono, edad, idSexo) VALUES(@nombre, @apellido, @telefono, @edad, @idSexo)"; //guardamos la consulta en una variable string
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", persona.Nombre); //agregamos los parametros de esta forma para no permitir inyeccion SQL
                comando.Parameters.AddWithValue("@apellido", persona.Apellido);
                comando.Parameters.AddWithValue("@telefono", persona.Telefono);
                comando.Parameters.AddWithValue("@edad", persona.Edad);
                comando.Parameters.AddWithValue("@idSexo", persona.IdSexo); //ESTO PARA VIEWMODEL

                comando.CommandType = System.Data.CommandType.Text; //le decimos al comando que le pasamos una consulta de tipo texto
                comando.CommandText = consulta; //le pasamos al comando la consulta guardada en la variable

                conexion.Open();
                comando.Connection = conexion; //al comando le decimos a donde conectarse, en este caso a nuestra conexion
                comando.ExecuteNonQuery(); //el comando ejecuta la sentencia.
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