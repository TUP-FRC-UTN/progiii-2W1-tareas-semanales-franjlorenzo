using NegocioInstrumentosMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NegocioInstrumentosMVC.AccesoDeDatos
{
    public class AD_TipoInstrumentoVM
    {
        public static List<TipoItemVM> ObtenerListaTiposInstrumentos()
        {
            List<TipoItemVM> listaInstrumentos = new List<TipoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "SELECT * FROM Tipo";
                comando.Parameters.Clear();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader lector = comando.ExecuteReader();
                if (lector != null)
                {
                    while (lector.Read())
                    {
                        TipoItemVM auxiliar = new TipoItemVM();
                        auxiliar.IdTipo = int.Parse(lector["idTipo"].ToString());
                        auxiliar.NombreTipo = lector["NombreTipo"].ToString();

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