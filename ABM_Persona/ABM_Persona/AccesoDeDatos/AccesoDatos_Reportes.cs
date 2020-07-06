using ABM_Persona.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABM_Persona.AccesoDeDatos
{
    public class AccesoDatos_Reportes
    {
        public static List<PersonaItemVM> obtenerReportePersonas()
        {
            List<PersonaItemVM> listaPersona = new List<PersonaItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"SELECT p.id, p.nombre, p.apellido, p.edad, p.telefono, s.nombre 'Sexo'
                                    from Persona p join Sexo s on p.idSexo = s.idSexo";
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
                        PersonaItemVM auxiliar = new PersonaItemVM();
                        auxiliar.Id = int.Parse(lector["id"].ToString());
                        auxiliar.Nombre = lector["nombre"].ToString();
                        auxiliar.Apellido = lector["apellido"].ToString();
                        auxiliar.Telefono = lector["telefono"].ToString();
                        auxiliar.Edad = int.Parse(lector["edad"].ToString());
                        auxiliar.SexoNombre = lector["Sexo"].ToString();

                        listaPersona.Add(auxiliar);
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
            return listaPersona;
        }

        public static List<SexoItemVM> cantidadPersonasPorSexo()
        {
            List<SexoItemVM> listaPersona = new List<SexoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = @"SELECT s.nombre 'Sexo', count(*) 'Cantidad'
                                    from Sexo s join Persona p on p.idSexo = s.idSexo
                                    group by s.nombre";
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
                        auxiliar.Nombre = lector["Sexo"].ToString();
                        auxiliar.Cantidad = int.Parse(lector["Cantidad"].ToString());

                        listaPersona.Add(auxiliar);
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
            return listaPersona;
        }
    }
}