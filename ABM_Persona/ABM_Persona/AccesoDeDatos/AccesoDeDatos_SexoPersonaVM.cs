using ABM_Persona.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABM_Persona.AccesoDeDatos
{
    public class AccesoDeDatos_SexoPersonaVM
    {
        public static List<SexoItemVM> ObtenerListaSexos()
        {
            List<SexoItemVM> listaSexos = new List<SexoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

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

                SqlDataReader lector = comando.ExecuteReader();
                if (lector != null)
                {
                    while (lector.Read())
                    {
                        SexoItemVM auxiliar = new SexoItemVM();
                        auxiliar.IdSexo = int.Parse(lector["idSexo"].ToString());
                        auxiliar.Nombre = lector["nombre"].ToString();

                        listaSexos.Add(auxiliar);
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
            return listaSexos;
        }
    }
}