using NegocioInstrumentosMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NegocioInstrumentosMVC.AccesoDeDatos
{
    public class AD_NuevoInstrumento
    {
        public static bool InsertarNuevoInstrumento(Instrumento instrumento)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "INSERT INTO Instrumento (Nombre, Descripcion, Stock, Precio, idTipo) VALUES(@Nombre, @Descripcion, @Stock, @Precio, @idTipo)"; //idTipo para ViewModel
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Nombre", instrumento.pNombre);
                comando.Parameters.AddWithValue("@Descripcion", instrumento.pDescripcion);
                comando.Parameters.AddWithValue("@Stock", instrumento.pStock);
                comando.Parameters.AddWithValue("@Precio", instrumento.pPrecio);
                comando.Parameters.AddWithValue("@idTipo", instrumento.IdTipo); //Esto para ViewModel

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