using NegocioInstrumentosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace NegocioInstrumentosMVC.AccesoDeDatos
{
    public class AD_ListadoInstrumento
    {
        public static List<Instrumento> ObtenerListadoInstrumentos()
        {
            List<Instrumento> listaInstrumentos = new List<Instrumento>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "SELECT idInstrumento, Nombre, Descripcion, Stock, Precio FROM Instrumento";
                comando.Parameters.Clear();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader();
                if(lector != null)
                {
                    while (lector.Read())
                    {
                        Instrumento auxiliar = new Instrumento();
                        auxiliar.IdInstrumento = int.Parse(lector["idInstrumento"].ToString());
                        auxiliar.pNombre = lector["Nombre"].ToString();
                        auxiliar.pDescripcion = lector["Descripcion"].ToString();
                        auxiliar.pStock = int.Parse(lector["Stock"].ToString());
                        auxiliar.pPrecio = float.Parse(lector["Precio"].ToString());

                        listaInstrumentos.Add(auxiliar);
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
            return listaInstrumentos;
        }
    }
}