using NegocioInstrumentosMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NegocioInstrumentosMVC.AccesoDeDatos
{
    public class AD_EliminarInstrumento
    {
        public static bool EliminarPersona(Instrumento instrumento)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "DELETE FROM Instrumento WHERE idInstrumento = @id";
                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@id", instrumento.IdInstrumento);

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

        public static Instrumento ObtenerInstrumento(int idInstrumento)
        {
            Instrumento resultado = new Instrumento();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "SELECT * FROM Instrumento WHERE idInstrumento = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", idInstrumento);

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader();
                if (lector != null)
                {
                    while (lector.Read())
                    {
                        resultado.IdInstrumento = int.Parse(lector["idInstrumento"].ToString());
                        resultado.pNombre = lector["Nombre"].ToString();
                        resultado.pDescripcion = lector["Descripcion"].ToString();
                        resultado.pStock = int.Parse(lector["Stock"].ToString());
                        resultado.pPrecio = float.Parse(lector["Precio"].ToString());
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