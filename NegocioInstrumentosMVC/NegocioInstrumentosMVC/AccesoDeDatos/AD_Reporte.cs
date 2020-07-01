using NegocioInstrumentosMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NegocioInstrumentosMVC.AccesoDeDatos
{
    public class AD_Reporte
    {
        public static List<InstrumentoItemVM> obtenerReporteInstrumentos()
        {
            List<InstrumentoItemVM> listaInstrumentos = new List<InstrumentoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"select i.Nombre, i.Descripcion, i.Stock, i.Precio
                                    from Instrumento i join Tipo t on i.idTipo = t.idTipo
                                    where t.NombreTipo = 'Percusion'
                                    order by 4 desc";
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
                        InstrumentoItemVM auxiliar = new InstrumentoItemVM();
                        auxiliar.Nombre = lector["Nombre"].ToString();
                        auxiliar.Descripcion = lector["Descripcion"].ToString();
                        auxiliar.Stock = int.Parse(lector["Stock"].ToString());
                        auxiliar.Precio = float.Parse(lector["Precio"].ToString());

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